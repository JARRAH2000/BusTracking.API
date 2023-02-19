using BusTracking.Core.Common;
using BusTracking.Core.Repository;
using BusTracking.Core.Service;
using BusTracking.Infra.Common;
using BusTracking.Infra.Repository;
using BusTracking.Infra.Service;

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


			var app = builder.Build();

			// Configure the HTTP request pipeline.
			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();

			app.UseAuthorization();


			app.MapControllers();

			app.Run();
		}
	}
}