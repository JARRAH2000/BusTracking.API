using BusTracking.Core.Repository;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Common;
using System.Security.Permissions;

namespace BusTracking.Infra.Repository
{
	public class TripDirectionRepository:ITripDirectionRepository
	{
		private readonly IDbContext _dbContext;
		public TripDirectionRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
