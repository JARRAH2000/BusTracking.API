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
		IEnumerable<Student?> GetAllStudents();
		Student? GetStudentById(int id);
		int CreateStudent(Student student);
		void UpdateStudent(Student student);
		void DeleteStudent(int id);
	}
}
