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
using BusTracking.Core.DTO;

namespace BusTracking.Infra.Repository
{
	public class TripRepository:ITripRepository
	{
		private readonly IDbContext _dbContext;
		public TripRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IEnumerable<Trip?> GetAllTrips()
		{
			return _dbContext.Connection.Query<Trip?>("TRIP_PACKAGE.GET_ALL_TRIPS", commandType: CommandType.StoredProcedure).ToList();
		}
		public Trip? GetTripById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { TRIPID = id });
			return _dbContext.Connection.Query<Trip?>("TRIP_PACKAGE.GET_TRIP_BY_ID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
		}
		public int CreateTrip(Trip trip)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				TCHRID = trip.Teacherid,
				BSID = trip.Busid,
				DRVID = trip.Driverid,
				TDATE = trip.Tripdate,
				STIME = trip.Starttime,
				ETIME = trip.Endtime,
				LON = trip.Longitude,
				LAT = trip.Latitude,
				DIRID = trip.Directionid,
				TRIPID = trip.Id
			});
			_dbContext.Connection.Execute("TRIP_PACKAGE.CREATE_TRIP", parameters, commandType: CommandType.StoredProcedure);
			return (int)parameters.Get<decimal>("TRIPID");
		}
		public void UpdateTrip(Trip trip)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				BSID = trip.Busid,
				DRVID = trip.Driverid,
				LON = trip.Longitude,
				LAT = trip.Latitude,
				TRIPID = trip.Id
			});
			_dbContext.Connection.Execute("TRIP_PACKAGE.UPDATE_TRIP", parameters, commandType: CommandType.StoredProcedure);
		}
		public void DeleteTrip(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { TRIPID = id });
			_dbContext.Connection.Execute("TRIP_PACKAGE.DELETE_TRIP", parameters, commandType: CommandType.StoredProcedure);
		}
		public TripDetails? GetTripDetails(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { TRIPID = id });
			return _dbContext.Connection.Query<TripDetails?>("TRIP_PACKAGE.TRIP_DETAILS", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
		}
	}
}
