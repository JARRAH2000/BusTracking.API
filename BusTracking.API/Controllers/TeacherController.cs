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
		public IEnumerable<Teacher?> GetAllTeachers()
		{
			return _teacherService.GetAllTeachers();
		}
		[HttpGet("GetBusyTeachers")]
		public IEnumerable<Teacher?> GetBusyTeachers()
		{
			return _teacherService.GetBusyTeachers();
		}
		[HttpGet("GetAvailableTeachers")]
		public IEnumerable<Teacher?> GetAvailableTeachers()
		{
			return _teacherService.GetAvailableTeachers();
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
	}
}
