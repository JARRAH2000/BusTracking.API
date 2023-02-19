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
	public class EmployeeStatusService:IEmployeeStatusService
	{
		private readonly IEmployeeStatusRepository _employeeStatusRepository;
		public EmployeeStatusService(IEmployeeStatusRepository employeeStatusRepository)
		{
			_employeeStatusRepository = employeeStatusRepository;
		}
		public IEnumerable<Employeestatus?> GetAllEmployeeStatuses()
		{
			return _employeeStatusRepository.GetAllEmployeeStatuses();
		}

		public Employeestatus? GetEmployeeStatusById(int id)
		{
			return _employeeStatusRepository.GetEmployeeStatusById(id);
		}

		public void CreateEmployeeStatus(Employeestatus employeestatus)
		{
			_employeeStatusRepository.CreateEmployeeStatus(employeestatus);
		}
	}
}
