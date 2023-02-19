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
		IEnumerable<Student?> GetAllStudents();
		Student? GetStudentById(int id);
		int CreateStudent(Student student);
		void UpdateStudent(Student student);
		void DeleteStudent(int id);
	}
}
