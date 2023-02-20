using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Data;
namespace BusTracking.Core.Repository
{
	public interface INotificationRepository
	{
		IEnumerable<Notification?> GetAllNotifications();
		Notification? GetNotificationById(int id);
		void CreateNotification(Notification notification);
		void UpdateNotification(Notification notification);
		void DeleteNotification(int id);
	}
}
