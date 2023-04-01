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
using System.Net.Http.Headers;
using System.Reflection;
using System.Security.Cryptography;
using System.Collections.ObjectModel;
using BusTracking.Core.Mail;
using BusTracking.Infra.Service;

namespace BusTracking.Infra.Repository
{
	public class StudentRepository:IStudentRepository
	{
		private readonly IDbContext _dbContext;
		private readonly IMailSender _mailSender;
		public StudentRepository(IDbContext dbContext,IMailSender mailSender)
		{
			_dbContext = dbContext;
			_mailSender = mailSender;
		}
		public async Task<IEnumerable<Student?>> GetAllStudents()
		{
			return await _dbContext.Connection.QueryAsync<Student?, Studentstatus?, Parent?, User?, Login?, Student?>("STUDENT_PACKAGE.GET_ALL_STUDENTS", (student, studentStatus, parent, user, login) =>
			{
				if (student == null) return student;
				student.Status = studentStatus;
				student.Parent = parent;
				if (student.Parent == null) return student;
				student.Parent.User = user;
				if (student.Parent.User != null && login != null)
					student.Parent.User.Logins = new List<Login> { login };
				return student;
			}, splitOn: "Id", commandType: CommandType.StoredProcedure);
			//return _dbContext.Connection.Query<Student?>("STUDENT_PACKAGE.GET_ALL_STUDENTS", commandType: CommandType.StoredProcedure).ToList();
		}
		public async Task<Student?> GetStudentById(int id)
		{
			DynamicParameters parameters=new DynamicParameters(new { STUDENTID =id});
			IEnumerable<Student?>students= await _dbContext.Connection.QueryAsync<Student?, Studentstatus?, Parent?, User?, Login?, Student?>("STUDENT_PACKAGE.GET_STUDENT_BY_ID", (student, studentStatus, parent, user, login) =>
			{
				if (student == null) return student;
				student.Status = studentStatus;
				student.Parent = parent;
				if (student.Parent == null) return student;
				student.Parent.User = user;
				if (student.Parent.User != null && login != null)
					student.Parent.User.Logins = new List<Login> { login };
				return student;
			}, splitOn: "Id",param:parameters, commandType: CommandType.StoredProcedure);
			return students.FirstOrDefault();
			//return _dbContext.Connection.Query<Student?>("STUDENT_PACKAGE.GET_STUDENT_BY_ID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
		}
		public async Task<Student?> GetStudentAbsenceById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { STUDID = id });
			IEnumerable<Student> students = await _dbContext.Connection.QueryAsync<Student, Absence,Teacher,User,Login, Student>("STUDENT_PACKAGE.GET_STUDENT_ABSENCE_BY_ID", (student, absence,teacher,user,login) =>
			{
				user.Logins = new List<Login> { login };
				teacher.User = user;
				absence.Teacher = teacher;
				student.Absences.Add(absence);
				return student;
			},
			splitOn: "Id",
			param: parameters,
			commandType: CommandType.StoredProcedure
			);
			students = students.GroupBy(s => s.Id).Select(student =>
			{
				Student std = student.First();
				std.Parent = _dbContext.Connection.Query<Parent?>("PARENT_PACKAGE.GET_PARENT_BY_ID", new DynamicParameters(new { PARENTID = std.Parentid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
				std.Status = _dbContext.Connection.Query<Studentstatus?>("STUDENTSTATUS_PACKAGE.GET_STUDENTSTATUS_BY_ID", new DynamicParameters(new { SSID = std.Statusid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
				std.Absences = student.Select(st => st.Absences.Single()).ToList();
				return std;
			});
			return students.FirstOrDefault();
		}
		public IEnumerable<Student> GetStudentByName(string stdName)
		{
			DynamicParameters parameters = new DynamicParameters(new { STDNAME = stdName });
			IEnumerable<Student> students = _dbContext.Connection.Query<Student>("STUDENT_PACKAGE.GET_STUDENT_BY_NAME", parameters, commandType: CommandType.StoredProcedure);
			students = students.Select(stud =>
			{
				Student student = stud;
				student.Parent = _dbContext.Connection.Query<Parent>("PARENT_PACKAGE.GET_PARENT_BY_ID", new DynamicParameters(new { PARENTID = stud.Parentid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
				if (stud.Parent != null)
					stud.Parent.User = _dbContext.Connection.Query<User?>("USER_PACKAGE.GET_USER_BY_ID", new DynamicParameters(new { UID = stud.Parent.Userid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
				return stud;
			});
			return students;
		}
		public int CreateStudent(Student student)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				SNAME = student.Name,
				IMG = student.Image,
				BIRTH = student.Birthdate,
				GENDER = student.Sex,
				LON = student.Longitude,
				LAT = student.Latitude,
				ABSENCENOTE = student.Absencenotify,
				BUSNOTE = student.Busnotify,
				INHOME = student.Inhomenotify,
				INSCHOOL = student.Inschoolnotify,
				TOHOME = student.Tohomenotify,
				TOSCHOOL = student.Toschoolnotify,
				PID = student.Parentid,
				STATID = student.Statusid,
				STUDENTID = student.Id
			});
			_dbContext.Connection.Execute("STUDENT_PACKAGE.CREATE_STUDENT", parameters, commandType: CommandType.StoredProcedure);
			return (int)parameters.Get<decimal>("STUDENTID");
		}
		public void UpdateStudent(Student student)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				SNAME = student.Name,
				IMG = student.Image,
				LON = student.Longitude,
				LAT = student.Latitude,
				ABSENCENOTE = student.Absencenotify,
				BUSNOTE = student.Busnotify,
				INHOME = student.Inhomenotify,
				INSCHOOL = student.Inschoolnotify,
				TOHOME = student.Tohomenotify,
				TOSCHOOL = student.Toschoolnotify,
				STATID = student.Statusid,
				STUDENTID = student.Id
			});
			_dbContext.Connection.Execute("STUDENT_PACKAGE.UPDATE_STUDENT", parameters, commandType: CommandType.StoredProcedure);
		}
		public async Task UpdateStudentStatusInTrip(Student student)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				STUDENTID = student.Id,
				STATE = student.Statusid,
				CURTRIP = student.Currenttrip
			});
			_dbContext.Connection.Execute("STUDENT_PACKAGE.UPDATE_STUDENT_STATUS", parameters, commandType: CommandType.StoredProcedure);
			
			
			DynamicParameters param = new DynamicParameters(new { STUDENTID = student.Id });
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

			//if (students == null || !students.Any() || students.FirstOrDefault()?.Parent?.User?.Logins?.FirstOrDefault() == null) return;

			User? parentUser = students.FirstOrDefault()?.Parent?.User;
			string? studentName = students.FirstOrDefault()?.Name;

			if (parentUser?.Logins?.FirstOrDefault()?.Email == null) return;
			if (student.Statusid == 1)
			{
				//In home email
				await _mailSender.SendEmailAsync(parentUser?.Logins?.FirstOrDefault()?.Email, "Student In Home", $"{(parentUser?.Sex == "M" ? "Mr" : "Ms")} {parentUser?.Firstname}, your son: {studentName} is in Home now");

			}
			else if (student.Statusid == 21)
			{
				//In school email
				await _mailSender.SendEmailAsync(parentUser?.Logins?.FirstOrDefault()?.Email, "Student In School", $"{(parentUser?.Sex == "M" ? "Mr" : "Ms")} {parentUser?.Firstname}, your son: {studentName} is in School now");

			}
			else if (student.Statusid == 22 )
			{
				//To home email
				await _mailSender.SendEmailAsync(parentUser?.Logins?.FirstOrDefault()?.Email, "Student coming to Home", $"{(parentUser?.Sex == "M" ? "Mr" : "Ms")} {parentUser?.Firstname}, your son: {studentName} is coming to Home now");

			}
			else if (student.Statusid == 23)
			{
				//To school email
				await _mailSender.SendEmailAsync(parentUser?.Logins?.FirstOrDefault()?.Email, "Student coming to School", $"{(parentUser?.Sex == "M" ? "Mr" : "Ms")} {parentUser?.Firstname}, your son: {studentName} is coming to School now");

			}
			else if (student.Statusid == 24 )
			{
				//absence email
				await _mailSender.SendEmailAsync(parentUser?.Logins?.FirstOrDefault()?.Email, "Student Absence", $"{(parentUser?.Sex == "M" ? "Mr" : "Ms")} {parentUser?.Firstname}, your son: {studentName} will be considered as absent unless he comes to school before absence counting time");

			}
			else if (student.Statusid == 25 )
			{
				//bus email
				await _mailSender.SendEmailAsync(parentUser?.Logins?.FirstOrDefault()?.Email, "Bus is coming", $"{(parentUser?.Sex == "M" ? "Mr" : "Ms")} {parentUser?.Firstname},school bus is coming for take your son: {studentName} is to school");

			}
		}
		public void DeleteStudent(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { STUDENTID = id });
			_dbContext.Connection.Execute("STUDENT_PACKAGE.DELETE_STUDENT", parameters, commandType: CommandType.StoredProcedure);
		}


		public async Task<IEnumerable<Student?>> GetAllAbsentStudents()
		{
			return await _dbContext.Connection.QueryAsync<Student?, Parent?, User?, Login?, Student?>("STUDENT_PACKAGE.GET_ALL_ABSENT_STUDENTS", (student, parent, user, login) =>
			{
				if (student == null) return student;
				if (login != null && user != null) user.Logins = new List<Login> { login };
				if (parent != null) parent.User = user;
				if (parent != null) student.Parent = parent;
				return student;
			}, splitOn: "Id", commandType: CommandType.StoredProcedure);
		}

	}
}
