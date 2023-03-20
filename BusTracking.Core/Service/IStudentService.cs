using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.Service
{
	public interface IStudentService
	{
		Task<IEnumerable<Student?>> GetAllStudents();
		Task<Student?> GetStudentById(int id);
		Task<Student?> GetStudentAbsenceById(int id);
		IEnumerable<Student?> GetStudentByName(string stdName);
		int CreateStudent(Student student);
		void UpdateStudent(Student student);
		void DeleteStudent(int id);
	}
}
