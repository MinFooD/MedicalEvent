using SMMS.Repositories.PhucTM;
using SMMS.Repositories.PhucTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.Services.PhucTM
{
	public class EventTypePhucTmService
	{
		private readonly EventTypePhucTmRepository _eventTypePhucTmRepository;
		public EventTypePhucTmService() => _eventTypePhucTmRepository ??= new EventTypePhucTmRepository();

		public async Task<List<EventTypePhucTm>> GetAllAsync()
		{
			var list = await _eventTypePhucTmRepository.GetAllEventTypesAsync();
			return list ?? new List<EventTypePhucTm>();
		}

		public async Task<int> CreateAsync(EventTypePhucTm eventTypePhucTm)
		{
			var result = await _eventTypePhucTmRepository.CreateEventTypeAsync(eventTypePhucTm);
			return result;
		}
	}
}
