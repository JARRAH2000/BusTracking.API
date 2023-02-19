using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using BusTracking.Core.Repository;
using BusTracking.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Infra.Service
{
	public class UserService:IUserService
	{
		private readonly IUserRepository _userRepository;
		public UserService(IUserRepository userRepository)
		{
			_userRepository = userRepository;
		}
		public User? GetUserById(int id)
		{
			return _userRepository.GetUserById(id);
		}
		public IEnumerable<User?> GetAllUsers()
		{
			return _userRepository.GetAllUsers();
		}
		public IEnumerable<User?> GetUserByRole(int roleId)
		{
			return _userRepository.GetUserByRole(roleId);
		}
		public IEnumerable<User?> GetUserByFirstName(string firstName)
		{
			return _userRepository.GetUserByFirstName(firstName);
		}
		public IEnumerable<User?> GetUserByMiddleName(string middleName)
		{
			return _userRepository.GetUserByMiddleName(middleName);
		}
		public IEnumerable<User?> GetUserByLastName(string lastName)
		{
			return _userRepository.GetUserByLastName(lastName);
		}
		public IEnumerable<User?> GetUserBySex(char gender)
		{
			return _userRepository.GetUserBySex(gender);
		}
		public IEnumerable<User?> GetUserByBirthDate(DateTime? birthDate)
		{
			return _userRepository.GetUserByBirthDate(birthDate);
		}
		public IEnumerable<User?> GetUserByBirthDateInterval(DateInterval birthDateInterval)
		{
			return _userRepository.GetUserByBirthDateInterval(birthDateInterval);
		}
		public int CreateUser(User user)
		{
			return _userRepository.CreateUser(user);
		}
		public void UpdateUser(User user)
		{
			_userRepository.UpdateUser(user);
		}
		public void DeleteUser(int id)
		{
			_userRepository.DeleteUser(id);
		}
	}
}
