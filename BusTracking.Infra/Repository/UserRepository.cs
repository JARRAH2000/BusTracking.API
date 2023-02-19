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
using System.Reflection;
using BusTracking.Core.DTO;

namespace BusTracking.Infra.Repository
{
	public class UserRepository:IUserRepository
	{
		private readonly IDbContext _dbContext;
		public UserRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public User? GetUserById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { UID = id });
			return _dbContext.Connection.Query<User?>("USER_PACKAGE.GET_USER_BY_ID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
		}
		public IEnumerable<User?> GetAllUsers()
		{
			return _dbContext.Connection.Query<User?>("USER_PACKAGE.GET_ALL_USERS", commandType: CommandType.StoredProcedure).ToList();
		}
		public IEnumerable<User?> GetUserByRole(int roleId)
		{
			DynamicParameters parameters = new DynamicParameters(new { RID = roleId });
			return _dbContext.Connection.Query<User?>("USER_PACKAGE.GET_USERS_BY_ROLE", parameters, commandType: CommandType.StoredProcedure).ToList();
		}
		public IEnumerable<User?> GetUserByFirstName(string firstName)
		{
			DynamicParameters parameters = new DynamicParameters(new { FNAME = firstName });
			return _dbContext.Connection.Query<User?>("USER_PACKAGE.GET_USERS_BY_FIRSTNAME", parameters, commandType: CommandType.StoredProcedure).ToList();
		}
		public IEnumerable<User?> GetUserByMiddleName(string middleName)
		{
			DynamicParameters parameters = new DynamicParameters(new { MNAME = middleName });
			return _dbContext.Connection.Query<User?>("USER_PACKAGE.GET_USERS_BY_MIDDLENAME", parameters, commandType: CommandType.StoredProcedure).ToList();
		}
		public IEnumerable<User?> GetUserByLastName(string lastName)
		{
			DynamicParameters parameters = new DynamicParameters(new { LNAME = lastName });
			return _dbContext.Connection.Query<User?>("USER_PACKAGE.GET_USERS_BY_LASTNAME", parameters, commandType: CommandType.StoredProcedure).ToList();
		}
		public IEnumerable<User?> GetUserBySex(char gender)
		{
			DynamicParameters parameters = new DynamicParameters(new { GENDER = gender });
			return _dbContext.Connection.Query<User?>("USER_PACKAGE.GET_USERS_BY_SEX", parameters, commandType: CommandType.StoredProcedure).ToList();
		}
		public IEnumerable<User?> GetUserByBirthDate(DateTime? birthDate)
		{
			DynamicParameters parameters = new DynamicParameters(new { BIRTH = birthDate });
			return _dbContext.Connection.Query<User?>("USER_PACKAGE.GET_USERS_BY_BIRTHDATE", parameters, commandType: CommandType.StoredProcedure).ToList();
		}
		public IEnumerable<User?> GetUserByBirthDateInterval(DateInterval birthDateInterval)
		{
			DynamicParameters parameters = new DynamicParameters(new { FROMBIRTH = birthDateInterval.From, TOBIRTH = birthDateInterval.To });
			return _dbContext.Connection.Query<User?>("USER_PACKAGE.GET_USERS_BY_BIRTHDATE_INTERVAL", parameters, commandType: CommandType.StoredProcedure).ToList();
		}
		public int CreateUser(User user)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				FNAME = user.Firstname,
				MNAME = user.Middlename,
				LNAME = user.Lastname,
				PNUMBER = user.Phone,
				IMG = user.Image,
				BIRTH = user.Birthdate,
				GENDER = user.Sex,
				RID = user.Roleid,
				UID = user.Id
			});
			_dbContext.Connection.Execute("USER_PACKAGE.CREATE_USER", parameters, commandType: CommandType.StoredProcedure);
			return (int)parameters.Get<decimal>("UID");
		}
		public void UpdateUser(User user)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				UID = user.Id,
				FNAME = user.Firstname,
				MNAME = user.Middlename,
				LNAME = user.Lastname,
				PNUMBER = user.Phone,
				IMG = user.Image
			});
			_dbContext.Connection.Execute("USER_PACKAGE.UPDATE_USER", parameters, commandType: CommandType.StoredProcedure);
		}
		public void DeleteUser(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { UID = id });
			_dbContext.Connection.Execute("USER_PACKAGE.DELETE_USER", parameters, commandType: CommandType.StoredProcedure);
		}
	}
}
