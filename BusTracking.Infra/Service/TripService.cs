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
	public class TripService:ITripService
	{
		private readonly ITripRepository _tripRepository;
		public TripService(ITripRepository tripRepository)
		{
			_tripRepository = tripRepository;
		}
		public IEnumerable<Trip?> GetAllTrips()
		{
			return _tripRepository.GetAllTrips();
		}
		public Trip? GetTripById(int id)
		{
			return _tripRepository.GetTripById(id);
		}
		public int CreateTrip(Trip trip)
		{
			return _tripRepository.CreateTrip(trip);
		}
		public void UpdateTrip(Trip trip)
		{
			_tripRepository.UpdateTrip(trip);
		}
		public void DeleteTrip(int id)
		{
			_tripRepository.DeleteTrip(id);
		}
	}
}
