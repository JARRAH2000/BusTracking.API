using BusTracking.Core.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Service;
namespace BusTracking.Infra.Service
{
	public class TripStudentService:ITripStudentService
	{
		private readonly ITripStudentRepository _tripStudentRepository;
		public TripStudentService(ITripStudentRepository tripStudentRepository)
		{
			_tripStudentRepository = tripStudentRepository;
		}
	}
}
