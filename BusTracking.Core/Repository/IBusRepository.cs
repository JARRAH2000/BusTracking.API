using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Data;
namespace BusTracking.Core.Repository
{
	public interface IBusRepository
	{
        IEnumerable<Bus?>GetAllBuses();
        IEnumerable<Bus?> GetAvailableBuses();
        IEnumerable<Bus?> GetBusyBuses();
        IEnumerable<Bus?> GetExpiredLicenseBuses();
        IEnumerable<Bus?> GetBusesOrderedByCapacity();
        IEnumerable<Bus?> GetBusByModel(string model);
        IEnumerable<Bus?> GetBusByBrand(string brand);
        IEnumerable<Bus?> GetBusByVRP(string vrp);
        IEnumerable<Bus?> GetBusByCapacityThreshold(int capacity);
        Bus? GetBusById(int id);
        int CreateBus(Bus bus);
        void UpdateBus(Bus bus);
        void DeleteBus(int id);
	}
}
