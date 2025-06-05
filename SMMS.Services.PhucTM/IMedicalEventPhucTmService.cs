using SMMS.Repositories.PhucTM.ModelExtensions;
using SMMS.Repositories.PhucTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.Services.PhucTM
{
	public interface IMedicalEventPhucTmService
	{
		Task<List<MedicalEventPhucTm>> GetAllMedicalEvents();
		Task<MedicalEventPhucTm> GetByIdAsync(int id);
		Task<List<MedicalEventPhucTm>> SearchAsync(string des1, decimal heartRate, string des2);
		Task<PaginationResult<List<MedicalEventPhucTm>>> SearchWithPagingAsync(string des1, decimal heartRate, string des2, int currentPage, int pageSize);

		Task<PaginationResult<List<MedicalEventPhucTm>>> SearchWithPagingAsync(SearchMedicalEventRequest searchRequest);
		Task<PaginationResult<List<MedicalEventPhucTm>>> GetAllAsync(int currentPage, int pageSize);
		Task<int> CreateAsync(MedicalEventPhucTm medicalEvent);
		Task<int> UpdateAsync(MedicalEventPhucTm medicalEvent);
		Task<bool> DeleteAsync(int id);
	}
}
