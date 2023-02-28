﻿using BusTracking.Core.Common;
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
		public IEnumerable<Driver?> GetAllDrivers()
		{
			return _dbContext.Connection.Query<Driver?>("DRIVER_PACKAGE.GET_ALL_DRIVERS", commandType: CommandType.StoredProcedure).ToList();
		}
		public IEnumerable<Driver?> GetBusyDrivers()
		{
			return _dbContext.Connection.Query<Driver?>("DRIVER_PACKAGE.GET_BUSY_DRIVERS", commandType: CommandType.StoredProcedure).ToList();
		}
		public IEnumerable<Driver?> GetAvailableDrivers()
		{
			return _dbContext.Connection.Query<Driver?>("DRIVER_PACKAGE.GET_AVAILABLE_DRIVERS", commandType: CommandType.StoredProcedure).ToList();
		}
		public IEnumerable<Driver?> GetExpiredLicenseDrivers()
		{
			return _dbContext.Connection.Query<Driver?>("DRIVER_PACKAGE.GET_EXPIRED_LICENSE_DRIVERS", commandType: CommandType.StoredProcedure).ToList();
		}
		public Driver? GetDriverById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { DRIVERID = id });
			return _dbContext.Connection.Query<Driver?>("DRIVER_PACKAGE.GET_DRIVER_BY_ID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
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
