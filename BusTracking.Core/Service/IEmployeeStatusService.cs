using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.Service
{
	public interface IEmployeeStatusService
	{
		IEnumerable<Employeestatus?> GetAllEmployeeStatuses();

		Employeestatus? GetEmployeeStatusById(int id);

		void CreateEmployeeStatus(Employeestatus employeestatus);
	}
}
