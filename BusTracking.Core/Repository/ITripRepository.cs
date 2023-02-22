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
		int CreateTrip(Trip trip);
		void UpdateTrip(Trip trip);
		void DeleteTrip(int id);

		TripDetails?GetTripDetails(int id);
	}
}
