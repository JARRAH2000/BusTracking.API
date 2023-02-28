using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusTracking.Core.Service;
using BusTracking.Core.Data;

namespace BusTracking.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class DriverController : ControllerBase
	{
		private readonly IDriverService _driverService;
		public DriverController(IDriverService driverService)
		{
			_driverService = driverService;
		}
		[HttpGet("GetAllDrivers")]
		public IEnumerable<Driver?> GetAllDrivers()
		{
			return _driverService.GetAllDrivers();
		}
		[HttpGet("GetBusyDrivers")]
		public IEnumerable<Driver?> GetBusyDrivers()
		{
			return _driverService.GetBusyDrivers();
		}
		[HttpGet("GetAvailableDrivers")]
		public IEnumerable<Driver?> GetAvailableDrivers()
		{
			return _driverService.GetAvailableDrivers();
		}
		[HttpGet("GetExpiredLicenseDrivers")]
		public IEnumerable<Driver?> GetExpiredLicenseDrivers()
		{
			return _driverService.GetExpiredLicenseDrivers();
		}
		[HttpGet("GetDriverById/{id}")]
		public Driver? GetDriverById(int id)
		{
			return _driverService.GetDriverById(id);
		}
		[HttpGet("GetDriverWithTripsById/{id}")]
		public async Task<Driver?> GetDriverWithTripsById(int id)
		{
			return await _driverService.GetDriverWithTripsById(id);
		}
		[HttpPost("CreateDriver")]
		public int CreateDriver(Driver driver)
		{
			return _driverService.CreateDriver(driver);
		}
		[HttpPut("UpdateDriver")]
		public void UpdateDriver(Driver driver)
		{
			_driverService.UpdateDriver(driver);
		}
		[HttpDelete("DeleteDriver/{id}")]
		public void DeleteDriver(int id)
		{
			_driverService.DeleteDriver(id);
		}
	}
}
