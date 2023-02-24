using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.Mail
{
	public interface IMailCredentials
	{
		string? Email { get; }
		string? Password { get; }
		string? DisplayName { get; }
		string? Host { get; }
		int Port { get; }
	}
}
