using BusTracking.Core.Data;
using BusTracking.Core.Repository;
using BusTracking.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Infra.Service
{
	public class ContactService:IContactService
	{
		private readonly IContactRepository _contactRepository;
		public ContactService(IContactRepository contactRepository)
		{
			_contactRepository = contactRepository;
		}
		public IEnumerable<Contact?> GetAllContacts()
		{
			return _contactRepository.GetAllContacts();
		}
		public Contact? GetContactById(int id)
		{
			return _contactRepository.GetContactById(id);
		}
		public void CreateContact(Contact contact)
		{
			_contactRepository.CreateContact(contact);
		}
		public void DeleteContactById(int id)
		{
			_contactRepository.DeleteContactById(id);
		}
	}
}
