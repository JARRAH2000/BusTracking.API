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
		Tripstudent? GetTripStudentById(int id);
		void CreateTripStudent(Tripstudent tripstudent);
		void UpdateTripStudent(Tripstudent tripstudent);
		void DeleteTripStudent(int id);
	}
}
