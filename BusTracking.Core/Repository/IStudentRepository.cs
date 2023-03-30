using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Data;
namespace BusTracking.Core.Repository
{
	public interface IStudentRepository
	{
		Task<IEnumerable<Student?>> GetAllStudents();
		Task<Student?> GetStudentById(int id);
		Task<Student?> GetStudentAbsenceById(int id);

		IEnumerable<Student?> GetStudentByName(string stdName);
		int CreateStudent(Student student);
		void UpdateStudent(Student student);

		Task UpdateStudentStatusInTrip(Student student);//New
		void DeleteStudent(int id);

		Task<IEnumerable<Student?>> GetAllAbsentStudents();
	}
}
