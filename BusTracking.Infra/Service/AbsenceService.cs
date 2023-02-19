using BusTracking.Core.Repository;
using BusTracking.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Infra.Service
{
	public class AbsenceService:IAbsenceService
	{
		private readonly IAbsenceRepository _absenceRepository;
		public AbsenceService(IAbsenceRepository absenceRepository)
		{
			_absenceRepository = absenceRepository;
		}
	}
}
