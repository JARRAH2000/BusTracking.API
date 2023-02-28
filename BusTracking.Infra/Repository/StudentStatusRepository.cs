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
	public class StudentStatusRepository:IStudentStatusRepository
	{
		private readonly IDbContext _dbContext;
		public StudentStatusRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IEnumerable<Studentstatus?> GetAllStudentStatuses()
		{
			return _dbContext.Connection.Query<Studentstatus?>("STUDENTSTATUS_PACKAGE.GET_ALL_STUDENTSTATUSES", commandType: CommandType.StoredProcedure).ToList();
		}
		public Studentstatus? GetStudentStatusById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { SSID = id });
			return _dbContext.Connection.Query<Studentstatus?>("STUDENTSTATUS_PACKAGE.GET_STUDENTSTATUS_BY_ID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
		}

		public void CreateStudentStatus(Studentstatus studentstatus)
		{
			DynamicParameters parameters = new DynamicParameters(new { STATE = studentstatus.Status });
			_dbContext.Connection.Execute("STUDENTSTATUS_PACKAGE.CREATE_STUDENTSTATUS", parameters, commandType: CommandType.StoredProcedure);	

		}
	}
}
