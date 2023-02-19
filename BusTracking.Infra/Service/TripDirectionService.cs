using BusTracking.Core.Service;
using BusTracking.Infra.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Repository;
namespace BusTracking.Infra.Service
{
	public class TripDirectionService:ITripDirectionService
	{
		private readonly ITripDirectionRepository _tripDirectionRepository;
		public TripDirectionService(ITripDirectionRepository tripDirectionRepository)
		{
			_tripDirectionRepository = tripDirectionRepository;
		}
	}
}
