using BusTracking.Core.Common;
using BusTracking.Core.Data;
using BusTracking.Core.Repository;
using BusTracking.Infra.Common;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace BusTracking.Infra.Repository
{
	public class ContactRepository:IContactRepository
	{
		private readonly IDbContext _dbContext;
		public ContactRepository(IDbContext dbContext) 
		{
			_dbContext = dbContext;
		}
		public IEnumerable<Contact?> GetAllContacts()
		{
			return _dbContext.Connection.Query<Contact?>("CONTACT_PACKAGE.GET_ALL_CONTACTS", commandType: CommandType.StoredProcedure);
		}
		public Contact? GetContactById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { CONTACTID = id });
			return _dbContext.Connection.Query<Contact?>("CONTACT_PACKAGE.GET_CONTACT_BY_ID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
		}
		public void CreateContact(Contact contact)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				MAIL = contact.Email,
				TOPLINE = contact.Title,
				MSG = contact.Message,
				SENDER = contact.Name,
				STIME = contact.Sendtime
			});
			_dbContext.Connection.Execute("CONTACT_PACKAGE.CREATE_CONTACT", parameters, commandType: CommandType.StoredProcedure);
		}
		public void DeleteContactById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { CONTACTID = id });
			_dbContext.Connection.Execute("CONTACT_PACKAGE.DELETE_CONTACT", parameters, commandType: CommandType.StoredProcedure);
		}
	}
}
