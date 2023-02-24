using BusTracking.Core.Mail;
using Microsoft.Extensions.Configuration;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace BusTracking.API.Settings
{
	public class MailCredentials:IMailCredentials
	{
		private readonly IConfiguration _configuration;
		public MailCredentials(IConfiguration configuration)
		{
			_configuration = configuration;
		}
		public string? Email => _configuration["MailSetting:Email"];
		public string? Password => _configuration["MailSetting:Password"];
		public string? DisplayName => _configuration["MailSetting:DisplayName"];
		public string? Host => _configuration["MailSetting:Host"];
		public int Port => Convert.ToInt32(_configuration["MailSetting:Port"]);
	}
}
