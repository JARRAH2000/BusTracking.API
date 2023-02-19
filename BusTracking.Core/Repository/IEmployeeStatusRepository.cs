using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.Repository
{
	public interface IEmployeeStatusRepository
	{
		IEnumerable<Employeestatus?> GetAllEmployeeStatuses();

		Employeestatus? GetEmployeeStatusById(int id);

		void CreateEmployeeStatus(Employeestatus employeestatus);
	}
}
