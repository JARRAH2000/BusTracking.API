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
	public class NotificationService:INotificationService
	{
		private readonly INotificationRepository _notificationRepository;
		public NotificationService(INotificationRepository notificationRepository)
		{
			_notificationRepository = notificationRepository;
		}
		public IEnumerable<Notification?> GetAllNotifications()
		{
			return _notificationRepository.GetAllNotifications();
		}
		public Notification? GetNotificationById(int id)
		{
			return _notificationRepository.GetNotificationById(id);
		}
		public void CreateNotification(Notification notification)
		{
			_notificationRepository.CreateNotification(notification);
		}
		public void UpdateNotification(Notification notification)
		{
			_notificationRepository.UpdateNotification(notification);
		}
		public void DeleteNotification(int id)
		{
			_notificationRepository.DeleteNotification(id);
		}
	}
}
