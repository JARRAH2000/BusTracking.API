using BusTracking.Core.Common;
using BusTracking.Core.Data;
using BusTracking.Core.Repository;
using Dapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Security.Cryptography;

namespace BusTracking.Infra.Repository
{
	public class NotificationRepository:INotificationRepository
	{
		private readonly IDbContext _dbContext;
		public NotificationRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IEnumerable<Notification?> GetAllNotifications()
		{
			return _dbContext.Connection.Query<Notification?>("NOTIFICATION_PACKAGE.GET_ALL_NOTIFICATION", commandType: CommandType.StoredProcedure).ToList();
		}
		public Notification? GetNotificationById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { NOTID = id });
			return _dbContext.Connection.Query<Notification?>("NOTIFICATION_PACKAGE.GET_NOTIFICATION_BY_ID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
		}
		public void CreateNotification(Notification notification)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				SENDTIM = notification.Sendtime,
				MESSAG = notification.Message,
				STUDENTI = notification.Studentid,
				TRIPI = notification.Tripid
			});
			_dbContext.Connection.Execute("NOTIFICATION_PACKAGE.CREATE_NOTIFICATION", parameters, commandType: CommandType.StoredProcedure);
		}
		public void UpdateNotification(Notification notification)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				NOTID = notification.Id,
				SENDTIM = notification.Sendtime,
				MESSAG = notification.Message,
				STUDENTI = notification.Studentid,
				TRIPI = notification.Tripid
			});
			_dbContext.Connection.Execute("NOTIFICATION_PACKAGE.UPDATE_NOTIFICATION", parameters, commandType: CommandType.StoredProcedure);
		}
		public void DeleteNotification(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { NOTID = id });
			_dbContext.Connection.Execute("NOTIFICATION_PACKAGE.DELETE_NOTIFICATION", parameters, commandType: CommandType.StoredProcedure);
		}
	}
}
