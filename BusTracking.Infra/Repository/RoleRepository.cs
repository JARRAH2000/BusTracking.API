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
	public class RoleRepository : IRoleRepository
	{
		private readonly IDbContext _dbContext;
		public RoleRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public Role? GetRoleById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { RID = id });
			return _dbContext.Connection.Query<Role>("ROLE_PACKAGE.GET_ROLE_BY_ID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
		}
		public IEnumerable<Role?> GetRoleByName(string name)
		{
			DynamicParameters parameters = new DynamicParameters(new { RNAME = name });
			return _dbContext.Connection.Query<Role>("ROLE_PACKAGE.GET_ROLE_BY_NAME", parameters, commandType: CommandType.StoredProcedure).ToList();
		}
		public IEnumerable<Role?> GetAllRoles()
		{
			return _dbContext.Connection.Query<Role>("ROLE_PACKAGE.GET_ALL_ROLES", commandType: CommandType.StoredProcedure);
		}
		public int CreateRole(Role role)
		{
			DynamicParameters parameters = new DynamicParameters(new { RNAME = role.Name, RID = role.Id });
			_dbContext.Connection.Execute("ROLE_PACKAGE.CREATE_ROLE", parameters, commandType: CommandType.StoredProcedure);
			return (int)parameters.Get<decimal>("RID");
		}
		public void UpdateRole(Role role)
		{
			DynamicParameters parameters = new DynamicParameters(new { RID = role.Id, RNAME = role.Name });
			_dbContext.Connection.Execute("ROLE_PACKAGE.UPDATE_ROLE", parameters, commandType: CommandType.StoredProcedure);
		}
		public void DeleteRole(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { RID = id });
			_dbContext.Connection.Execute("ROLE_PACKAGE.DELETE_ROLE", parameters, commandType: CommandType.StoredProcedure);
		}
	}
}
