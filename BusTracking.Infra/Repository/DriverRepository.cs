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
	public class DriverRepository:IDriverRepository
	{
		private readonly IDbContext _dbContext;
		public DriverRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<IEnumerable<Driver?>> GetAllDrivers()
		{
			return await _dbContext.Connection.QueryAsync<Driver?, User?, Driver?>("DRIVER_PACKAGE.GET_ALL_DRIVERS", (driver, user)=>
			{
				if (driver == null) return driver;
				driver.User = user;
				if(driver.User!=null)driver.User.Logins= _dbContext.Connection.Query<Login>("LOGIN_PACKAGE.GET_EMAIL_BY_USER_ID", new DynamicParameters(new { UID = driver.Userid }), commandType: CommandType.StoredProcedure).ToList(); _dbContext.Connection.Query<Login>("LOGIN_PACKAGE.GET_EMAIL_BY_USER_ID", new DynamicParameters(new { UID = driver.Userid }), commandType: CommandType.StoredProcedure).ToList();
				return driver;
			},splitOn:"Id", commandType: CommandType.StoredProcedure);
		}
		public async Task<IEnumerable<Driver?>> GetBusyDrivers()
		{
			return await _dbContext.Connection.QueryAsync<Driver?, User?, Driver?>("DRIVER_PACKAGE.GET_BUSY_DRIVERS", (driver, user) =>
			{
				if (driver == null) return driver;
				driver.User = user;
				if (driver.User != null) driver.User.Logins = _dbContext.Connection.Query<Login>("LOGIN_PACKAGE.GET_EMAIL_BY_USER_ID", new DynamicParameters(new { UID = driver.Userid }), commandType: CommandType.StoredProcedure).ToList(); _dbContext.Connection.Query<Login>("LOGIN_PACKAGE.GET_EMAIL_BY_USER_ID", new DynamicParameters(new { UID = driver.Userid }), commandType: CommandType.StoredProcedure).ToList();
				return driver;
			}, splitOn: "Id", commandType: CommandType.StoredProcedure);
		}
		public async Task<IEnumerable<Driver?>> GetAvailableDrivers()
		{
			return await _dbContext.Connection.QueryAsync<Driver?,User?,Driver?>("DRIVER_PACKAGE.GET_AVAILABLE_DRIVERS", (driver, user) =>
			{
				if (driver == null) return driver;
				driver.User = user;
				if (driver.User != null) driver.User.Logins = _dbContext.Connection.Query<Login>("LOGIN_PACKAGE.GET_EMAIL_BY_USER_ID", new DynamicParameters(new { UID = driver.Userid }), commandType: CommandType.StoredProcedure).ToList(); _dbContext.Connection.Query<Login>("LOGIN_PACKAGE.GET_EMAIL_BY_USER_ID", new DynamicParameters(new { UID = driver.Userid }), commandType: CommandType.StoredProcedure).ToList();
				return driver;
			}, splitOn: "Id", commandType: CommandType.StoredProcedure);
		}
		public async Task<IEnumerable<Driver?>> GetExpiredLicenseDrivers()
		{
			return await _dbContext.Connection.QueryAsync<Driver?,User?,Driver?>("DRIVER_PACKAGE.GET_EXPIRED_LICENSE_DRIVERS", (driver, user) =>
			{
				if (driver == null) return driver;
				driver.User = user;
				if (driver.User != null) driver.User.Logins = _dbContext.Connection.Query<Login>("LOGIN_PACKAGE.GET_EMAIL_BY_USER_ID", new DynamicParameters(new { UID = driver.Userid }), commandType: CommandType.StoredProcedure).ToList(); _dbContext.Connection.Query<Login>("LOGIN_PACKAGE.GET_EMAIL_BY_USER_ID", new DynamicParameters(new { UID = driver.Userid }), commandType: CommandType.StoredProcedure).ToList();
				return driver;
			}, splitOn: "Id", commandType: CommandType.StoredProcedure);
		}
		public async Task<Driver?> GetDriverById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { DRIVERID = id });
			IEnumerable<Driver?> drivers = await _dbContext.Connection.QueryAsync<Driver?, User?, Driver?>("DRIVER_PACKAGE.GET_DRIVER_BY_ID", (driver, user) =>
			{
				if (driver == null) return driver;
				driver.User = user;
				if (driver.User != null) driver.User.Logins = _dbContext.Connection.Query<Login>("LOGIN_PACKAGE.GET_EMAIL_BY_USER_ID", new DynamicParameters(new { UID = driver.Userid }), commandType: CommandType.StoredProcedure).ToList(); _dbContext.Connection.Query<Login>("LOGIN_PACKAGE.GET_EMAIL_BY_USER_ID", new DynamicParameters(new { UID = driver.Userid }), commandType: CommandType.StoredProcedure).ToList();
				return driver;
			}, splitOn: "Id", param: parameters, commandType: CommandType.StoredProcedure);
			return drivers.FirstOrDefault();
		}

		public async Task<Driver?> GetDriverWithTripsById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { DRIID = id });
			IEnumerable<Driver> drivers = await _dbContext.Connection.QueryAsync<Driver, Trip, Driver>("DRIVER_PACKAGE.GET_DRIVER_WITH_TRIPS_BY_ID", (driver, trip) =>
			{
				driver.Trips.Add(trip);
				return driver;
			},
			splitOn: "Id",
			param: parameters,
			commandType: CommandType.StoredProcedure
			);
			drivers = drivers.GroupBy(d => d.Id).Select(driver =>
			{
				Driver dr = driver.First();
				dr.User = _dbContext.Connection.Query<User?>("USER_PACKAGE.GET_USER_BY_ID", new DynamicParameters(new { UID = dr.Userid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
				dr.Status = _dbContext.Connection.Query<Employeestatus?>("EMPLOYEESTATUS_PACKAGE.GET_STATUS_BY_ID", new DynamicParameters(new { SID = dr.Statusid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
				dr.Trips = driver.Select(d => d.Trips.Single()).ToList();
				return dr;
			});
			return drivers.FirstOrDefault();
		}
		public int CreateDriver(Driver driver)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				EXPIRED = driver.Licensedate,
				STATUS = driver.Statusid,
				UID = driver.Userid,
				DRIVERID = driver.Id
			});
			_dbContext.Connection.Execute("DRIVER_PACKAGE.CREATE_DRIVER", parameters, commandType: CommandType.StoredProcedure);
			return (int)parameters.Get<decimal>("DRIVERID");
		}
		public void UpdateDriver(Driver driver)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				EXPIRED = driver.Licensedate,
				STATUS = driver.Statusid,
				DRIVERID = driver.Id
			});
			_dbContext.Connection.Execute("DRIVER_PACKAGE.UPDATE_DRIVER", parameters, commandType: CommandType.StoredProcedure);
		}
		public void DeleteDriver(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { DRIVERID = id });
			_dbContext.Connection.Execute("DRIVER_PACKAGE.DELETE_DRIVER", parameters, commandType: CommandType.StoredProcedure);
		}
	}
}
