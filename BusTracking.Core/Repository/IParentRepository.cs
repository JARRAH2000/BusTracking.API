using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Data;
namespace BusTracking.Core.Repository
{
	public interface IParentRepository
	{
		IEnumerable<Parent?> GetAllParents();
		Parent? GetParentById(int id);

		Task<Parent?> GetParentAndStudentsById(int id);
		int CreateParent(Parent parent);
		void DeleteParent(int id);
	}
}
