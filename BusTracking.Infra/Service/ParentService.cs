using BusTracking.Core.Data;
using BusTracking.Core.Repository;
using BusTracking.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Infra.Service
{
	public class ParentService:IParentService
	{
		private readonly IParentRepository _parentRepository;
		public ParentService(IParentRepository parentRepository)
		{
			_parentRepository = parentRepository;
		}
		public async Task<IEnumerable<Parent?>> GetAllParents()
		{
			return await _parentRepository.GetAllParents();
		}
		public Parent? GetParentById(int id)
		{
			return _parentRepository.GetParentById(id);
		}

		public async Task<Parent?> GetParentAndStudentsById(int id)
		{
			return await _parentRepository.GetParentAndStudentsById(id);
		}
		public int CreateParent(Parent parent)
		{
			return _parentRepository.CreateParent(parent);
		}
		public void DeleteParent(int id)
		{
			_parentRepository.DeleteParent(id);
		}
		public IEnumerable<Parent?> GetParentByName(string pName)
		{
			return _parentRepository.GetParentByName(pName);
		}
		public async Task<Parent?> GetParentByUserId(int userId)
		{
			return await _parentRepository.GetParentByUserId(userId);
		}
	}
}
