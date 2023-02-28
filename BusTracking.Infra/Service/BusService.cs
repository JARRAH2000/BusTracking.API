using BusTracking.Core.Data;
using BusTracking.Core.Repository;
using BusTracking.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Infra.Service
{
	public class BusService:IBusService
	{
		private readonly IBusRepository _busRepository;
		public BusService(IBusRepository busRepository)
		{
			_busRepository = busRepository;
		}
		public IEnumerable<Bus?> GetAllBuses()
		{
			return _busRepository.GetAllBuses();
		}
		public IEnumerable<Bus?> GetAvailableBuses()
		{
			return _busRepository.GetAvailableBuses();
		}
		public IEnumerable<Bus?> GetBusyBuses()
		{
			return _busRepository.GetBusyBuses();
		}
		public IEnumerable<Bus?> GetExpiredLicenseBuses()
		{
			return _busRepository.GetExpiredLicenseBuses();
		}
		public IEnumerable<Bus?> GetBusesOrderedByCapacity()
		{
			return _busRepository.GetBusesOrderedByCapacity();
		}
		public IEnumerable<Bus?> GetBusByModel(string model)
		{
			return _busRepository.GetBusByModel(model);
		}
		public IEnumerable<Bus?> GetBusByBrand(string brand)
		{
			return _busRepository.GetBusByBrand(brand);
		}
		public IEnumerable<Bus?> GetBusByVRP(string vrp)
		{
			return _busRepository.GetBusByVRP(vrp);
		}
		public IEnumerable<Bus?> GetBusByCapacityThreshold(int capacity)
		{
			return _busRepository.GetBusByCapacityThreshold(capacity);
		}
		public Bus? GetBusById(int id)
		{
			return _busRepository.GetBusById(id);
		}
		public async Task<Bus?> GetBusWithTripsById(int id)
		{
			return await _busRepository.GetBusWithTripsById(id);
		}
		public int CreateBus(Bus bus)
		{
			return _busRepository.CreateBus(bus);
		}
		public void UpdateBus(Bus bus)
		{
			_busRepository.UpdateBus(bus);
		}
		public void DeleteBus(int id)
		{
			_busRepository.DeleteBus(id);
		}
	}
}
