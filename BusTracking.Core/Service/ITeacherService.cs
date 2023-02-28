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
		IEnumerable<Teacher?> GetAllTeachers();
		IEnumerable<Teacher?> GetBusyTeachers();
		IEnumerable<Teacher?> GetAvailableTeachers();
		Task<Teacher?> GetTeacherWithTripsById(int id);
		Teacher? GetTeacherById(int id);
		int CreateTeacher(Teacher teacher);
		void UpdateTeacher(Teacher teacher);
		void DeleteTeacher(int id);
	}
}
