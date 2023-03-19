using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusTracking.Core.Data;
namespace BusTracking.Core.Repository
{
	public interface ITestimonialRepository
	{
        Task<IEnumerable<Testimonial?>> GetAllTestimonials();
        Task<IEnumerable<Testimonial?>> GetPublishedTestimonials();
        Task<IEnumerable<Testimonial?>> GetUnPublishedTestimonials();
        Task<Testimonial?> GetTestimonialById(int id);
        void CreateTestimonial(Testimonial testimonial);
        void UpdateTestimonial(Testimonial testimonial);
        void DeleteTestimonial(int id);
	}
}
