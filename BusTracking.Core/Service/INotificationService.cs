using BusTracking.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusTracking.Core.Service
{
	public interface INotificationService
	{
		IEnumerable<Notification?> GetAllNotifications();
		Notification? GetNotificationById(int id);
		void CreateNotification(Notification notification);
		void UpdateNotification(Notification notification);
		void DeleteNotification(int id);
	}
}
