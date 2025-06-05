using Microsoft.EntityFrameworkCore;
using SMMS.Repositories.PhucTM.Basic;
using SMMS.Repositories.PhucTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.Repositories.PhucTM
{
	public class EventTypePhucTmRepository : GenericRepository<EventTypePhucTm>
	{
		public EventTypePhucTmRepository() => _context ??= new DBContext.SU25_PRN232_SE1725_G2_SchoolMedicalManagementSystemContext();

		public EventTypePhucTmRepository(DBContext.SU25_PRN232_SE1725_G2_SchoolMedicalManagementSystemContext context) => _context = context;

		public async Task<List<EventTypePhucTm>> GetAllEventTypesAsync()
		{
			var list = await _context.EventTypePhucTms.ToListAsync();
			return list ?? new List<EventTypePhucTm>();
		}
	}
}
