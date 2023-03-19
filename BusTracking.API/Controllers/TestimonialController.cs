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
		public async Task<IEnumerable<Testimonial?>> GetAllTestimonials()
		{
			return await _testimonialService.GetAllTestimonials();
		}
		[HttpGet("GetPublishedTestimonials")]
		public async Task<IEnumerable<Testimonial?>> GetPublishedTestimonials()
		{
			return await _testimonialService.GetPublishedTestimonials();
		}
		[HttpGet("GetUnPublishedTestimonials")]
		public async Task<IEnumerable<Testimonial?>> GetUnPublishedTestimonials()
		{
			return await _testimonialService.GetUnPublishedTestimonials();
		}
		[HttpGet("GetTestimonialById/{id}")]
		public async Task<Testimonial?> GetTestimonialById(int id)
		{
			return await _testimonialService.GetTestimonialById(id);
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