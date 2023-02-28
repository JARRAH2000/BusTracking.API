using BusTracking.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Service;
using BusTracking.Core.Data;

namespace BusTracking.Infra.Service
{
	public class DriverService:IDriverService
	{
		private readonly IDriverRepository _driverRepository;
		public DriverService(IDriverRepository driverRepository)
		{
			_driverRepository = driverRepository;
		}
		public IEnumerable<Driver?> GetAllDrivers()
		{
			return _driverRepository.GetAllDrivers();
		}
		public IEnumerable<Driver?> GetBusyDrivers()
		{
			return _driverRepository.GetBusyDrivers();
		}
		public IEnumerable<Driver?> GetAvailableDrivers()
		{
			return _driverRepository.GetAvailableDrivers();
		}
		public IEnumerable<Driver?> GetExpiredLicenseDrivers()
		{
			return _driverRepository.GetExpiredLicenseDrivers();
		}
		public Driver? GetDriverById(int id)
		{
			return _driverRepository.GetDriverById(id);
		}
		public async Task<Driver?> GetDriverWithTripsById(int id)
		{
			return await _driverRepository.GetDriverWithTripsById(id);
		}
		public int CreateDriver(Driver driver)
		{
			return _driverRepository.CreateDriver(driver);
		}
		public void UpdateDriver(Driver driver)
		{
			_driverRepository.UpdateDriver(driver);
		}
		public void DeleteDriver(int id)
		{
			_driverRepository.DeleteDriver(id);
		}
	}
}
