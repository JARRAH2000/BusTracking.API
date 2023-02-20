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
			return _dbContext.Connection.Query<Tripdirection?>("Tripdirection_package.Getall_Tripdirection", commandType: CommandType.StoredProcedure).ToList();
		}
		public Tripdirection? GetTripDirectionById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { DirectID = id });
			return _dbContext.Connection.Query<Tripdirection?>("Tripdirection_package.GET_Tripdirection_BY_ID", commandType: CommandType.StoredProcedure).FirstOrDefault();
		}
		public void CreateTripDirection(Tripdirection tripdirection)
		{
			DynamicParameters parameters = new DynamicParameters(new { Direct = tripdirection.Direction });
			_dbContext.Connection.Execute("Tripdirection_package.Create_Tripdirection", parameters, commandType: CommandType.StoredProcedure);
		}
		public void UpdateTripDirection(Tripdirection tripdirection)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				DirectID = tripdirection.Id,
				Direct = tripdirection.Direction
			});
			_dbContext.Connection.Execute("Tripdirection_package.Update_Tripdirection", parameters, commandType: CommandType.StoredProcedure);
		}
		public void DeleteTripDirection(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { DirectID = id });
			_dbContext.Connection.Execute("Tripdirection_package.Delete_Tripdirection", parameters, commandType: CommandType.StoredProcedure);
		}
	}
}
