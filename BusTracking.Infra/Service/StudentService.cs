using BusTracking.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Service;
using BusTracking.Infra.Repository;
using BusTracking.Core.Data;

namespace BusTracking.Infra.Service
{
	public class StudentService:IStudentService
	{
		private readonly IStudentRepository _studentRepository;
		public StudentService(IStudentRepository studentRepository)
		{
			_studentRepository = studentRepository;
		}
		public IEnumerable<Student?> GetAllStudents()
		{
			return _studentRepository.GetAllStudents();
		}
		public Student? GetStudentById(int id)
		{
			return _studentRepository.GetStudentById(id);
		}
		public async Task<Student?> GetStudentAbsenceById(int id)
		{
			return await _studentRepository.GetStudentAbsenceById(id);
		}
		public int CreateStudent(Student student)
		{
			return _studentRepository.CreateStudent(student);
		}
		public void UpdateStudent(Student student)
		{
			_studentRepository.UpdateStudent(student);
		}
		public void DeleteStudent(int id)
		{
			_studentRepository.DeleteStudent(id);
		}
	}
}
