using BusTracking.Core.Data;
using BusTracking.Core.Repository;
using BusTracking.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Infra.Service
{
	public class TeacherService:ITeacherService
	{
		private readonly ITeacherRepository _teacherRepository;
		public TeacherService(ITeacherRepository teacherRepository)
		{
			_teacherRepository = teacherRepository;
		}
		public IEnumerable<Teacher?> GetAllTeachers()
		{
			return _teacherRepository.GetAllTeachers();
		}
		public IEnumerable<Teacher?> GetBusyTeachers()
		{
			return _teacherRepository.GetBusyTeachers();
		}
		public IEnumerable<Teacher?> GetAvailableTeachers()
		{
			return _teacherRepository.GetAvailableTeachers();
		}
		public Teacher? GetTeacherById(int id)
		{
			return _teacherRepository.GetTeacherById(id);
		}
		public int CreateTeacher(Teacher teacher)
		{
			return _teacherRepository.CreateTeacher(teacher);
		}
		public void UpdateTeacher(Teacher teacher)
		{
			_teacherRepository.UpdateTeacher(teacher);
		}
		public void DeleteTeacher(int id)
		{
			_teacherRepository.DeleteTeacher(id);
		}
	}
}
