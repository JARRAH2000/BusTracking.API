using BusTracking.API.Settings;
using BusTracking.Core.Common;
using BusTracking.Core.Repository;
using BusTracking.Core.Service;
using BusTracking.Infra.Common;
using BusTracking.Infra.Repository;
using BusTracking.Infra.Service;


using BusTracking.Core.Mail;

using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

namespace BusTracking.API
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);

			// Add services to the container.

			builder.Services.AddControllers();
			// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();


			//Allow external access
			builder.Services.AddCors(corsOptions =>
			{
				corsOptions.AddPolicy("policy",
				builder =>
				{
					builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader();
				});
			});





			//Commons
			builder.Services.AddScoped<IDbContext, DbContext>();

			//Repositories
			builder.Services.AddScoped<IRoleRepository, RoleRepository>();
			builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddScoped<ILoginRepository, LoginRepository>();
			builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
			builder.Services.AddScoped<IDriverRepository, DriverRepository>();
			builder.Services.AddScoped<IBusRepository, BusRepository>();
			builder.Services.AddScoped<IParentRepository,ParentRepository>();
			builder.Services.AddScoped<IStudentRepository, StudentRepository>();
			builder.Services.AddScoped<ITripRepository, TripRepository>();
			builder.Services.AddScoped<ITripStudentRepository, TripStudentRepository>();
			builder.Services.AddScoped<INotificationRepository, NotificationRepository>();
			builder.Services.AddScoped<IAbsenceRepository, AbsenceRepository>();
			builder.Services.AddScoped<IEmployeeStatusRepository, EmployeeStatusRepository>();
			builder.Services.AddScoped<ITripDirectionRepository, TripDirectionRepository>();
			builder.Services.AddScoped<IStudentStatusRepository, StudentStatusRepository>();
			builder.Services.AddScoped<IContentRepository, ContentRepository>();
			builder.Services.AddScoped<IContactRepository, ContactRepository>();
			builder.Services.AddScoped<ITestimonialRepository, TestimonialRepository>();
			//Services
			builder.Services.AddScoped<IRoleService, RoleService>();
			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<ILoginService, LoginService>();
			builder.Services.AddScoped<ITeacherService, TeacherService>();
			builder.Services.AddScoped<IDriverService, DriverService>();
			builder.Services.AddScoped<IBusService, BusService>();
			builder.Services.AddScoped<IParentService, ParentService>();
			builder.Services.AddScoped<IStudentService, StudentService>();
			builder.Services.AddScoped<ITripService, TripService>();
			builder.Services.AddScoped<ITripStudentService, TripStudentService>();
			builder.Services.AddScoped<INotificationService, NotificationService>();
			builder.Services.AddScoped<IAbsenceService, AbsenceService>();
			builder.Services.AddScoped<IEmployeeStatusService, EmployeeStatusService>();
			builder.Services.AddScoped<ITripDirectionService, TripDirectionService>();
			builder.Services.AddScoped<IStudentStatusService, StudentStatusService>();
			builder.Services.AddScoped<IContentService, ContentService>();
			builder.Services.AddScoped<IContactService, ContactService>();
			builder.Services.AddScoped<ITestimonialService, TestimonialService>();

			//Mail Setting
			//builder.Services.Configure<MailCredentials>(options => builder.Configuration.GetSection("MailSetting").Bind(options));
			builder.Services.AddScoped<IMailCredentials,MailCredentials>();
			builder.Services.AddScoped<IMailSender, MailSender>();
			///**


			//JWT configurations
			builder.Services.AddAuthentication(options =>
			{
				options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
				options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
			}).AddJwtBearer(option =>
			{
				option.TokenValidationParameters = new TokenValidationParameters
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("BusTrackingSystemByTahalufTrainees_Basheer_Alaa_AhmadQuran_And_AhmadObiedat"))
				};
			});



			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();

			//allow cors
			app.UseCors("policy");

			app.MapControllers();

			app.Run();
		}
	}
}