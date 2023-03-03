using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusTracking.Core.Service;
using BusTracking.Core.Data;
using BusTracking.Core.DTO;
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
		public Task CreateAbsence(Absence absence)
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
		[HttpGet("GetAbsencesByDate/{date}")]
		public IEnumerable<Absence?> GetAbsencesByDate(DateTime date)
		{
			return _absenceService.GetAbsencesByDate(date);
		}
		[HttpPost("GetAbsencesByDateInterval")]
		public IEnumerable<Absence?> GetAbsencesByDateInterval(DateInterval dateInterval)
		{
			return _absenceService.GetAbsencesByDateInterval(dateInterval);
		}
	}
}
