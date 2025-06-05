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

		//// GET api/<EventTypePhucTmsController>/5
		//[HttpGet("{id}")]
		//public string Get(int id)
		//{
		//	return "value";
		//}

		//// POST api/<EventTypePhucTmsController>
		//[HttpPost]
		//public void Post([FromBody] string value)
		//{
		//}

		//// PUT api/<EventTypePhucTmsController>/5
		//[HttpPut("{id}")]
		//public void Put(int id, [FromBody] string value)
		//{
		//}

		//// DELETE api/<EventTypePhucTmsController>/5
		//[HttpDelete("{id}")]
		//public void Delete(int id)
		//{
		//}
	}
}
