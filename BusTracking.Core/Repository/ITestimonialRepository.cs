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
        IEnumerable<Testimonial?> GetAllTestimonials();
        IEnumerable<Testimonial?> GetPublishedTestimonials();
        IEnumerable<Testimonial?> GetUnPublishedTestimonials();
        Testimonial? GetTestimonialById(int id);
        void CreateTestimonial(Testimonial testimonial);
        void UpdateTestimonial(Testimonial testimonial);
        void DeleteTestimonial(int id);
	}
}
