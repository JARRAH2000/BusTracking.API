using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusTracking.Core.Service;
using BusTracking.Core.Data;
using BusTracking.Core.DTO;

namespace BusTracking.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class LoginController : ControllerBase
	{
		private readonly ILoginService _loginService;
		public LoginController(ILoginService loginService)
		{
			_loginService = loginService;
		}
		[HttpPost("VerifyingLogin")]
		public Login? VerifyingLogin(Login login)
		{
			//here return type will be string after impelementing JWT
			return _loginService.VerifyinLogin(login);

			//Unauthorized();
		}
		[HttpPost("CreateLogin")]
		public void CreateLogin(Login login)
		{
			_loginService.CreateLogin(login);
		}
		[HttpPut("UpdateLogin")]
		public void UpdateLogin(UpdateLoginData loginDate)
		{
			_loginService.UpdateLogin(loginDate);
		}
		[HttpDelete("DeleteLogin/{id}")]
		public void DeleteLogin(int id)
		{
			_loginService.DeleteLogin(id);
		}
	}
}
