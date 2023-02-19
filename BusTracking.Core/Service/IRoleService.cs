using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.Service
{
	public interface IRoleService
	{
		Role? GetRoleById(int id);
		IEnumerable<Role?> GetRoleByName(string name);
		IEnumerable<Role?> GetAllRoles();
		int CreateRole(Role role);
		void UpdateRole(Role role);
		void DeleteRole(int id);
	}
}
