using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusTracking.Core.Service;
using BusTracking.Core.Data;

namespace BusTracking.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TripDirectionController : ControllerBase
	{
		private readonly ITripDirectionService _tripDirectionService;
		public TripDirectionController(ITripDirectionService tripDirectionService)
		{
			_tripDirectionService = tripDirectionService;
		}
		[HttpGet("GetAllTripDirections")]
		public IEnumerable<Tripdirection?> GetAllTripDirections()
		{
			return _tripDirectionService.GetAllTripDirections();
		}
		[HttpGet("GetTripDirectionById/{id}")]
		public Tripdirection? GetTripDirectionById(int id)
		{
			return _tripDirectionService.GetTripDirectionById(id);
		}
		[HttpPost("CreateTripDirection")]
		public void CreateTripDirection(Tripdirection tripdirection)
		{
			_tripDirectionService.CreateTripDirection(tripdirection);
		}
		[HttpPut("UpdateTripDirection")]
		public void UpdateTripDirection(Tripdirection tripdirection)
		{
			_tripDirectionService.UpdateTripDirection(tripdirection);
		}
		[HttpDelete("DeleteTripDirection/{id}")]
		public void DeleteTripDirection(int id)
		{
			_tripDirectionService.DeleteTripDirection(id);
		}
	}
}
