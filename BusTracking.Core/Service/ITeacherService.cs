using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.Service
{
	public interface ITeacherService
	{
		Task<IEnumerable<Teacher?>> GetAllTeachers();
		Task<IEnumerable<Teacher?>> GetBusyTeachers();
		Task<IEnumerable<Teacher?>> GetAvailableTeachers();
		Task<Teacher?> GetTeacherWithTripsById(int id);
		Teacher? GetTeacherById(int id);
		Task<Teacher?> GetTeacherByUserId(int userId);
		int CreateTeacher(Teacher teacher);
		void UpdateTeacher(Teacher teacher);
		void DeleteTeacher(int id);
		IEnumerable<Teacher?> GetTeacherByName(string tchName);

	}
}
