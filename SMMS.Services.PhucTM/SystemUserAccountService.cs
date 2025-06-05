using SMMS.Repositories.PhucTM;
using SMMS.Repositories.PhucTM.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SMMS.Services.PhucTM
{
	public class SystemUserAccountService
	{
		private readonly SystemUserAccountRepository _systemUserAccountRepository;
		public SystemUserAccountService() => _systemUserAccountRepository ??= new SystemUserAccountRepository();

		public async Task<SystemUserAccount> GetUserAccount(string username, string password)
		{
			return await _systemUserAccountRepository.GetUserAccount(username, password);
		}
	}
}
