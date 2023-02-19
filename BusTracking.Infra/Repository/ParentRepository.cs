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
using System.Security.Cryptography;

namespace BusTracking.Infra.Repository
{
	public class ParentRepository:IParentRepository
	{
		private readonly IDbContext _dbContext;
		public ParentRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IEnumerable<Parent?> GetAllParents()
		{
			return _dbContext.Connection.Query<Parent?>("PARENT_PACKAGE.GET_ALL_PARENTS", commandType: CommandType.StoredProcedure).ToList();
		}
		public Parent? GetParentById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { PARENTID = id });
			return _dbContext.Connection.Query<Parent?>("PARENT_PACKAGE.GET_PARENT_BY_ID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
		}
		public int CreateParent(Parent parent)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				UID = parent.Userid,
				PARENTID = parent.Id
			});
			_dbContext.Connection.Execute("PARENT_PACKAGE.CREATE_PARENT", parameters, commandType: CommandType.StoredProcedure);
			return (int)parameters.Get<decimal>("PARENTID");
		}
		public void DeleteParent(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { PARENTID = id });
			_dbContext.Connection.Execute("PARENT_PACKAGE.DELETE_PARENT", parameters, commandType: CommandType.StoredProcedure);
		}
	}
}
