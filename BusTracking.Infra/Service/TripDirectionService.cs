using BusTracking.Core.Service;
using BusTracking.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Repository;
using BusTracking.Core.Data;

namespace BusTracking.Infra.Service
{
	public class TripDirectionService:ITripDirectionService
	{
		private readonly ITripDirectionRepository _tripDirectionRepository;
		public TripDirectionService(ITripDirectionRepository tripDirectionRepository)
		{
			_tripDirectionRepository = tripDirectionRepository;
		}
		public IEnumerable<Tripdirection?> GetAllTripDirections()
		{
			return _tripDirectionRepository.GetAllTripDirections();
		}
		public Tripdirection? GetTripDirectionById(int id)
		{
			return _tripDirectionRepository.GetTripDirectionById(id);
		}
		public void CreateTripDirection(Tripdirection tripdirection)
		{
			_tripDirectionRepository.CreateTripDirection(tripdirection);
		}
		public void UpdateTripDirection(Tripdirection tripdirection)
		{
			_tripDirectionRepository.UpdateTripDirection(tripdirection);
		}
		public void DeleteTripDirection(int id)
		{
			_tripDirectionRepository.DeleteTripDirection(id);
		}
	}
}
