using BusTracking.Core.Data;
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
		public IEnumerable<Absence?> GetAllAbsences()
		{
			return _absenceRepository.GetAllAbsences();
		}
		public Absence? GetAbsenceById(int id)
		{
			return _absenceRepository.GetAbsenceById(id);
		}
		public Task CreateAbsence(Absence absence)
		{
			return _absenceRepository.CreateAbsence(absence);
		}
		public void UpdateAbsence(Absence absence)
		{
			_absenceRepository.UpdateAbsence(absence);
		}
		public void DeleteAbsence(int id)
		{
			_absenceRepository.DeleteAbsence(id);
		}
	}
}
