using BusTracking.API.Settings;
using BusTracking.Core.Service;
using MailKit.Net.Smtp;
using Microsoft.Extensions.Options;
using MimeKit;
using MailKit.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Mail;
using BusTracking.Core.DTO;
//using System.Net.Mail;
namespace BusTracking.Infra.Service
{
	public class MailSender : IMailSender
	{
		private readonly IMailCredentials _mailCredentials;
		public MailSender(IMailCredentials mailCredentials)
		{
			_mailCredentials = mailCredentials;
		}
		public async Task SendEmailAsync(string recipient, string subject, string body)
		{
			BodyBuilder bodyBuilder = new()
			{
				HtmlBody = body
			};
			MimeMessage message = new()
			{
				Sender = MailboxAddress.Parse(_mailCredentials.Email),
				Subject = subject,
				Body = bodyBuilder.ToMessageBody(),
				From = { MailboxAddress.Parse(_mailCredentials.Email) },
				To = { MailboxAddress.Parse(recipient) }
			};
			SmtpClient smtpClient = new();
			smtpClient.Connect(_mailCredentials.Host, _mailCredentials.Port, SecureSocketOptions.StartTls);
			smtpClient.Authenticate(_mailCredentials.Email, _mailCredentials.Password);
			await smtpClient.SendAsync(message);
			smtpClient.Disconnect(true);
		}
		public async Task AbsenceEmailAsync(AbsenceEmail? absenceEmail)
		{
			if (absenceEmail == null) return;
			BodyBuilder bodyBuilder = new()
			{
				HtmlBody = $"{(absenceEmail.ParentSex == "M" ? "Mr" : "Ms")} {absenceEmail.ParentName},\n" +
				$"We are going to tell you that your son: {absenceEmail.StudentName} {absenceEmail.ParentName} " +
				$"was considered as an absent by teacher: {absenceEmail.TeacherName} for date: {absenceEmail.AbsenceDate}"
			};
			MimeMessage message = new()
			{
				Sender = MailboxAddress.Parse(_mailCredentials.Email),
				Subject = "Absence",
				Body = bodyBuilder.ToMessageBody(),
				From = { MailboxAddress.Parse(_mailCredentials.Email) },
				To = { MailboxAddress.Parse(absenceEmail.ParentEmail) }
			};
			SmtpClient smtpClient= new();
			smtpClient.Connect(_mailCredentials.Host, _mailCredentials.Port, SecureSocketOptions.StartTls);
			smtpClient.Authenticate(_mailCredentials.Email, _mailCredentials.Password);
			await smtpClient.SendAsync(message);
			smtpClient.Disconnect(true);
		}
		//public Task TripEmailAsync(string recipient, string subject, string body)
		//{

		//}
	}
}
