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
		public IEnumerable<Testimonial?> GetAllTestimonials()
		{
			return _testimonialRepository.GetAllTestimonials();
		}
		public async Task<IEnumerable<Testimonial?>> GetPublishedTestimonials()
		{
			return await _testimonialRepository.GetPublishedTestimonials();
		}
		public IEnumerable<Testimonial?> GetUnPublishedTestimonials()
		{
			return _testimonialRepository.GetUnPublishedTestimonials();
		}
		public Testimonial? GetTestimonialById(int id)
		{
			return _testimonialRepository.GetTestimonialById(id);
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
