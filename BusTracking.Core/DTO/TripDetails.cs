using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.DTO
{
	public class TripDetails
	{
		public string? TeacherName { get; set; }
		public string? TeacherEmail { get; set; }
		public string? TeacherPhone { get; set; }
		public string? DriverName { get; set; }
		public string? TripDirection { get; set; }
		public string? Longitude { get; set; }
		public string? Latitude { get; set; }
		public TimeSpan? TripStartTime { get; set; }
		public int BusCapacity { get; set; }
		public string? BusRegisterPlate { get; set; }
	}
}
