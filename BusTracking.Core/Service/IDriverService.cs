using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Data;
namespace BusTracking.Core.Service
{
	public interface IDriverService
	{
		Task<IEnumerable<Driver?>> GetAllDrivers();
		Task<IEnumerable<Driver?>> GetBusyDrivers();
		Task<IEnumerable<Driver?>> GetAvailableDrivers();
		Task<IEnumerable<Driver?>> GetExpiredLicenseDrivers();
		Task<Driver?> GetDriverById(int id);
		Task<Driver?> GetDriverWithTripsById(int id);
		Task<Driver?> GetDriverByUserId(int userId);

		int CreateDriver(Driver driver);
		void UpdateDriver(Driver driver);
		void DeleteDriver(int id);
	}
}
