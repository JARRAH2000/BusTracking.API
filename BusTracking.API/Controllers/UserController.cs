using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using BusTracking.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;

namespace BusTracking.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UserController : ControllerBase
	{
		private readonly IUserService _userService;
		//public const DateTime TodayDate = new DateTime(DateTime.Now.Date);
		public UserController(IUserService userService)
		{
			_userService = userService;
			//TodayDate = DateTime.Now.Date;
		}
		[HttpGet("GetUserById/{id}")]
		public User? GetUserById(int id)
		{
			return _userService.GetUserById(id);
		}
		[HttpGet("GetAllUsers")]
		public IEnumerable<User?> GetAllUsers()
		{
			return _userService.GetAllUsers();
		}
		[HttpGet("GetUserByRole/{roleId}")]
		public IEnumerable<User?> GetUserByRole(int roleId)
		{
			return _userService.GetUserByRole(roleId);
		}
		[HttpGet("GetUserByFirstName/{firstName}")]
		public IEnumerable<User?> GetUserByFirstName(string firstName)
		{
			return _userService.GetUserByFirstName(firstName);
		}
		[HttpGet("GetUserByMiddleName/{middleName}")]
		public IEnumerable<User?> GetUserByMiddleName(string middleName)
		{
			return _userService.GetUserByMiddleName(middleName);
		}
		[HttpGet("GetUserByLastName/{lastName}")]
		public IEnumerable<User?> GetUserByLastName(string lastName)
		{
			return _userService.GetUserByLastName(lastName);
		}
		[HttpGet("GetUserBySex/{gender}")]
		public IEnumerable<User?> GetUserBySex(char gender)
		{
			return _userService.GetUserBySex(gender);
		}
		[HttpGet("GetUserByBirthDate/{birthDate}")]
		[HttpGet("GetUserByBirthDate")]//for null value,the method will return users who are borned today
		public IEnumerable<User?> GetUserByBirthDate(DateTime? birthDate = null)
		{
			return _userService.GetUserByBirthDate(birthDate);
		}
		[HttpPost("GetUserByBirthDateInterval")]
		public IEnumerable<User?> GetUserByBirthDateInterval(DateInterval birthDateInterval)
		{
			return _userService.GetUserByBirthDateInterval(birthDateInterval);
		}
		[HttpPost("CreateUser")]
		public int CreateUser(User user)
		{
			return _userService.CreateUser(user);
		}
		[HttpPut("UpdateUser")]
		public void UpdateUser(User user)
		{
			_userService.UpdateUser(user);
		}
		[HttpDelete("DeleteUser/{id}")]
		public void DeleteUser(int id)
		{
			_userService.DeleteUser(id);
		}
		[HttpPost("UploadUserImage")]
		public User UploadUserImage()
		{
			IFormFile formFile = Request.Form.Files[0];
			string fileName = Guid.NewGuid().ToString() + "_" + formFile.FileName;
			string fullPath = Path.Combine("Images/Users", fileName);
			using(FileStream stream=new FileStream(fullPath,FileMode.Create))
			{
				formFile.CopyTo(stream);
			}
			return new User { Image = fileName };
		}
	}
}
