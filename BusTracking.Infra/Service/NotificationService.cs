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
	}
}
