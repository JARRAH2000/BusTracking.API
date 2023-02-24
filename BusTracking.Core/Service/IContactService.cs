using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.Service
{
	public interface IContactService
	{
		IEnumerable<Contact?> GetAllContacts();
		Contact? GetContactById(int id);
		void CreateContact(Contact contact);
		void DeleteContactById(int id);
	}
}
