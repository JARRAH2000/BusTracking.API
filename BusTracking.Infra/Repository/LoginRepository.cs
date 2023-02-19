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
using BusTracking.Core.DTO;

namespace BusTracking.Infra.Repository
{
	public class LoginRepository:ILoginRepository
	{
		private readonly IDbContext _dbContext;
		public LoginRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public Login? VerifyinLogin(Login login)
		{
			//JWT must be add in service layer for this method
			DynamicParameters parameters = new DynamicParameters(new { USERNAME = login.Email, SECRET = login.Password });
			return _dbContext.Connection.Query<Login>("LOGIN_PACKAGE.VERIFYING_LOGIN", parameters, commandType: CommandType.StoredProcedure).SingleOrDefault();
		}
		public void CreateLogin(Login login)
		{
			DynamicParameters parameters = new DynamicParameters(new { USERNAME = login.Email, SECRET = login.Password, UID = login.Userid });
			try
			{ 
				_dbContext.Connection.Execute("LOGIN_PACKAGE.CREATE_LOGIN", parameters, commandType: CommandType.StoredProcedure);
			}
			catch (Exception)
			{
				//exception will be thrown if unique constraint is violated
			}
		}
		public void UpdateLogin(UpdateLoginData loginData)
		{
			DynamicParameters parameters = new DynamicParameters(new { USERNAME = loginData.UserName, OLDPASSWORD = loginData.OldPassword, NEWPASSWORD = loginData.NewPassword });
			_dbContext.Connection.Execute("LOGIN_PACKAGE.UPDATE_LOGIN", parameters, commandType: CommandType.StoredProcedure);
		}
		public void DeleteLogin(int userId)
		{
			DynamicParameters parameters = new DynamicParameters(new { UID = userId });
			_dbContext.Connection.Execute("LOGIN_PACKAGE.DELETE_LOGIN", parameters, commandType: CommandType.StoredProcedure);	
		}
	}
}
