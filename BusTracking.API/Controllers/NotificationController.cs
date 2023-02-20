using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusTracking.Core.Service;
using BusTracking.Core.Data;

namespace BusTracking.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class NotificationController : ControllerBase
	{
		private readonly INotificationService _notificationService;
		public NotificationController(INotificationService notificationService)
		{
			_notificationService = notificationService;
		}
		[HttpGet("GetAllNotifications")]
		public IEnumerable<Notification?>GetAllNotifications()
		{
			return _notificationService.GetAllNotifications();
		}
		[HttpGet("GetNotificationById/{id}")]
		public Notification? GetNotificationById(int id)
		{
			return _notificationService.GetNotificationById(id);
		}
		[HttpPost("CreateNotification")]
		public void CreateNotification(Notification notification)
		{
			_notificationService.CreateNotification(notification);
		}
		[HttpPut("UpdateNotification")]
		public void UpdateNotification(Notification notification)
		{
			_notificationService.UpdateNotification(notification);
		}
		[HttpDelete("DeleteNotification/{id}")]
		public void DeleteNotification(int id)
		{
			_notificationService.DeleteNotification(id);
		}
	}
}
