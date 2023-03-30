using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusTracking.Core.Service;
using BusTracking.Core.Data;

namespace BusTracking.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TripStudentController : ControllerBase
	{
		private readonly ITripStudentService _tripStudentService;
		public TripStudentController(ITripStudentService tripStudentService)
		{
			_tripStudentService = tripStudentService;
		}
		[HttpGet("GetAllTripStudents")]
		public IEnumerable<Tripstudent?> GetAllTripStudents()
		{
			return _tripStudentService.GetAllTripStudents();
		}
		[HttpGet("GetTripStudentsByTripId/{tripId}")]
		public async Task<IEnumerable<Tripstudent?>> GetTripStudentsByTripId(int tripId)
		{
			return await _tripStudentService.GetTripStudentsByTripId(tripId);
		}
		[HttpGet("GetTripStudentById/{id}")]
		public Tripstudent? GetTripStudentById(int id)
		{
			return _tripStudentService.GetTripStudentById(id);
		}
		[HttpPost("CreateTripStudent")]
		public async Task CreateTripStudent(Tripstudent tripstudent)
		{
			await _tripStudentService.CreateTripStudent(tripstudent);
		}
		[HttpPut("UpdateTripStudent")]
		public void UpdateTripStudent(Tripstudent tripstudent)
		{
			_tripStudentService.UpdateTripStudent(tripstudent);
		}
		[HttpDelete("DeleteTripStudent/{id}")]
		public void DeleteTripStudent(int id)
		{
			_tripStudentService.DeleteTripStudent(id);
		}
	}
}