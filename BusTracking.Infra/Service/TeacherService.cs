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
		public async Task<IEnumerable<Teacher?>> GetAllTeachers()
		{
			return await _teacherRepository.GetAllTeachers();
		}
		public async Task<IEnumerable<Teacher?>> GetBusyTeachers()
		{
			return await _teacherRepository.GetBusyTeachers();
		}
		public async Task<IEnumerable<Teacher?>> GetAvailableTeachers()
		{
			return await _teacherRepository.GetAvailableTeachers();
		}
		public async Task<Teacher?> GetTeacherWithTripsById(int id)
		{
			return await _teacherRepository.GetTeacherWithTripsById(id);
		}
		public Teacher? GetTeacherById(int id)
		{
			return _teacherRepository.GetTeacherById(id);
		}
		public async Task<Teacher?> GetTeacherByUserId(int userId)
		{
			return await _teacherRepository.GetTeacherByUserId(userId);
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
		public IEnumerable<Teacher?> GetTeacherByName(string tchName)
		{
			return _teacherRepository.GetTeacherByName(tchName);
		}
	}
}
