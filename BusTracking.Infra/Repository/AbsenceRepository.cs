using BusTracking.Core.Common;
using BusTracking.Core.Data;
using BusTracking.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using Dapper;

namespace BusTracking.Infra.Repository
{
	public class AbsenceRepository:IAbsenceRepository
	{
		private readonly IDbContext _dbContext;
		public AbsenceRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IEnumerable<Absence?> GetAllAbsences()
		{
			return _dbContext.Connection.Query<Absence?>("ABSENCE_PACKAGE.GET_ALL_ABSENCES", commandType: CommandType.StoredProcedure).ToList();
		}
		public Absence? GetAbsenceById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { ABID = id });
			return _dbContext.Connection.Query<Absence?>("ABSENCE_PACKAGE.GET_ABSENCE_BY_ID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
		}
		public int CreateAbsence(Absence absence)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				CHECKTIME = absence.Checkingtime,
				TECHER = absence.Teacherid,
				STUDENT = absence.Studentid,
				ABSENCEID = absence.Id
			});
			_dbContext.Connection.Execute("ABSENCE_PACKAGE.CREATE_ABSENCE", parameters, commandType: CommandType.StoredProcedure);
			return (int)parameters.Get<decimal>("ABSENCEID");
		}
		public void UpdateAbsence(Absence absence)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				ABID = absence.Id,
				CHECKTIME = absence.Checkingtime,
				TECHER = absence.Teacherid,
				STUDENT = absence.Studentid
			});
			_dbContext.Connection.Execute("ABSENCE_PACKAGE.UPDATE_ABSENCE", parameters, commandType: CommandType.StoredProcedure);
		}
		public void DeleteAbsence(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { ABID = id });
			_dbContext.Connection.Execute("ABSENCE_PACKAGE.DELETE_ABSENCE", parameters, commandType: CommandType.StoredProcedure);
		}
	}
}
