using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Service;
using BusTracking.Core.Repository;
using BusTracking.Core.Data;
using BusTracking.Core.DTO;

namespace BusTracking.Infra.Service
{
	public class LoginService:ILoginService
	{
		private readonly ILoginRepository _loginRepository;
		public LoginService(ILoginRepository loginRepository)
		{
			_loginRepository = loginRepository;
		}
		public Login? VerifyinLogin(Login login)
		{
			//must create JWT here,may be the return type must be string also to return token
			return _loginRepository.VerifyinLogin(login);
		}
		public async Task CreateLogin(Login login)
		{
			await _loginRepository.CreateLogin(login);
		}
		public void UpdateLogin(UpdateLoginData loginData)
		{
			_loginRepository.UpdateLogin(loginData);
		}
		public void DeleteLogin(int userId)
		{
			_loginRepository.DeleteLogin(userId);
		}
	}
}
