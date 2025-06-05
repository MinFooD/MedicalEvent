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
	public class SystemUserAccountRepository : GenericRepository<SystemUserAccount>
	{
		public SystemUserAccountRepository() => _context ??= new DBContext.SU25_PRN232_SE1725_G2_SchoolMedicalManagementSystemContext();
		public SystemUserAccountRepository(DBContext.SU25_PRN232_SE1725_G2_SchoolMedicalManagementSystemContext context) => _context = context;

		public async Task<SystemUserAccount> GetUserAccount(string userName, string password)
		{
			return await _context.SystemUserAccounts
				.FirstOrDefaultAsync(x => x.UserName == userName && x.Password == password);
		}
	}
}
