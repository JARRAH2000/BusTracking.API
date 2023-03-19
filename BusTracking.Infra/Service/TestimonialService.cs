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
	public class TestimonialService:ITestimonialService
	{
		private readonly ITestimonialRepository _testimonialRepository;
		public TestimonialService(ITestimonialRepository testimonialRepository)
		{
			_testimonialRepository = testimonialRepository;
		}
		public async Task<IEnumerable<Testimonial?>> GetAllTestimonials()
		{
			return await _testimonialRepository.GetAllTestimonials();
		}
		public async Task<IEnumerable<Testimonial?>> GetPublishedTestimonials()
		{
			return await _testimonialRepository.GetPublishedTestimonials();
		}
		public async Task<IEnumerable<Testimonial?>> GetUnPublishedTestimonials()
		{
			return await _testimonialRepository.GetUnPublishedTestimonials();
		}
		public async Task<Testimonial?> GetTestimonialById(int id)
		{
			return await _testimonialRepository.GetTestimonialById(id);
		}
		public void CreateTestimonial(Testimonial testimonial)
		{
			_testimonialRepository.CreateTestimonial(testimonial);
		}
		public void UpdateTestimonial(Testimonial testimonial)
		{
			_testimonialRepository.UpdateTestimonial(testimonial);
		}
		public void DeleteTestimonial(int id)
		{
			_testimonialRepository.DeleteTestimonial(id);
		}
	}
}
