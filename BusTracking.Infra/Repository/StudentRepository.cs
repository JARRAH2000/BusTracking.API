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

namespace BusTracking.Infra.Repository
{
	public class StudentRepository:IStudentRepository
	{
		private readonly IDbContext _dbContext;
		public StudentRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IEnumerable<Student?> GetAllStudents()
		{
			return _dbContext.Connection.Query<Student?>("STUDENT_PACKAGE.GET_ALL_STUDENTS", commandType: CommandType.StoredProcedure).ToList();
		}
		public Student? GetStudentById(int id)
		{
			DynamicParameters parameters=new DynamicParameters(new { STUDENTID =id});
			return _dbContext.Connection.Query<Student?>("STUDENT_PACKAGE.GET_STUDENT_BY_ID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
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
		public void DeleteStudent(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { STUDENTID = id });
			_dbContext.Connection.Execute("STUDENT_PACKAGE.DELETE_STUDENT", parameters, commandType: CommandType.StoredProcedure);
		}
	}
}
