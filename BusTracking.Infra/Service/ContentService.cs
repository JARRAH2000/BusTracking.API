using BusTracking.Core.Data;
using BusTracking.Core.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Repository;
namespace BusTracking.Infra.Service
{
	public class ContentService:IContentService
	{
		private readonly IContentRepository _contentRepository;
		public ContentService(IContentRepository contentRepository)
		{
			_contentRepository = contentRepository;
		}
		public IEnumerable<Content?> GetAllContents()
		{
			return _contentRepository.GetAllContents();
		}
		public void CreateContent(Content content)
		{
			_contentRepository.CreateContent(content);
		}
		public void UpdateContent(Content content)
		{
			_contentRepository.UpdateContent(content);
		}
	}
}
