using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.DTO
{
	public class AbsenceEmail
	{
		public string? ParentName { get; set; }
		public string? ParentEmail { get; set; }

		public string? ParentSex { get; set; }
		public string? StudentName { get; set; }
		public string? TeacherName { get; set; }

		public DateTime? AbsenceDate { get; set; }
	}
}
