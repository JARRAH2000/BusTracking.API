using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusTracking.Core.Service;
using BusTracking.Core.Data;

namespace BusTracking.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class BusController : ControllerBase
	{
		private readonly IBusService _busService;
		public BusController(IBusService busService)
		{
			_busService = busService;
		}
		[HttpGet("GetAllBuses")]
		public IEnumerable<Bus?> GetAllBuses()
		{
			return _busService.GetAllBuses();
		}
		[HttpGet("GetAvailableBuses")]
		public IEnumerable<Bus?> GetAvailableBuses()
		{
			return _busService.GetAvailableBuses();
		}
		[HttpGet("GetBusyBuses")]
		public IEnumerable<Bus?> GetBusyBuses()
		{
			return _busService.GetBusyBuses();
		}
		[HttpGet("GetExpiredLicenseBuses")]
		public IEnumerable<Bus?> GetExpiredLicenseBuses()
		{
			return _busService.GetExpiredLicenseBuses();
		}
		[HttpGet("GetBusesOrderedByCapacity")]
		public IEnumerable<Bus?> GetBusesOrderedByCapacity()
		{
			return _busService.GetBusesOrderedByCapacity();
		}
		[HttpGet("GetBusByModel/{model}")]
		public IEnumerable<Bus?> GetBusByModel(string model)
		{
			return _busService.GetBusByModel(model);
		}
		[HttpGet("GetBusByBrand/{brand}")]
		public IEnumerable<Bus?> GetBusByBrand(string brand)
		{
			return _busService.GetBusByBrand(brand);
		}
		[HttpGet("GetBusByVRP/{vrp}")]
		public IEnumerable<Bus?> GetBusByVRP(string vrp)
		{
			return _busService.GetBusByVRP(vrp);
		}
		[HttpGet("GetBusByCapacityThreshold/{capacity}")]
		public IEnumerable<Bus?> GetBusByCapacityThreshold(int capacity)
		{
			return _busService.GetBusByCapacityThreshold(capacity);
		}
		[HttpGet("GetBusById/{id}")]
		public Bus? GetBusById(int id)
		{
			return _busService.GetBusById(id);
		}
		[HttpPost("CreateBus")]
		public int CreateBus(Bus bus)
		{
			return _busService.CreateBus(bus);
		}
		[HttpPut("UpdateBus")]
		public void UpdateBus(Bus bus)
		{
			_busService.UpdateBus(bus);
		}
		[HttpDelete("DeleteBus/{id}")]
		public void DeleteBus(int id)
		{
			_busService.DeleteBus(id);
		}
	}
}
