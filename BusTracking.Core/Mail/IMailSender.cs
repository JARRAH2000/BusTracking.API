using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.Mail
{
	public interface IMailSender
	{
		public Task SendEmailAsync(string recipient, string subject, string body);
	}
}
