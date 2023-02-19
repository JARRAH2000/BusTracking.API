using BusTracking.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Service;
using BusTracking.Core.Data;

namespace BusTracking.Infra.Service
{
	public class StudentStatusService:IStudentStatusService
	{
		private readonly IStudentStatusRepository _studentStatusRepository;
		public StudentStatusService(IStudentStatusRepository studentStatusRepository)
		{
			_studentStatusRepository = studentStatusRepository;
		}
		public IEnumerable<Studentstatus?> GetAllStudentStatuses()
		{
			return _studentStatusRepository.GetAllStudentStatuses();
		}
		public Studentstatus? GetStudentStatusById(int id)
		{
			return _studentStatusRepository.GetStudentStatusById(id);
		}

		public void CreateStudentStatus(Studentstatus studentstatus)
		{
			_studentStatusRepository.CreateStudentStatus(studentstatus);
		}
	}
}
