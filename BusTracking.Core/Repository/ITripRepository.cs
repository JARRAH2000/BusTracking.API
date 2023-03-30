using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Data;
using BusTracking.Core.DTO;
namespace BusTracking.Core.Repository
{
	public interface ITripRepository
	{
		IEnumerable<Trip?> GetAllTrips();
		Trip? GetTripById(int id);
		Task<int> CreateTrip(Trip trip);
		void UpdateTrip(Trip trip);
		void DeleteTrip(int id);
		TripDetails? GetTripDetails(int id);
		IEnumerable<TripDetails?> GetTripsByDate(DateTime date);
		IEnumerable<TripDetails?> GetTripsByDateInterval(DateInterval dateInterval);
		Task<Trip?> GetTripStudentsById(int id);

		Task EndTrip(Trip trip);
	}
}
