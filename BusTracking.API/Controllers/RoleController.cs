using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusTracking.Core.Service;
using BusTracking.Core.Data;
namespace BusTracking.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class RoleController : ControllerBase
	{
		private readonly IRoleService _roleService;
		public RoleController(IRoleService roleService)
		{
			_roleService = roleService;
		}
		[HttpGet("GetRoleById/{id}")]
		public Role? GetRoleById(int id)
		{
			return _roleService.GetRoleById(id);
		}

		[HttpGet("GetRoleByName/{name}")]
		public IEnumerable<Role?> GetRoleByName(string name) 
		{
			return _roleService.GetRoleByName(name);
		}

		[HttpGet("GetAllRoles")]
		public IEnumerable<Role?>GetAllRoles()
		{
			return _roleService.GetAllRoles();
		}

		[HttpPost("CreateRole")]
		public int CreateRole(Role role)
		{
			return _roleService.CreateRole(role);
		}

		[HttpPut("UpdateRole")]
		public void UpdateRole(Role role)
		{
			_roleService.UpdateRole(role);
		}

		[HttpDelete("DeleteRole/{id}")]
		public void DeleteRole(int id)
		{
			_roleService.DeleteRole(id);
		}
	}
}
