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
using System.Security.Cryptography;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace BusTracking.Infra.Service
{
	public class LoginService:ILoginService
	{
		private readonly ILoginRepository _loginRepository;
		public LoginService(ILoginRepository loginRepository)
		{
			_loginRepository = loginRepository;
		}
		public string? VerifyinLogin(Login login)
		{
			JWTPayload? userPayload = _loginRepository.VerifyinLogin(login);
			if (userPayload == null) return null;
			SymmetricSecurityKey symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("BusTrackingSystemByTahalufTrainees_Basheer_Alaa_AhmadQuran_And_AhmadObiedat"));
			SigningCredentials credentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
			List<Claim> userClaims = new()
			{
				new Claim(ClaimTypes.Role,userPayload.UserRole.ToString()),
				new Claim(ClaimTypes.Name,userPayload.UserName.ToString()),
				new Claim(ClaimTypes.Email,userPayload.UserEmail.ToString()),
				new Claim(ClaimTypes.NameIdentifier,userPayload.UserId.ToString())
			};
			JwtSecurityToken jwtSecurityToken = new JwtSecurityToken
			(
				claims: userClaims,
				expires: DateTime.Now.AddMinutes(60),
				signingCredentials: credentials
			);
			return new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken);
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
