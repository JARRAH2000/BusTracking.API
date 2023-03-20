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
using System.Security.Cryptography;

namespace BusTracking.Infra.Repository
{
	public class ParentRepository:IParentRepository
	{
		private readonly IDbContext _dbContext;
		public ParentRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<IEnumerable<Parent?>> GetAllParents()
		{
			return await _dbContext.Connection.QueryAsync<Parent?, User?, Parent?>("PARENT_PACKAGE.GET_ALL_PARENTS", (parent, user) =>
			{
				if (parent == null) return parent;
				parent.User = user;
				if (parent.User != null) parent.User.Logins = _dbContext.Connection.Query<Login>("LOGIN_PACKAGE.GET_EMAIL_BY_USER_ID", new DynamicParameters(new { UID = parent.Userid }), commandType: CommandType.StoredProcedure).ToList();
				return parent;
			}, splitOn: "Id", commandType: CommandType.StoredProcedure);
		}
		public Parent? GetParentById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { PARENTID = id });
			return _dbContext.Connection.Query<Parent?>("PARENT_PACKAGE.GET_PARENT_BY_ID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
		}

		public async Task<Parent?> GetParentAndStudentsById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { PARID = id });
			IEnumerable<Parent> parents = await _dbContext.Connection.QueryAsync<Parent, Student, Parent>("PARENT_PACKAGE.GET_PARENT_AND_STUDENTS_BY_ID", (parent, student) =>
			{
				parent.Students.Add(student);
				return parent;
			},
			splitOn: "Id",
			param: parameters,
			commandType: CommandType.StoredProcedure
			);
			IEnumerable<Parent> parent = parents.GroupBy(p => p.Id).Select(father =>
			{
				Parent dad = father.First();
				DynamicParameters userParameter = new DynamicParameters(new { UID = dad.Userid });
				dad.User = _dbContext.Connection.Query<User>("USER_PACKAGE.GET_USER_BY_ID", userParameter, commandType: CommandType.StoredProcedure).FirstOrDefault();
				dad.Students = father.Select(f => f.Students.Single()).ToList();
				return dad;
			});
			return parent.FirstOrDefault();
		}

		public int CreateParent(Parent parent)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				UID = parent.Userid,
				PARENTID = parent.Id
			});
			_dbContext.Connection.Execute("PARENT_PACKAGE.CREATE_PARENT", parameters, commandType: CommandType.StoredProcedure);
			return (int)parameters.Get<decimal>("PARENTID");
		}
		public void DeleteParent(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { PARENTID = id });
			_dbContext.Connection.Execute("PARENT_PACKAGE.DELETE_PARENT", parameters, commandType: CommandType.StoredProcedure);
		}
		public IEnumerable<Parent?> GetParentByName(string pName)
		{
			DynamicParameters parameters = new DynamicParameters(new { PNAME = pName });
			IEnumerable<Parent?> parents = _dbContext.Connection.Query<Parent?>("PARENT_PACKAGE.GET_PARENT_BY_NAME", parameters, commandType: CommandType.StoredProcedure);
			parents = parents.Select(p =>
			{
				if (p == null) return null;
				Parent parent = p;
				parent.User = _dbContext.Connection.Query<User?>("USER_PACKAGE.GET_USER_BY_ID", new DynamicParameters(new { UID = parent.Userid }), commandType: CommandType.StoredProcedure).FirstOrDefault();
				return parent;
			});
			return parents;
		}
	}
}
