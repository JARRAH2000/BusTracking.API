using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Data;
namespace BusTracking.Core.Repository
{
	public interface ITeacherRepository
	{
		Task<IEnumerable<Teacher?>> GetAllTeachers();
		Task<IEnumerable<Teacher?>> GetBusyTeachers();
		Task<IEnumerable<Teacher?>> GetAvailableTeachers();
		Task<Teacher?>GetTeacherWithTripsById(int id);
		Teacher? GetTeacherById(int id);
		
		Task<Teacher?>GetTeacherByUserId(int userId);
		int CreateTeacher(Teacher teacher);
		void UpdateTeacher(Teacher teacher);
		void DeleteTeacher(int id);
		IEnumerable<Teacher?> GetTeacherByName(string tchName);
	}
}
