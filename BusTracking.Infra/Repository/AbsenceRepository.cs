﻿using BusTracking.Core.Common;
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
using System.Drawing.Printing;

namespace BusTracking.Infra.Repository
{
	public class AbsenceRepository:IAbsenceRepository
	{
		private readonly IDbContext _dbContext;
		private readonly IMailCredentials _mailCredentials;


		private readonly IMailSender _mailSender;
		public AbsenceRepository(IDbContext dbContext,IMailCredentials mailCredentials,IMailSender mailSender)
		{
			_dbContext = dbContext;
			_mailCredentials = mailCredentials;
			_mailSender = mailSender;
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
				STDENT = absence.Studentid,
				ABSENCEID = absence.Id
			});
			try
			{
				_dbContext.Connection.Execute("ABSENCE_PACKAGE.CREATE_ABSENCE", parameters, commandType: CommandType.StoredProcedure);

				DynamicParameters param = new DynamicParameters(new { STUDENTID = absence.Studentid });
				IEnumerable<Student?> students = await _dbContext.Connection.QueryAsync<Student?, Studentstatus?, Parent?, User?, Login?, Student?>("STUDENT_PACKAGE.GET_STUDENT_BY_ID", (student, studentStatus, parent, user, login) =>
				{
					if (student == null) return student;
					student.Status = studentStatus;
					student.Parent = parent;
					if (student.Parent == null) return student;
					student.Parent.User = user;
					if (student.Parent.User != null && login != null)
						student.Parent.User.Logins = new List<Login> { login };
					return student;
				}, splitOn: "Id", param: param, commandType: CommandType.StoredProcedure);
				Student? student = students.FirstOrDefault();


				DynamicParameters parameters2 = new DynamicParameters(new { TEACHERID = absence.Teacherid });
				IEnumerable<Teacher?> teachers = _dbContext.Connection.Query<Teacher?>("TEACHER_PACKAGE.GET_TEACHER_BY_ID", parameters2, commandType: CommandType.StoredProcedure);

				teachers = teachers.Select(teacher =>
				{
					if (teacher == null) return null;
					teacher.User = _dbContext.Connection.Query<User?>("USER_PACKAGE.GET_USER_BY_ID", new DynamicParameters(new { UID = teacher.Userid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
					if (teacher.User != null) teacher.User.Logins = _dbContext.Connection.Query<Login>("LOGIN_PACKAGE.GET_EMAIL_BY_USER_ID", new DynamicParameters(new { UID = teacher.Userid }), commandType: CommandType.StoredProcedure).ToList();
					teacher.Status = _dbContext.Connection.Query<Employeestatus?>("EMPLOYEESTATUS_PACKAGE.GET_STATUS_BY_ID", new DynamicParameters(new { SID = teacher.Statusid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
					teacher.Trips = _dbContext.Connection.Query<Trip>("TRIP_PACKAGE.GET_TEACHER_TRIPS", new DynamicParameters(new { TCHID = teacher.Id }), commandType: CommandType.StoredProcedure).ToList();
					return teacher;
				});
				Teacher? teacher= teachers.FirstOrDefault();



				if (student != null && teacher != null && student.Absencenotify == "Y")
				{
					AbsenceEmail absenceEmail = new AbsenceEmail
					{
						ParentName = student?.Parent?.User?.Firstname,
						ParentEmail = student?.Parent?.User?.Logins?.FirstOrDefault()?.Email,

						ParentSex = student?.Parent?.User?.Sex,
						StudentName = student?.Name,
						TeacherName = teacher?.User?.Firstname + " " + teacher?.User?.Lastname,

						AbsenceDate = absence.Checkingtime
					};
					await _mailSender.AbsenceEmailAsync(absenceEmail);
					//Absence email Notification add here after checks that parent email is valid
				}
			}
			catch (Exception)
			{

			}
			//DynamicParameters emailParameters = new DynamicParameters(new
			//{
			//	ABSENCEID = parameters.Get<decimal>("ABSENCEID")
			//});
			//AbsenceEmail? absenceEmail = _dbContext.Connection.Query<AbsenceEmail>("ABSENCE_PACKAGE.GET_ABSENCE_INFO_EMAIL", emailParameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
			//MailSender mailSender = new MailSender(_mailCredentials);

			//await mailSender.AbsenceEmailAsync(absenceEmail);
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
