using BusTracking.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Service;
using BusTracking.Core.Data;

namespace BusTracking.Infra.Service
{
	public class TripStudentService:ITripStudentService
	{
		private readonly ITripStudentRepository _tripStudentRepository;
		public TripStudentService(ITripStudentRepository tripStudentRepository)
		{
			_tripStudentRepository = tripStudentRepository;
		}
		public IEnumerable<Tripstudent?> GetAllTripStudents()
		{
			return _tripStudentRepository.GetAllTripStudents();
		}
		public async Task<IEnumerable<Tripstudent?>> GetTripStudentsByTripId(int tripId)
		{
			 return await _tripStudentRepository.GetTripStudentsByTripId(tripId);
		}
		public Tripstudent? GetTripStudentById(int id)
		{
			return _tripStudentRepository.GetTripStudentById(id);
		}
		public async Task CreateTripStudent(Tripstudent tripstudent)
		{
			await _tripStudentRepository.CreateTripStudent(tripstudent);
		}
		public void UpdateTripStudent(Tripstudent tripstudent)
		{
			_tripStudentRepository.UpdateTripStudent(tripstudent);
		}
		public void DeleteTripStudent(int id)
		{
			_tripStudentRepository.DeleteTripStudent(id);
		}
	}
}
