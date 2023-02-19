using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.Service
{
	public interface ITripService
	{
		IEnumerable<Trip?> GetAllTrips();
		Trip? GetTripById(int id);
		int CreateTrip(Trip trip);
		void UpdateTrip(Trip trip);
		void DeleteTrip(int id);
	}
}
