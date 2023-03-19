using BusTracking.Core.Common;
using BusTracking.Core.Data;
using BusTracking.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace BusTracking.Infra.Repository
{
	public class TeacherRepository:ITeacherRepository
	{
		private readonly IDbContext _dbContext;
		public TeacherRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<IEnumerable<Teacher?>> GetAllTeachers()
		{
			return await _dbContext.Connection.QueryAsync<Teacher?, User?, Teacher?>("TEACHER_PACKAGE.GET_ALL_TEACHERS", (teacher, user) =>
			{
				if (teacher == null) return teacher;
				teacher.User = user;
				//if(teacher.User!=null)teacher.User.Logins=
				teacher.Status= _dbContext.Connection.Query<Employeestatus>("EMPLOYEESTATUS_PACKAGE.GET_STATUS_BY_ID", new DynamicParameters(new {SID=teacher.Statusid}), commandType: CommandType.StoredProcedure).FirstOrDefault();
				return teacher;
			},splitOn:"Id", commandType: CommandType.StoredProcedure);
		}
		public async Task<IEnumerable<Teacher?>> GetBusyTeachers()
		{
			return await _dbContext.Connection.QueryAsync<Teacher?,User?,Teacher?>("TEACHER_PACKAGE.GET_BUSY_TEACHERS",(teacher, user) => 
			{
				if (teacher != null) teacher.User = user;
				return teacher;
			},splitOn:"Id", commandType: CommandType.StoredProcedure);
		}

		public async Task<IEnumerable<Teacher?>> GetAvailableTeachers()
		{
			return await _dbContext.Connection.QueryAsync<Teacher?,User?,Teacher?>("TEACHER_PACKAGE.GET_AVAILABLE_TEACHERS", (teacher, user) =>
			{
				if (teacher != null) teacher.User = user;
				return teacher;
			}, splitOn: "Id", commandType: CommandType.StoredProcedure);
		}
		public async Task<Teacher?> GetTeacherWithTripsById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { TCHID = id });
			IEnumerable<Teacher> teachers = await _dbContext.Connection.QueryAsync<Teacher, Trip, Teacher>("TEACHER_PACKAGE.GET_TEACHER_WITH_TRIPS_BY_ID", (teacher, trip) =>
			{
				teacher.Trips.Add(trip);
				return teacher;
			},
			splitOn: "Id",
			param: parameters,
			commandType: CommandType.StoredProcedure
			);
			teachers = teachers.GroupBy(t => t.Id).Select(tch =>
			{
				Teacher t = tch.First();
				t.User = _dbContext.Connection.Query<User?>("USER_PACKAGE.GET_USER_BY_ID", new DynamicParameters(new { UID = t.Userid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
				if (t.User != null) t.User.Logins = _dbContext.Connection.Query<Login>("LOGIN_PACKAGE.GET_EMAIL_BY_USER_ID", new DynamicParameters(new { UID = t.Userid }), commandType: CommandType.StoredProcedure).ToList();
				t.Status = _dbContext.Connection.Query<Employeestatus?>("EMPLOYEESTATUS_PACKAGE.GET_STATUS_BY_ID", new DynamicParameters(new { SID = t.Statusid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
				t.Trips = tch.Select(tchr => tchr.Trips.Single()).ToList();
				return t;
			});
			return teachers.FirstOrDefault();
		}
		public Teacher? GetTeacherById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { TEACHERID = id });
			IEnumerable<Teacher?> teachers = _dbContext.Connection.Query<Teacher?>("TEACHER_PACKAGE.GET_TEACHER_BY_ID", parameters, commandType: CommandType.StoredProcedure);

			teachers = teachers.Select(teacher =>
			{
				if (teacher == null) return null;
				teacher.User = _dbContext.Connection.Query<User?>("USER_PACKAGE.GET_USER_BY_ID", new DynamicParameters(new { UID = teacher.Userid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
				if (teacher.User != null) teacher.User.Logins = _dbContext.Connection.Query<Login>("LOGIN_PACKAGE.GET_EMAIL_BY_USER_ID", new DynamicParameters(new { UID = teacher.Userid }), commandType: CommandType.StoredProcedure).ToList();
				teacher.Status = _dbContext.Connection.Query<Employeestatus?>("EMPLOYEESTATUS_PACKAGE.GET_STATUS_BY_ID", new DynamicParameters(new { SID = teacher.Statusid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
				teacher.Trips = _dbContext.Connection.Query<Trip>("TRIP_PACKAGE.GET_TEACHER_TRIPS", new DynamicParameters(new { TCHID = teacher.Id }), commandType: CommandType.StoredProcedure).ToList();
				return teacher;
			});
			return teachers?.FirstOrDefault();
		}
		public int CreateTeacher(Teacher teacher)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				UID = teacher.Userid,
				SID = teacher.Statusid,
				TID=teacher.Id
			});
			_dbContext.Connection.Execute("TEACHER_PACKAGE.CREATE_TEACHER", parameters, commandType: CommandType.StoredProcedure);
			return (int)parameters.Get<decimal>("TID");
		}
		public void UpdateTeacher(Teacher teacher)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				SID = teacher.Statusid,
				TID = teacher.Id
			});
			_dbContext.Connection.Execute("TEACHER_PACKAGE.UPDATE_TEACHER", parameters, commandType: CommandType.StoredProcedure);
		}
		public void DeleteTeacher(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { TID = id });
			_dbContext.Connection.Execute("TEACHER_PACKAGE.DELETE_TEACHER", parameters, commandType: CommandType.StoredProcedure);
		}
		public IEnumerable<Teacher?> GetTeacherByName(string tchName)
		{
			DynamicParameters parameters = new DynamicParameters(new { TCHNAME = tchName });
			IEnumerable<Teacher?> teachers = _dbContext.Connection.Query<Teacher?>("TEACHER_PACKAGE.GET_TEACHER_BY_NAME", parameters, commandType: CommandType.StoredProcedure);
			teachers = teachers.Select(t =>
			{
				Teacher? teacher = t;
				if (teacher != null)
					teacher.User = _dbContext.Connection.Query<User?>("USER_PACKAGE.GET_USER_BY_ID", new DynamicParameters(new { UID = teacher.Userid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
				return teacher;
			});
			return teachers;
		}
	}
}
