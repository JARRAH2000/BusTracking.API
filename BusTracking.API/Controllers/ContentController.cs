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
		[HttpPost("UploadLogo")]
		public Content UploadLogo()
		{
			IFormFile formFile = Request.Form.Files[0];
			string fileName = Guid.NewGuid().ToString() + "_" + formFile.FileName;
			string fullPath = Path.Combine("C:/Users/user/Desktop/AngularProject/src/assets/Images", fileName);
			using (FileStream stream = new FileStream(fullPath, FileMode.Create))
			{
				formFile.CopyTo(stream);
			}
			return new Content { Mainlogo = fileName };
		}
	}
}
