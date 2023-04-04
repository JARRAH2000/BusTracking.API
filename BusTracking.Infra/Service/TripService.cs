using BusTracking.Core.Data;
using BusTracking.Core.DTO;
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
		public async Task<int> CreateTrip(Trip trip)
		{
			return await _tripRepository.CreateTrip(trip);
		}
		public void UpdateTrip(Trip trip)
		{
			_tripRepository.UpdateTrip(trip);
		}
		public void DeleteTrip(int id)
		{
			_tripRepository.DeleteTrip(id);
		}
		public TripDetails? GetTripDetails(int id)
		{
			return _tripRepository.GetTripDetails(id);
		}

		public IEnumerable<TripDetails?> GetTripsByDate(DateTime date)
		{
			return _tripRepository.GetTripsByDate(date);
		}

		public IEnumerable<TripDetails?> GetTripsByDateInterval(DateInterval dateInterval)
		{
			return _tripRepository.GetTripsByDateInterval(dateInterval);
		}
		public Task<Trip?> GetTripStudentsById(int id)
		{
			return _tripRepository.GetTripStudentsById(id);
		}
		public async Task EndTrip(Trip trip)
		{
			await _tripRepository.EndTrip(trip);
		}

		public async Task<IEnumerable<MonthlyTrips>> CountOfTripsEachMonth()
		{
			return await _tripRepository.CountOfTripsEachMonth();
		}

	}
}
