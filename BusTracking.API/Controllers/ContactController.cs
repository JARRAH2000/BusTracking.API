using BusTracking.Core.Data;
using BusTracking.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContactController : ControllerBase
	{
		private readonly IContactService _contactService;
		public ContactController(IContactService contactService)
		{
			_contactService = contactService;
		}
		[HttpGet("GetAllContacts")]
		public IEnumerable<Contact?> GetAllContacts()
		{
			return _contactService.GetAllContacts();
		}
		[HttpGet("GetContactById/{id}")]
		public Contact? GetContactById(int id)
		{
			return _contactService.GetContactById(id);
		}
		[HttpPost("CreateContact")]
		public void CreateContact(Contact contact)
		{
			_contactService.CreateContact(contact);
		}
		[HttpPut("UpdateContact")]
		public void DeleteContactById(int id)
		{
			_contactService.DeleteContactById(id);
		}
	}
}
