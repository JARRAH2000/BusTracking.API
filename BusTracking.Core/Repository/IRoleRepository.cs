using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Data;
namespace BusTracking.Core.Repository
{
	public interface IRoleRepository
	{
		Role? GetRoleById(int id);
		IEnumerable<Role?> GetRoleByName(string name);
		IEnumerable<Role?> GetAllRoles();
		int CreateRole(Role role);
		void UpdateRole(Role role);
		void DeleteRole(int id);
	}
}
