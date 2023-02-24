using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BusTracking.Core.Service;
using BusTracking.Core.Data;

namespace BusTracking.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ContentController : ControllerBase
	{
		private readonly IContentService _contentService;
		public ContentController(IContentService contentService)
		{
			_contentService = contentService;
		}
		[HttpGet("GetAllContents")]
		public IEnumerable<Content?> GetAllContents()
		{
			return _contentService.GetAllContents();
		}
		[HttpPost("CreateContent")]
		public void CreateContent(Content content)
		{
			_contentService.CreateContent(content);
		}
		[HttpPut("UpdateContent")]
		public void UpdateContent(Content content)
		{
			_contentService.UpdateContent(content);
		}
	}
}
