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
using System.Security.Cryptography.Xml;

namespace BusTracking.Infra.Repository
{
	public class TripStudentRepository:ITripStudentRepository
	{
		private readonly IDbContext _dbContext;
		public TripStudentRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IEnumerable<Tripstudent?> GetAllTripStudents()
		{
			return _dbContext.Connection.Query<Tripstudent?>("TRIPSTUDENT_PACKAGE.GETALL_TRIPSTUDENT", commandType: CommandType.StoredProcedure).ToList();
		}
		public async Task<IEnumerable<Tripstudent?>> GetTripStudentsByTripId(int tripId)
		{
			DynamicParameters parameters = new DynamicParameters(new { TRIPSTDID = tripId });
			return await _dbContext.Connection.QueryAsync<Tripstudent?, Trip?, Student?, Parent?, User?, Login?, Tripstudent?>("TRIPSTUDENT_PACKAGE.GET_TRIPSTUDENTS_BY_TRIP_ID", (tripstudent, trip, student, parent, user, login) =>
			{
				if (tripstudent == null) return tripstudent;
				tripstudent.Trip = trip;
				tripstudent.Student = student;
				if (tripstudent.Student != null)
				{
					tripstudent.Student.Parent = parent;
					if (tripstudent.Student.Parent != null)
					{
						tripstudent.Student.Parent.User = user;
						if (tripstudent.Student.Parent.User != null && login != null)
						{
							tripstudent.Student.Parent.User.Logins = new List<Login> { login };
						}
					}
				}
				return tripstudent;
			}, splitOn: "Id", param:parameters, commandType: CommandType.StoredProcedure);
		}
		public Tripstudent? GetTripStudentById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { TRIPSTD = id });
			return _dbContext.Connection.Query<Tripstudent?>("TRIPSTUDENT_PACKAGE.GET_TRIPSTUDENT_BY_ID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
		}
		public async Task CreateTripStudent(Tripstudent tripstudent)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				ARRIV = new TimeSpan(DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second),
				STDID = tripstudent.Studentid,
				TRID = tripstudent.Tripid
			});
			await _dbContext.Connection.ExecuteAsync("TRIPSTUDENT_PACKAGE.CREATE_TRIPSTUDENT", parameters, commandType: CommandType.StoredProcedure);
		}
		public void UpdateTripStudent(Tripstudent tripstudent)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				ARRIV = tripstudent.Arrivaltime,
				STDID = tripstudent.Studentid,
				TRID = tripstudent.Tripid,
				TRPSID = tripstudent.Id
			});
			_dbContext.Connection.Execute("TRIPSTUDENT_PACKAGE.UPDEATE_TRIPSTUDENT", parameters, commandType: CommandType.StoredProcedure);
		}
		public void DeleteTripStudent(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { TRPSID = id });
			_dbContext.Connection.Execute("TRIPSTUDENT_PACKAGE.DELETE_TRIPSTUDENT", parameters, commandType: CommandType.StoredProcedure);
		}
	}
}
