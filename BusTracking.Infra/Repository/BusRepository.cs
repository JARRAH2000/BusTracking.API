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
	public class BusRepository:IBusRepository
	{
		private readonly IDbContext _dbContext;
		public BusRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IEnumerable<Bus?> GetAllBuses()
		{
			return _dbContext.Connection.Query<Bus?>("BUS_PACKAGE.GET_ALL_BUSES", commandType: CommandType.StoredProcedure).ToList();		}
		public IEnumerable<Bus?> GetAvailableBuses()
		{
			return _dbContext.Connection.Query<Bus?>("BUS_PACKAGE.GET_AVAILABLE_BUSES", commandType: CommandType.StoredProcedure).ToList();
		}
		public IEnumerable<Bus?> GetBusyBuses()
		{
			return _dbContext.Connection.Query<Bus?>("BUS_PACKAGE.GET_BUSY_BUSES", commandType: CommandType.StoredProcedure).ToList();
		}
		public IEnumerable<Bus?> GetExpiredLicenseBuses()
		{
			return _dbContext.Connection.Query<Bus?>("BUS_PACKAGE.GET_EXPIRED_LICENSE_BUSES", commandType: CommandType.StoredProcedure).ToList();
		}
		public IEnumerable<Bus?> GetBusesOrderedByCapacity()
		{
			return _dbContext.Connection.Query<Bus?>("BUS_PACKAGE.GET_CAPACITY_ORDERED_BUSES", commandType: CommandType.StoredProcedure).ToList();
		}
		public IEnumerable<Bus?> GetBusByModel(string model)
		{
			DynamicParameters parameters = new DynamicParameters(new { BUSMODEL = model });
			return _dbContext.Connection.Query<Bus?>("BUS_PACKAGE.GET_BUS_BY_MODEL", parameters, commandType: CommandType.StoredProcedure).ToList();
		}
		public IEnumerable<Bus?> GetBusByBrand(string brand)
		{
			DynamicParameters parameters = new DynamicParameters(new { BUSBRAND = brand });
			return _dbContext.Connection.Query<Bus?>("BUS_PACKAGE.GET_BUS_BY_BRAND", parameters, commandType: CommandType.StoredProcedure).ToList();
		}
		public IEnumerable<Bus?> GetBusByVRP(string vrp)
		{
			DynamicParameters parameters = new DynamicParameters(new { PLATENUMBER = vrp });
			return _dbContext.Connection.Query<Bus?>("BUS_PACKAGE.GET_BUS_BY_VRP", parameters, commandType: CommandType.StoredProcedure).ToList();
		}
		public IEnumerable<Bus?> GetBusByCapacityThreshold(int capacity)
		{
			DynamicParameters parameters = new DynamicParameters(new { THRESHOLD = capacity });
			return _dbContext.Connection.Query<Bus?>("BUS_PACKAGE.GET_BUS_BY_CAPACITY_THRESHOLD", parameters, commandType: CommandType.StoredProcedure).ToList();
		}
		public Bus? GetBusById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { BID = id });
			return _dbContext.Connection.Query<Bus?>("BUS_PACKAGE.GET_BUS_BY_ID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
		}
		public async Task<Bus?> GetBusWithTripsById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { BSID = id });
			IEnumerable<Bus> buses = await _dbContext.Connection.QueryAsync<Bus, Trip, Bus>("BUS_PACKAGE.GET_BUS_TRIPS_BY_ID", (bus, trip) =>
			{
				bus.Trips.Add(trip);
				return bus;
			},
			splitOn: "Id",
			param: parameters,
			commandType: CommandType.StoredProcedure
			);
			buses = buses.GroupBy(b => b.Id).Select(bus =>
			{
				Bus bs = bus.First();
				bs.Status = _dbContext.Connection.Query<Employeestatus?>("EMPLOYEESTATUS_PACKAGE.GET_STATUS_BY_ID", new DynamicParameters(new { SID = bs.Statusid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
				bs.Trips = bus.Select(b => b.Trips.Single()).ToList();
				return bs;
			});
			return buses.FirstOrDefault();
		}
		public int CreateBus(Bus bus)
		{
			DynamicParameters parameters = new DynamicParameters(new 
			{ 
				CHAIRS = bus.Capacity,
				PLATENUMBER = bus.Vrp,
				BUSBRAND = bus.Brand,
				BUSMODEL = bus.Model,
				EXPIRED = bus.Licensedate,
				IMG = bus.Image,
				SID = bus.Statusid,
				BID = bus.Id 
			});
			_dbContext.Connection.Execute("BUS_PACKAGE.CREATE_BUS", parameters, commandType: CommandType.StoredProcedure);
			return (int)parameters.Get<decimal>("BID");
		}
		public void UpdateBus(Bus bus)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				BID = bus.Id,
				CHAIRS = bus.Capacity,
				PLATENUMBER = bus.Vrp,
				BUSBRAND = bus.Brand,
				BUSMODEL = bus.Model,
				EXPIRED = bus.Licensedate,
				IMG = bus.Image,
				SID = bus.Statusid
			});
			_dbContext.Connection.Execute("BUS_PACKAGE.UPDATE_BUS", parameters, commandType: CommandType.StoredProcedure);
		}
		public void DeleteBus(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { BID = id });
			_dbContext.Connection.Execute("BUS_PACKAGE.DELETE_BUS", parameters, commandType: CommandType.StoredProcedure);
		}
	}
}
