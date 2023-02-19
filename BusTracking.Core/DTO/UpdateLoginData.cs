using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.DTO
{
	public class UpdateLoginData
	{
		public string? UserName { get; set; }
		public string? OldPassword { get; set; }
		public string? NewPassword { get; set; }
	}
}
