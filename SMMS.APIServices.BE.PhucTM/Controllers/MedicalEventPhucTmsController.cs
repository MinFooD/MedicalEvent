using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.OData.Query;
using SMMS.Repositories.PhucTM.ModelExtensions;
using SMMS.Repositories.PhucTM.Models;
using SMMS.Services.PhucTM;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMMS.APIServices.BE.PhucTM.Controllers
{
	[Authorize]
	[Route("api/[controller]")]
	[ApiController]
	public class MedicalEventPhucTmsController : ControllerBase
	{
		private readonly IMedicalEventPhucTmService _medicalEventPhucTmService;

		public MedicalEventPhucTmsController(IMedicalEventPhucTmService medicalEventPhucTmService)
		{
			_medicalEventPhucTmService = medicalEventPhucTmService;
		}

		// GET: api/<MedicalEventPhucTmsController>
		[HttpGet]
		[Authorize(Roles ="1,2")]
		[EnableQuery]
		public async Task<List<MedicalEventPhucTm>> Get()
		{
			return await _medicalEventPhucTmService.GetAllMedicalEvents();
		}

		// GET api/<MedicalEventPhucTmsController>/5
		[HttpGet("{id}")]
		[Authorize(Roles = "1,2")]
		public async Task<MedicalEventPhucTm> Get(int id)
		{
			return await _medicalEventPhucTmService.GetByIdAsync(id);
		}

		// POST api/<MedicalEventPhucTmsController>
		[HttpPost]
		[Authorize(Roles = "1,2")]
		public async Task<int> Post(MedicalEventPhucTm medicalEventPhucTm)
		{
			return await _medicalEventPhucTmService.CreateAsync(medicalEventPhucTm);
		}

		// PUT api/<MedicalEventPhucTmsController>/5
		[HttpPut()]
		[Authorize(Roles = "1,2")]
		public async Task<int> Put(MedicalEventPhucTm medicalEventPhucTm)
		{
			if (ModelState.IsValid)
			{
				return await _medicalEventPhucTmService.UpdateAsync(medicalEventPhucTm);
			}
			return 0;
			
		}

		// DELETE api/<MedicalEventPhucTmsController>/5
		[HttpDelete("{id}")]
		[Authorize(Roles = "1")]
		public async Task<bool> Delete(int id)
		{
			return await _medicalEventPhucTmService.DeleteAsync(id);
		}

		[HttpGet("{des1}/{heartRate}/{des2}")]
		[Authorize(Roles = "1,2")]
		public async Task<List<MedicalEventPhucTm>> Get(string des1, decimal heartRate, string des2)
		{
			return await _medicalEventPhucTmService.SearchAsync(des1, heartRate, des2);
		}
		[HttpGet("{currentPage}/{pageSize}")]
		[Authorize(Roles = "1,2")]
		public async Task<PaginationResult<List<MedicalEventPhucTm>>> Get(int currentPage, int pageSize)
		{
			return await _medicalEventPhucTmService.GetAllAsync(currentPage, pageSize);
		}

		//https://localhost:7071/api/MedicalEventPhucTms?des1=u&heartRate=90&des2=u&currentPage=1&pageSize=2
		[HttpGet("{des1}/{heartRate}/{des2}/{currentPage}/{pageSize}")]
		[Authorize(Roles = "1,2")]
		public async Task<PaginationResult<List<MedicalEventPhucTm>>> Get(string des1, decimal heartRate, string des2,
			int currentPage, int pageSize)
		{
			return await _medicalEventPhucTmService.SearchWithPagingAsync(des1, heartRate, des2, currentPage, pageSize);
		}

		[HttpPost("Search")]
		[Authorize(Roles = "1,2")]
		public async Task<PaginationResult<List<MedicalEventPhucTm>>> Get(SearchMedicalEventRequest searchRequest)
		{
			return await _medicalEventPhucTmService.SearchWithPagingAsync(searchRequest);
		}

		[HttpGet("Get-Odata")]
		[Authorize(Roles = "1,2")]
		[EnableQuery]
		public async Task<List<MedicalEventPhucTm>> Odata()
		{
			return await _medicalEventPhucTmService.GetAllMedicalEvents();
		}
	}
}
