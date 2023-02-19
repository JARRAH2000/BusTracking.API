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
		IEnumerable<Teacher?> GetAllTeachers();
		IEnumerable<Teacher?> GetBusyTeachers();
		IEnumerable<Teacher?> GetAvailableTeachers();
		Teacher? GetTeacherById(int id);
		int CreateTeacher(Teacher teacher);
		void UpdateTeacher(Teacher teacher);
		void DeleteTeacher(int id);
	}
}
