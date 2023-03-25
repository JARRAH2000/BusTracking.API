using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusTracking.Core.Service;
using BusTracking.Core.Data;
using BusTracking.Core.Repository;

namespace BusTracking.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TeacherController : ControllerBase
	{
		private readonly ITeacherService _teacherService;
		public TeacherController(ITeacherService teacherService)
		{
			_teacherService = teacherService;
		}
		[HttpGet("GetAllTeachers")]
		public async Task<IEnumerable<Teacher?>> GetAllTeachers()
		{
			return await _teacherService.GetAllTeachers();
		}
		[HttpGet("GetBusyTeachers")]
		public async Task<IEnumerable<Teacher?>> GetBusyTeachers()
		{
			return await _teacherService.GetBusyTeachers();
		}
		[HttpGet("GetAvailableTeachers")]
		public async Task<IEnumerable<Teacher?>> GetAvailableTeachers()
		{
			return await _teacherService.GetAvailableTeachers();
		}
		[HttpGet("GetTeacherWithTripsById/{id}")]
		public async Task<Teacher?> GetTeacherWithTripsById(int id)
		{
			return await _teacherService.GetTeacherWithTripsById(id);
		}
		[HttpGet("GetTeacherById/{id}")]
		public Teacher? GetTeacherById(int id)
		{
			return _teacherService.GetTeacherById(id);
		}
		[HttpGet("GetTeacherByUserId/{userId}")]
		public async Task<Teacher?> GetTeacherByUserId(int userId)
		{
			return await _teacherService.GetTeacherByUserId(userId);
		}
		[HttpPost("CreateTeacher")]
		public int CreateTeacher(Teacher teacher)
		{
			return _teacherService.CreateTeacher(teacher);
		}
		[HttpPut("UpdateTeacher")]
		public void UpdateTeacher(Teacher teacher)
		{
			_teacherService.UpdateTeacher(teacher);
		}
		[HttpDelete("DeleteTeacher/{id}")]
		public void DeleteTeacher(int id)
		{
			_teacherService.DeleteTeacher(id);
		}
		[HttpGet("GetTeacherByName/{tchName}")]
		public IEnumerable<Teacher?> GetTeacherByName(string tchName)
		{
			return _teacherService.GetTeacherByName(tchName);
		}
	}
}
