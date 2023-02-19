using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.Service
{
	public interface IStudentStatusService
	{
		IEnumerable<Studentstatus?> GetAllStudentStatuses();
		Studentstatus? GetStudentStatusById(int id);
		void CreateStudentStatus(Studentstatus studentstatus);
	}
}
