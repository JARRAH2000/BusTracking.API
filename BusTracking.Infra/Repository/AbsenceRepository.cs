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
using BusTracking.Core.Mail;
using BusTracking.Core.DTO;
using BusTracking.Infra.Service;
using static Dapper.SqlMapper;

namespace BusTracking.Infra.Repository
{
	public class AbsenceRepository:IAbsenceRepository
	{
		private readonly IDbContext _dbContext;
		private readonly IMailCredentials _mailCredentials;
		public AbsenceRepository(IDbContext dbContext,IMailCredentials mailCredentials)
		{
			_dbContext = dbContext;
			_mailCredentials = mailCredentials;
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
		public async Task CreateAbsence(Absence absence)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				CHECKTIME = absence.Checkingtime,
				TECHER = absence.Teacherid,
				STUDENT = absence.Studentid,
				ABSENCEID = absence.Id
			});
			_dbContext.Connection.Execute("ABSENCE_PACKAGE.CREATE_ABSENCE", parameters, commandType: CommandType.StoredProcedure);
			DynamicParameters emailParameters = new DynamicParameters(new
			{
				ABSENCEID = parameters.Get<decimal>("ABSENCEID")
			});
			AbsenceEmail? absenceEmail = _dbContext.Connection.Query<AbsenceEmail>("ABSENCE_PACKAGE.GET_ABSENCE_INFO_EMAIL", emailParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
			MailSender mailSender = new MailSender(_mailCredentials);
			
			await mailSender.AbsenceEmailAsync(absenceEmail);
			//return (int)parameters.Get<decimal>("ABSENCEID");
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
		public IEnumerable<Absence?> GetAbsencesByDate(DateTime date)
		{
			DynamicParameters parameters = new DynamicParameters(new { ABSENCEDATE = date });
			IEnumerable<Absence> absences = _dbContext.Connection.Query<Absence>("ABSENCE_PACKAGE.GET_ABSENCE_BY_DATE", parameters, commandType: CommandType.StoredProcedure);
			absences = absences.Select(absence =>
			{
				absence.Teacher = _dbContext.Connection.Query<Teacher?>("TEACHER_PACKAGE.GET_TEACHER_BY_ID", new DynamicParameters(new { TEACHERID = absence.Teacherid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
				absence.Student = _dbContext.Connection.Query<Student?>("STUDENT_PACKAGE.GET_STUDENT_BY_ID", new DynamicParameters(new { STUDENTID = absence.Studentid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
				return absence;
			});
			return absences;
		}
		public IEnumerable<Absence?> GetAbsencesByDateInterval(DateInterval dateInterval)
		{
			DynamicParameters parameters = new DynamicParameters(new { ABSENCEFROM = dateInterval.From, ABSENCETO = dateInterval.To });
			IEnumerable<Absence> absences = _dbContext.Connection.Query<Absence>("ABSENCE_PACKAGE.GET_ABSENCE_BY_DATE_INTERVAL", parameters, commandType: CommandType.StoredProcedure);
			absences = absences.Select(absence =>
			{
				absence.Teacher = _dbContext.Connection.Query<Teacher?>("TEACHER_PACKAGE.GET_TEACHER_BY_ID", new DynamicParameters(new { TEACHERID = absence.Teacherid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
				absence.Student = _dbContext.Connection.Query<Student?>("STUDENT_PACKAGE.GET_STUDENT_BY_ID", new DynamicParameters(new { STUDENTID = absence.Studentid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
				return absence;
			});
			return absences;
		}
	}
}
