using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.Service
{
	public interface ITripDirectionService
	{
		IEnumerable<Tripdirection?> GetAllTripDirections();
		Tripdirection? GetTripDirectionById(int id);
		void CreateTripDirection(Tripdirection tripdirection);
		void UpdateTripDirection(Tripdirection tripdirection);
		void DeleteTripDirection(int id);
	}
}
