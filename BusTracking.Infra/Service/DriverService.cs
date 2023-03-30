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
		public async Task<IEnumerable<Driver?>> GetAllDrivers()
		{
			return await _driverRepository.GetAllDrivers();
		}
		public async Task<IEnumerable<Driver?>> GetBusyDrivers()
		{
			return await _driverRepository.GetBusyDrivers();
		}
		public async Task<IEnumerable<Driver?>> GetAvailableDrivers()
		{
			return  await _driverRepository.GetAvailableDrivers();
		}
		public async Task<IEnumerable<Driver?>> GetExpiredLicenseDrivers()
		{
			return await _driverRepository.GetExpiredLicenseDrivers();
		}
		public async Task<Driver?> GetDriverById(int id)
		{
			return await _driverRepository.GetDriverById(id);
		}
		public async Task<Driver?> GetDriverWithTripsById(int id)
		{
			return await _driverRepository.GetDriverWithTripsById(id);
		}

		public async Task<Driver?> GetDriverByUserId(int userId)
		{
			return await _driverRepository.GetDriverByUserId(userId);
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
