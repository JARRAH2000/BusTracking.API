using BusTracking.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.Mail
{
	public interface IMailSender
	{
		Task SendEmailAsync(string recipient, string subject, string body);

		Task AbsenceEmailAsync(AbsenceEmail? absenceEmail);

		//Task TripEmailAsync(string recipient, string subject, string body);
	}
}
