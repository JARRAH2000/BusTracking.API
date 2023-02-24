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
namespace BusTracking.Infra.Repository
{
	public class ContentRepository : IContentRepository
	{
		private readonly IDbContext _dbContext;
		public ContentRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public IEnumerable<Content?> GetAllContents()
		{
			return _dbContext.Connection.Query<Content?>("CONTENT_PACKAGE.GET_ALL_CONTENTS", commandType: CommandType.StoredProcedure).ToList();
		}
		public void CreateContent(Content content)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				AB = content.About,
				FACE = content.Facebook,
				MAIL = content.Email,
				TUBE = content.Youtube,
				PHONE = content.Telephone,
				LOGO = content.Mainlogo,
				GREET = content.Greeting,
				GRAPH = content.Paragraph
			});
			_dbContext.Connection.Execute("CONTENT_PACKAGE.CREATE_CONTENT", parameters, commandType: CommandType.StoredProcedure);
		}
		public void UpdateContent(Content content)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				CONTENTID = content.Id,
				AB = content.About,
				FACE = content.Facebook,
				MAIL = content.Email,
				TUBE = content.Youtube,
				PHONE = content.Telephone,
				LOGO = content.Mainlogo,
				GREET = content.Greeting,
				GRAPH = content.Paragraph
			});
			_dbContext.Connection.Execute("CONTENT_PACKAGE.UPDATE_CONTENT", parameters, commandType: CommandType.StoredProcedure);
		}
	}
}
