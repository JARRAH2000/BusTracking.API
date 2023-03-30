using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Data;
namespace BusTracking.Core.Repository
{
	public interface ITripStudentRepository
	{
		IEnumerable<Tripstudent?> GetAllTripStudents();

		Task<IEnumerable<Tripstudent?>> GetTripStudentsByTripId(int tripId);
		Tripstudent? GetTripStudentById(int id);
		Task CreateTripStudent(Tripstudent tripstudent);
		void UpdateTripStudent(Tripstudent tripstudent);
		void DeleteTripStudent(int id);
	}
}
