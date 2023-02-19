using BusTracking.Core.Common;
using BusTracking.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Infra.Repository
{
	public class TripStudentRepository:ITripStudentRepository
	{
		private readonly IDbContext _dbContext;
		public TripStudentRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
	}
}
