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
using System.Security.AccessControl;
using System.Runtime.CompilerServices;
using System.Diagnostics.CodeAnalysis;

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
			return _dbContext.Connection.Query<Trip?, Teacher?, User?, Trip?>("TRIP_PACKAGE.GET_ALL_TRIPS", (trip, teacher, user) =>
			{
				if (trip == null || teacher == null || user == null) return trip;
				teacher.User = user;
				trip.Teacher = teacher;
				return trip;
			},splitOn:"Id", commandType: CommandType.StoredProcedure).ToList();
		}
		public Trip? GetTripById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { TRIPID = id });
			return _dbContext.Connection.Query<Trip?>("TRIP_PACKAGE.GET_TRIP_BY_ID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
		}
		public async Task<int> CreateTrip(Trip trip)
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
			await _dbContext.Connection.ExecuteAsync("TRIP_PACKAGE.CREATE_TRIP", parameters, commandType: CommandType.StoredProcedure);
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

		public IEnumerable<TripDetails?> GetTripsByDate(DateTime date)
		{
			DynamicParameters parameters = new DynamicParameters(new { TDATE = date });
			return _dbContext.Connection.Query<TripDetails?>("TRIP_PACKAGE.GET_TRIPS_BY_DATE", parameters, commandType: CommandType.StoredProcedure);
		}

		public IEnumerable<TripDetails?> GetTripsByDateInterval(DateInterval dateInterval)
		{
			DynamicParameters parameters = new DynamicParameters(new { TRIPFROM = dateInterval.From, TRIPTO = dateInterval.To });
			return _dbContext.Connection.Query<TripDetails?>("TRIP_PACKAGE.GET_TRIPS_BY_DATE_INTERVAL", parameters, commandType: CommandType.StoredProcedure);
		}
		public async Task<Trip?> GetTripStudentsById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { TRID = id });
			IEnumerable<Trip> trips = await _dbContext.Connection.QueryAsync<Trip, Tripstudent, Trip>("TRIP_PACKAGE.GET_TRIP_STUDENTS_BY_ID", (trip, tripstudent) =>
			{
				tripstudent.Student = _dbContext.Connection.Query<Student?>("STUDENT_PACKAGE.GET_STUDENT_BY_ID", new DynamicParameters(new { STUDENTID = tripstudent.Studentid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
				trip.Tripstudents.Add(tripstudent);
				return trip;
			},
			splitOn: "Id",
			param: parameters,
			commandType: CommandType.StoredProcedure
			);
			trips = trips.GroupBy(t => t.Id).Select(trip =>
			{
				Trip tp = trip.First();
				tp.Teacher = _dbContext.Connection.Query<Teacher?>("TEACHER_PACKAGE.GET_TEACHER_BY_ID", new DynamicParameters(new { TEACHERID = tp.Teacherid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
				tp.Driver = _dbContext.Connection.Query<Driver?>("DRIVER_PACKAGE.GET_DRIVER_BY_ID", new DynamicParameters(new { DRIVERID = tp.Driverid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
				tp.Bus = _dbContext.Connection.Query<Bus?>("BUS_PACKAGE.GET_BUS_BY_ID", new DynamicParameters(new { BID = tp.Busid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
				tp.Tripstudents = trip.Select(ts => ts.Tripstudents.Single()).ToList();
				return tp;
			});
			return trips.FirstOrDefault();
		}

		public async Task EndTrip(Trip trip)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				ENDTRIP = trip.Endtime,
				LAT = trip.Latitude,
				LNG = trip.Longitude,
				TRIPID = trip.Id
			});
			await _dbContext.Connection.ExecuteAsync("TRIP_PACKAGE.END_TRIP", parameters, commandType: CommandType.StoredProcedure);

		}

	}
}
