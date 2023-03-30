using BusTracking.Core.Data;
using BusTracking.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ParentController : ControllerBase
	{
		private readonly IParentService _parentService;
		public ParentController(IParentService parentService)
		{
			_parentService = parentService;
		}
		[HttpGet("GetAllParents")]
		public async Task<IEnumerable<Parent?>> GetAllParents()
		{
			return await _parentService.GetAllParents();
		}
		[HttpGet("GetParentById/{id}")]
		public Parent? GetParentById(int id)
		{
			return _parentService.GetParentById(id);
		}
		[HttpGet("GetParentAndStudentsById/{id}")]
		public async Task<Parent?> GetParentAndStudentsById(int id)
		{
			return await _parentService.GetParentAndStudentsById(id);
		}
		[HttpPost("CreateParent")]
		public int CreateParent(Parent parent)
		{
			return _parentService.CreateParent(parent);
		}
		[HttpDelete("DeleteParent/{id}")]
		public void DeleteParent(int id)
		{
			_parentService.DeleteParent(id);
		}
		[HttpGet("GetParentByName/{pName}")]
		public IEnumerable<Parent?> GetParentByName(string pName)
		{
			return _parentService.GetParentByName(pName);
		}
		[HttpGet("GetParentByUserId/{userId}")]
		public async Task<Parent?> GetParentByUserId(int userId)
		{
			return await _parentService.GetParentByUserId(userId);
		}
	}
}
