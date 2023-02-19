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
		public IEnumerable<Teacher?> GetAllTeachers()
		{
			return _dbContext.Connection.Query<Teacher?>("TEACHER_PACKAGE.GET_ALL_TEACHERS", commandType: CommandType.StoredProcedure).ToList();
		}
		public IEnumerable<Teacher?> GetBusyTeachers()
		{
			return _dbContext.Connection.Query<Teacher?>("TEACHER_PACKAGE.GET_BUSY_TEACHERS", commandType: CommandType.StoredProcedure).ToList();
		}

		public IEnumerable<Teacher?> GetAvailableTeachers()
		{
			return _dbContext.Connection.Query<Teacher?>("TEACHER_PACKAGE.GET_AVAILABLE_TEACHERS", commandType: CommandType.StoredProcedure).ToList();
		}

		public Teacher? GetTeacherById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { TEACHERID = id });
			return _dbContext.Connection.Query<Teacher?>("TEACHER_PACKAGE.GET_TEACHER_BY_ID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
		}
		public int CreateTeacher(Teacher teacher)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				UID = teacher.Userid,
				SID = teacher.Statusid,
				TID = teacher.Id
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
	}
}
