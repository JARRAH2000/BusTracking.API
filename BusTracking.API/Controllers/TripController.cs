using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusTracking.Core.Service;
using BusTracking.Core.Data;

namespace BusTracking.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TripController : ControllerBase
	{
		private readonly ITripService _tripService;
		public TripController(ITripService tripService)
		{
			_tripService = tripService;
		}
		[HttpGet("GetAllTrips")]
		public IEnumerable<Trip?> GetAllTrips()
		{
			return _tripService.GetAllTrips();
		}
		[HttpGet("GetTripById/{id}")]
		public Trip? GetTripById(int id)
		{
			return _tripService.GetTripById(id);
		}
		[HttpPost("CreateTrip")]
		public int CreateTrip(Trip trip)
		{
			return _tripService.CreateTrip(trip);
		}
		[HttpPut("UpdateTrip")]
		public void UpdateTrip(Trip trip)
		{
			_tripService.UpdateTrip(trip);
		}
		[HttpDelete("DeleteTrip/{id}")]
		public void DeleteTrip(int id)
		{
			_tripService.DeleteTrip(id);
		}
	}
}
