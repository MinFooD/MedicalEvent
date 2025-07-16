using Microsoft.AspNetCore.Mvc;
using SMMS.Repositories.PhucTM;
using SMMS.Repositories.PhucTM.Models;
using SMMS.Services.PhucTM;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SMMS.APIServices.BE.PhucTM.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EventTypePhucTmsController : ControllerBase
	{
		private readonly EventTypePhucTmService _eventTypePhucTmService;

		public EventTypePhucTmsController(EventTypePhucTmService eventTypePhucTmService)
		{
			_eventTypePhucTmService = eventTypePhucTmService;
		}

		// GET: api/<EventTypePhucTmsController>
		[HttpGet]
		public async Task<IEnumerable<EventTypePhucTm>> Get()
		{
			return await _eventTypePhucTmService.GetAllAsync();
		}

		// POST api/<EventTypePhucTmsController>
		[HttpPost]
		public async Task<int> Post(EventTypePhucTm eventTypePhucTm)
		{
			var result = await _eventTypePhucTmService.CreateAsync(eventTypePhucTm);
			return result;
		}

		// GET api/<EventTypePhucTmsController>/5
		[HttpGet("{id}")]
		public async Task<EventTypePhucTm> Get(int id)
		{
			return await _eventTypePhucTmService.GetByIdAsync(id);
		}

		// PUT api/<EventTypePhucTmsController>/5
		[HttpPut]
		public async Task<int> Put(EventTypePhucTm eventTypePhucTm)
		{
			return await _eventTypePhucTmService.UpdateAsync(eventTypePhucTm);
		}

		// DELETE api/<EventTypePhucTmsController>/5
		[HttpDelete("{id}")]
		public async Task<bool> Delete(int id)
		{
			return await _eventTypePhucTmService.DeleteAsync(id);
		}
	}
}
