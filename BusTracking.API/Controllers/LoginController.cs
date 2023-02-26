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
		public IActionResult VerifyingLogin(Login login)
		{
			string? token = _loginService.VerifyinLogin(login);
			return token == null ? Unauthorized() : Ok(token);
		}
		[HttpPost("CreateLogin")]
		public async Task CreateLogin(Login login)
		{
			await _loginService.CreateLogin(login);
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
