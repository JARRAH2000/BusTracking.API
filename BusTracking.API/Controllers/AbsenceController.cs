using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusTracking.Core.Service;
using BusTracking.Core.Data;

namespace BusTracking.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class AbsenceController : ControllerBase
	{
		private readonly IAbsenceService _absenceService;
		public AbsenceController(IAbsenceService absenceService)
		{
			_absenceService = absenceService;
		}
		[HttpGet("GetAllAbsences")]
		public IEnumerable<Absence?> GetAllAbsences()
		{
			return _absenceService.GetAllAbsences();
		}
		[HttpGet("GetAbsenceById/{id}")]
		public Absence? GetAbsenceById(int id)
		{
			return _absenceService.GetAbsenceById(id);
		}
		[HttpPost("CreateAbsence")]
		public int CreateAbsence(Absence absence)
		{
			return _absenceService.CreateAbsence(absence);
		}
		[HttpPut("UpdateAbsence")]
		public void UpdateAbsence(Absence absence)
		{
			_absenceService.UpdateAbsence(absence);
		}
		[HttpDelete("DeleteAbsence/{id}")]
		public void DeleteAbsence(int id)
		{
			_absenceService.DeleteAbsence(id);
		}
	}
}
