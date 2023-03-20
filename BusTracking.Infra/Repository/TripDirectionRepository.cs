using BusTracking.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Common;
using System.Security.Permissions;
using BusTracking.Core.Data;
using Dapper;
namespace BusTracking.Infra.Repository
{
	public class TripDirectionRepository:ITripDirectionRepository
	{
		private readonly IDbContext _dbContext;
		public TripDirectionRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IEnumerable<Tripdirection?> GetAllTripDirections()
		{
			return _dbContext.Connection.Query<Tripdirection?>("TRIPDIRECTION_PACKAGE.GET_ALL_TRIPDIRECTIONS", commandType: CommandType.StoredProcedure).ToList();
		}
		public Tripdirection? GetTripDirectionById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { DIRECTIONID = id });
			return _dbContext.Connection.Query<Tripdirection?>("TRIPDIRECTION_PACKAGE.GET_TRIPDIRECTION_BY_ID", commandType: CommandType.StoredProcedure).FirstOrDefault();
		}
		public void CreateTripDirection(Tripdirection tripdirection)
		{
			DynamicParameters parameters = new DynamicParameters(new { DIRECT = tripdirection.Direction });
			_dbContext.Connection.Execute("TRIPDIRECTION_PACKAGE.CREATE_TRIPDIRECTION", parameters, commandType: CommandType.StoredProcedure);
		}
		public void UpdateTripDirection(Tripdirection tripdirection)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				DIRECTIONID = tripdirection.Id,
				DIRECT = tripdirection.Direction
			});
			_dbContext.Connection.Execute("TRIPDIRECTION_PACKAGE.UPDATE_TRIPDIRECTION", parameters, commandType: CommandType.StoredProcedure);
		}
		public void DeleteTripDirection(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { DIRECTIONID = id });
			_dbContext.Connection.Execute("TRIPDIRECTION_PACKAGE.DELETE_TRIPDIRECTION", parameters, commandType: CommandType.StoredProcedure);
		}
	}
}
