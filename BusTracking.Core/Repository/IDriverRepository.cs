using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.Repository
{
	public interface IDriverRepository
	{
		Task<IEnumerable<Driver?>> GetAllDrivers();
		Task<IEnumerable<Driver?>> GetBusyDrivers();
		Task<IEnumerable<Driver?>> GetAvailableDrivers();
		Task<IEnumerable<Driver?>> GetExpiredLicenseDrivers();
		Task<Driver?> GetDriverById(int id);
		Task<Driver?> GetDriverWithTripsById(int id);
		int CreateDriver(Driver driver);
		void UpdateDriver(Driver driver);
		void DeleteDriver(int id);
	}
}
