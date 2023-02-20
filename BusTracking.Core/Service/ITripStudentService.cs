using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.Service
{
	public interface ITripStudentService
	{
		IEnumerable<Tripstudent?> GetAllTripStudents();
		Tripstudent? GetTripStudentById(int id);
		void CreateTripStudent(Tripstudent tripstudent);
		void UpdateTripStudent(Tripstudent tripstudent);
		void DeleteTripStudent(int id);
	}
}
