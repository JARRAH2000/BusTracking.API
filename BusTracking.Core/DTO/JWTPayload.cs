using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.DTO
{
	public class JWTPayload
	{
		public int UserId { get; set; }
		public string UserName { get; set; } = null!;
		public string UserEmail { get; set; } = null!;
		public int UserRole { get; set; }
	}
}
