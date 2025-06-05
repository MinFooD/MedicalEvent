using SMMS.Repositories.PhucTM;
using SMMS.Repositories.PhucTM.ModelExtensions;
using SMMS.Repositories.PhucTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.Services.PhucTM
{
	/*
	public interface IMedicalEventPhucTmService
	{
		Task<List<MedicalEventPhucTm>> GetAllMedicalEvents();
		Task<MedicalEventPhucTm> GetByIdAsync(int code);
		Task<List<MedicalEventPhucTm>> SearchAsync(string des1, decimal heartRate, string des2);
	}
	*/

	public class MedicalEventPhucTmService : IMedicalEventPhucTmService
	{
		private readonly MedicalEventPhucTmRepository _medicalEventPhucTmRepository;

		public MedicalEventPhucTmService() => _medicalEventPhucTmRepository ??= new MedicalEventPhucTmRepository();

		public Task<int> CreateAsync(MedicalEventPhucTm medicalEvent)
		{
			return _medicalEventPhucTmRepository.CreateAsync(medicalEvent);
		}

		public async Task<bool> DeleteAsync(int id)
		{
			var existingEvent = await _medicalEventPhucTmRepository.GetByIdAsync(id);
			return await _medicalEventPhucTmRepository.RemoveAsync(existingEvent);
		}

		public async Task<List<MedicalEventPhucTm>> GetAllMedicalEvents()
		{
			var list = await _medicalEventPhucTmRepository.GetAllMedicalEvents();
			return list ?? new List<MedicalEventPhucTm>();
		}

		public async Task<PaginationResult<List<MedicalEventPhucTm>>> GetAllAsync(int currentPage, int pageSize)
		{
			var list = await _medicalEventPhucTmRepository.GetAllAsync(currentPage, pageSize);
			return list ?? new PaginationResult<List<MedicalEventPhucTm>>();
		}

		public async Task<MedicalEventPhucTm> GetByIdAsync(int id)
		{
			var item = await _medicalEventPhucTmRepository.GetByIdAsync(id);
			return item ?? new MedicalEventPhucTm();
		}

		public async Task<List<MedicalEventPhucTm>> SearchAsync(string des1, decimal heartRate, string des2)
		{
			var list = await _medicalEventPhucTmRepository.SearchAsync(des1, heartRate, des2);
			return list ?? new List<MedicalEventPhucTm>();
		}

		public async Task<PaginationResult<List<MedicalEventPhucTm>>> SearchWithPagingAsync(string des1, decimal heartRate, string des2, int currentPage, int pageSize)
		{
			var list = await _medicalEventPhucTmRepository.SearchWithPagingAsync(des1, heartRate, des2, currentPage, pageSize);
			return list ?? new PaginationResult<List<MedicalEventPhucTm>>();
		}

		public async Task<PaginationResult<List<MedicalEventPhucTm>>> SearchWithPagingAsync(SearchMedicalEventRequest searchRequest)
		{
			var list = await _medicalEventPhucTmRepository.SearchWithPagingAsync(searchRequest);
			return list ?? new PaginationResult<List<MedicalEventPhucTm>>();
		}

		public async Task<int> UpdateAsync(MedicalEventPhucTm medicalEvent)
		{
			return await _medicalEventPhucTmRepository.UpdateAsync(medicalEvent);
		}
	}
}
