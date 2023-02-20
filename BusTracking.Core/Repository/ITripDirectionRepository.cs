using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Data;
namespace BusTracking.Core.Repository
{
	public interface ITripDirectionRepository
	{
		IEnumerable<Tripdirection?>GetAllTripDirections();
		Tripdirection? GetTripDirectionById(int id);
		void CreateTripDirection(Tripdirection tripdirection);
		void UpdateTripDirection(Tripdirection tripdirection);
		void DeleteTripDirection(int id);
	}
}
