using BusTracking.Core.Data;
using BusTracking.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class EmployeeStatusController : ControllerBase
	{
		private readonly IEmployeeStatusService _employeeStatusService;
		public EmployeeStatusController(IEmployeeStatusService employeeStatusService)
		{
			_employeeStatusService = employeeStatusService;
		}
		[HttpGet("GetAllEmployeeStatuses")]
		public IEnumerable<Employeestatus?>GetAllEmployeeStatuses()
		{
			return _employeeStatusService.GetAllEmployeeStatuses();
		}
		[HttpGet("GetEmployeeStatusById/{id}")]
		public Employeestatus? GetEmployeeStatus(int id)
		{
			return _employeeStatusService.GetEmployeeStatusById(id);
		}
		[HttpPost("CreateEmployeeStatus")]
		public void CreateEmployeeStatus(Employeestatus employeeStatus)
		{
			_employeeStatusService.CreateEmployeeStatus(employeeStatus);
		}
	}
}
