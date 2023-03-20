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
		public async Task<IEnumerable<Driver?>> GetAllDrivers()
		{
			return await _driverService.GetAllDrivers();
		}
		[HttpGet("GetBusyDrivers")]
		public async Task<IEnumerable<Driver?>> GetBusyDrivers()
		{
			return await _driverService.GetBusyDrivers();
		}
		[HttpGet("GetAvailableDrivers")]
		public async Task<IEnumerable<Driver?>> GetAvailableDrivers()
		{
			return await _driverService.GetAvailableDrivers();
		}
		[HttpGet("GetExpiredLicenseDrivers")]
		public async Task<IEnumerable<Driver?>> GetExpiredLicenseDrivers()
		{
			return await _driverService.GetExpiredLicenseDrivers();
		}
		[HttpGet("GetDriverById/{id}")]
		public async Task<Driver?> GetDriverById(int id)
		{
			return await _driverService.GetDriverById(id);
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
