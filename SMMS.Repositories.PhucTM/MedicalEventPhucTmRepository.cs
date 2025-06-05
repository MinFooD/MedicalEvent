using Microsoft.EntityFrameworkCore;
using SMMS.Repositories.PhucTM.Basic;
using SMMS.Repositories.PhucTM.ModelExtensions;
using SMMS.Repositories.PhucTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.Repositories.PhucTM
{
	public class MedicalEventPhucTmRepository : GenericRepository<MedicalEventPhucTm>
	{
		public MedicalEventPhucTmRepository() => _context ??= new DBContext.SU25_PRN232_SE1725_G2_SchoolMedicalManagementSystemContext();

		public MedicalEventPhucTmRepository(DBContext.SU25_PRN232_SE1725_G2_SchoolMedicalManagementSystemContext context) => _context = context;

		public async Task<List<MedicalEventPhucTm>> GetAllMedicalEvents()
		{
			var list = await _context.MedicalEventPhucTms.Include(x => x.EventTypePhucTm).ToListAsync();
			return list ?? new List<MedicalEventPhucTm>();
		}

		public async Task<MedicalEventPhucTm> GetByIdAsync(int code)
		{
			var item = await _context.MedicalEventPhucTms
				.Include(x => x.EventTypePhucTm)
				.FirstOrDefaultAsync(x => x.MedicalEventPhucTmid == code);
			return item ?? new MedicalEventPhucTm();
		}

		public async Task<List<MedicalEventPhucTm>> SearchAsync(string des1, decimal heartRate, string des2)
		{
			var list = await _context.MedicalEventPhucTms.Include(x => x.EventTypePhucTm)
				.Where(x => 
				(x.Description.Contains(des1) || string.IsNullOrEmpty(des1))
				&& (heartRate == 0 || x.HeartRate == heartRate || heartRate == null)
				&& (x.EventTypePhucTm.Description.Contains (des2) || string.IsNullOrEmpty(des2)))
				.ToListAsync();
			return list ?? new List<MedicalEventPhucTm>();
		}

		public async Task<PaginationResult<List<MedicalEventPhucTm>>> SearchWithPagingAsync(string des1, decimal heartRate, string des2, int currentPage, int pageSize)
		{
			var list = await this.SearchAsync(des1, heartRate, des2);

			var totalItems = list.Count;
			var totalPages = (int)Math.Ceiling((double)totalItems / pageSize);

			list = list.Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
			var result = new PaginationResult<List<MedicalEventPhucTm>>
			{
				TotalItems = totalItems,
				TotalPages = totalPages,
				CurrentPage = currentPage,
				PageSize = pageSize,
				Items = list
			};

			return result;
		}

		public async Task<PaginationResult<List<MedicalEventPhucTm>>> SearchWithPagingAsync(SearchMedicalEventRequest searchRequest)
		{
			var list = await this.SearchAsync(searchRequest.Des1, searchRequest.HeartRate.GetValueOrDefault(), searchRequest.Des2);

			var totalItems = list.Count;
			var totalPages = (int)Math.Ceiling((double)totalItems / searchRequest.PageSize.GetValueOrDefault());

			list = list.Skip(searchRequest.PageSize.GetValueOrDefault() * (searchRequest.CurrentPage.GetValueOrDefault() - 1)).Take(searchRequest.PageSize.GetValueOrDefault()).ToList();
			var result = new PaginationResult<List<MedicalEventPhucTm>>
			{
				TotalItems = totalItems,
				TotalPages = totalPages,
				CurrentPage = searchRequest.CurrentPage.GetValueOrDefault(),
				PageSize = searchRequest.PageSize.GetValueOrDefault(),
				Items = list
			};

			return result;
		}

		public async Task<PaginationResult<List<MedicalEventPhucTm>>> GetAllAsync(int currentPage, int pageSize)
		{
			var list = await this.GetAllMedicalEvents();

			var totalItems = list.Count;
			var totalPages = (int)Math.Ceiling((double)totalItems/pageSize);

			list = list.Skip(pageSize * (currentPage - 1)).Take(pageSize).ToList();
			var result = new PaginationResult<List<MedicalEventPhucTm>>
			{
				TotalItems = totalItems,
				TotalPages = totalPages,
				CurrentPage = currentPage,
				PageSize = pageSize,
				Items = list
			};

			return result;
		}

	}
}
