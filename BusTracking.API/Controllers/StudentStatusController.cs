using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusTracking.Core.Service;
using BusTracking.Core.Data;

namespace BusTracking.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class StudentStatusController : ControllerBase
	{
		private readonly IStudentStatusService _studentStatusService;
		public StudentStatusController(IStudentStatusService studentStatusService)
		{
			_studentStatusService = studentStatusService;
		}
		[HttpGet("GetAllStudentStatuses")]
		public IEnumerable<Studentstatus?>GetAllStudentStatuses()
		{
			return _studentStatusService.GetAllStudentStatuses();
		}
		[HttpGet("GetStudentStatusById/{id}")]
		public Studentstatus?GetStudentstatusById(int id)
		{
			return _studentStatusService.GetStudentStatusById(id);
		}
		[HttpPost("CreateStudentStatus")]
		public void CreateStudentStatus(Studentstatus studentstatus)
		{
			_studentStatusService.CreateStudentStatus(studentstatus);
		}
	}
}
