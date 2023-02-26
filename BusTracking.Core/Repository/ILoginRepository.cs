using BusTracking.Core.Data;
using BusTracking.Core.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.Repository
{
	public interface ILoginRepository
	{
		JWTPayload? VerifyinLogin(Login login);
		Task CreateLogin(Login login);
		void UpdateLogin(UpdateLoginData loginData);
		void DeleteLogin(int userId);
    }
}
