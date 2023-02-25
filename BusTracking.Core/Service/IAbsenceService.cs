using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Data;
namespace BusTracking.Core.Service
{
	public interface IAbsenceService
	{
		IEnumerable<Absence?> GetAllAbsences();
		Absence? GetAbsenceById(int id);
		Task CreateAbsence(Absence absence);
		void UpdateAbsence(Absence absence);
		void DeleteAbsence(int id);
	}
}
