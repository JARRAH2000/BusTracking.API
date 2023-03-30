using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusTracking.Core.Service;
using BusTracking.Core.Data;
using BusTracking.Core.DTO;

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
		public async Task<int> CreateTrip(Trip trip)
		{
			return await _tripService.CreateTrip(trip);
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
		[HttpGet("GetTripDetails/{id}")]
		public TripDetails? GetTripDetails(int id)
		{
			return _tripService.GetTripDetails(id);
		}
		[HttpGet("GetTripsByDate/{date}")]
		public IEnumerable<TripDetails?> GetTripsByDate(DateTime date)
		{
			return _tripService.GetTripsByDate(date);
		}
		[HttpPost("GetTripsByDateInterval")]
		public IEnumerable<TripDetails?> GetTripsByDateInterval(DateInterval dateInterval)
		{
			return _tripService.GetTripsByDateInterval(dateInterval);
		}
		[HttpGet("GetTripStudentsById/{id}")]
		public Task<Trip?> GetTripStudentsById(int id)
		{
			return _tripService.GetTripStudentsById(id);
		}

		[HttpPut("EndTrip")]
		public async Task EndTrip(Trip trip)
		{
			await _tripService.EndTrip(trip);
		}
	}
}
