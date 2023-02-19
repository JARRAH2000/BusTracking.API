using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.Service
{
	public interface IUserService
	{
		User? GetUserById(int id);
		IEnumerable<User?> GetAllUsers();
		IEnumerable<User?> GetUserByRole(int roleId);
		IEnumerable<User?> GetUserByFirstName(string firstName);
		IEnumerable<User?> GetUserByMiddleName(string middleName);
		IEnumerable<User?> GetUserByLastName(string lastName);
		IEnumerable<User?> GetUserBySex(char gender);
		IEnumerable<User?> GetUserByBirthDate(DateTime? birthDate);
		IEnumerable<User?> GetUserByBirthDateInterval(DateInterval birthDateInterval);
		int CreateUser(User user);
		void UpdateUser(User user);
		void DeleteUser(int id);
	}
}
