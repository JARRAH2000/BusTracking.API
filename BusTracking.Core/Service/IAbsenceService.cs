using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Data;
using BusTracking.Core.DTO;
namespace BusTracking.Core.Service
{
	public interface IAbsenceService
	{
		IEnumerable<Absence?> GetAllAbsences();
		Absence? GetAbsenceById(int id);
		Task CreateAbsence(Absence absence);
		void UpdateAbsence(Absence absence);
		void DeleteAbsence(int id);
		IEnumerable<Absence?> GetAbsencesByDate(DateTime date);
		IEnumerable<Absence?> GetAbsencesByDateInterval(DateInterval dateInterval);
	}
}
