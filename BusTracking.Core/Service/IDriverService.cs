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
		IEnumerable<Driver?> GetAllDrivers();
		IEnumerable<Driver?> GetBusyDrivers();
		IEnumerable<Driver?> GetAvailableDrivers();
		IEnumerable<Driver?> GetExpiredLicenseDrivers();
		Driver?GetDriverById(int id);
		int CreateDriver(Driver driver);
		void UpdateDriver(Driver driver);
		void DeleteDriver(int id);
	}
}
