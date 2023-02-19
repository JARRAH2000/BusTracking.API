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
	public class RoleService:IRoleService
	{
		private readonly IRoleRepository _roleRepository;
		public RoleService(IRoleRepository roleRepository)
		{
			_roleRepository = roleRepository;
		}
		public Role? GetRoleById(int id)
		{
			return _roleRepository.GetRoleById(id);
		}
		public IEnumerable<Role?> GetRoleByName(string name)
		{
			return _roleRepository.GetRoleByName(name);
		}
		public IEnumerable<Role?> GetAllRoles()
		{
			return _roleRepository.GetAllRoles();
		}
		public int CreateRole(Role role)
		{
			return _roleRepository.CreateRole(role);
		}
		public void UpdateRole(Role role)
		{
			_roleRepository.UpdateRole(role);
		}
		public void DeleteRole(int id)
		{
			_roleRepository.DeleteRole(id);
		}
	}
}
