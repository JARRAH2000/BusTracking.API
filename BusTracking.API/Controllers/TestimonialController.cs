using BusTracking.Core.Data;
using BusTracking.Core.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BusTracking.API.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class TestimonialController : ControllerBase
	{
		private readonly ITestimonialService _testimonialService;
		public TestimonialController(ITestimonialService testimonialService)
		{
			_testimonialService = testimonialService;
		}
		[HttpGet("GetAllTestimonials")]
		public IEnumerable<Testimonial?> GetAllTestimonials()
		{
			return _testimonialService.GetAllTestimonials();
		}
		[HttpGet("GetPublishedTestimonials")]
		public IEnumerable<Testimonial?> GetPublishedTestimonials()
		{
			return _testimonialService.GetPublishedTestimonials();
		}
		[HttpGet("GetUnPublishedTestimonials")]
		public IEnumerable<Testimonial?> GetUnPublishedTestimonials()
		{
			return _testimonialService.GetUnPublishedTestimonials();
		}
		[HttpGet("GetTestimonialById/{id}")]
		public Testimonial? GetTestimonialById(int id)
		{
			return _testimonialService.GetTestimonialById(id);
		}
		[HttpPost("CreateTestimonial")]
		public void CreateTestimonial(Testimonial testimonial)
		{
			_testimonialService.CreateTestimonial(testimonial);
		}
		[HttpPut("UpdateTestimonial")]
		public void UpdateTestimonial(Testimonial testimonial)
		{
			_testimonialService.UpdateTestimonial(testimonial);
		}
		[HttpDelete("DeleteTestimonial/{id}")]
		public void DeleteTestimonial(int id)
		{
			_testimonialService.DeleteTestimonial(id);
		}
	}
}