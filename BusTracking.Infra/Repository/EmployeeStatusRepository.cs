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
	public class EmployeeStatusRepository:IEmployeeStatusRepository
	{
		private readonly IDbContext _dbContext;
		public EmployeeStatusRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IEnumerable<Employeestatus?> GetAllEmployeeStatuses()
		{
			return _dbContext.Connection.Query<Employeestatus?>("EMPLOYEESTATUS_PACKAGE.GET_ALL_STATUSES", commandType: CommandType.StoredProcedure);
		}

		public Employeestatus? GetEmployeeStatusById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { SID = id });
			return _dbContext.Connection.Query<Employeestatus>("EMPLOYEESTATUS_PACKAGE.GET_STATUS_BY_ID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
		}

		public void CreateEmployeeStatus(Employeestatus employeestatus)
		{
			DynamicParameters parameters = new DynamicParameters(new { STATE = employeestatus.Status });
			_dbContext.Connection.Execute("EMPLOYEESTATUS_PACKAGE.CREATE_STATUS", parameters, commandType: CommandType.StoredProcedure);
		}
	}
}
