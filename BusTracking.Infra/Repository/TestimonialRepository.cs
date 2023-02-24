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
using System.Reflection;
using System.Security.Policy;

namespace BusTracking.Infra.Repository
{
	public class TestimonialRepository:ITestimonialRepository
	{
		private readonly IDbContext _dbContext;
		public TestimonialRepository(IDbContext dbContext) 
		{
			_dbContext = dbContext;
		}
		public IEnumerable<Testimonial?> GetAllTestimonials()
		{
			return _dbContext.Connection.Query<Testimonial?>("TESTIMONIAL_PACKAGE.GET_ALL_TESTIMONIALS", commandType: CommandType.StoredProcedure).ToList();
		}
		public IEnumerable<Testimonial?> GetPublishedTestimonials()
		{
			return _dbContext.Connection.Query<Testimonial?>("TESTIMONIAL_PACKAGE.GET_PUBLISHED_TESTIMONIALS", commandType: CommandType.StoredProcedure);
		}
		public IEnumerable<Testimonial?> GetUnPublishedTestimonials()
		{
			return _dbContext.Connection.Query<Testimonial?>("TESTIMONIAL_PACKAGE.GET_UNPUBLISHED_TESTIMONIALS", commandType: CommandType.StoredProcedure);
		}
		public Testimonial? GetTestimonialById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { TESTID = id });
			return _dbContext.Connection.Query<Testimonial?>("TESTIMONIAL_PACKAGE.GET_TESTIMONIAL_BY_ID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
		}
		public void CreateTestimonial(Testimonial testimonial)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				MSG = testimonial.Message,
				SENDER = testimonial.Parentid
			});
			_dbContext.Connection.Execute("TESTIMONIAL_PACKAGE.CREATE_TESTIMONIAL", parameters, commandType: CommandType.StoredProcedure);
		}
		public void UpdateTestimonial(Testimonial testimonial)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				TESTID = testimonial.Id,
				PUBLISH = testimonial.Published
			});
			_dbContext.Connection.Execute("TESTIMONIAL_PACKAGE.UPDATE_TESTIMONIAL", parameters, commandType: CommandType.StoredProcedure);
		}
		public void DeleteTestimonial(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { TESTID = id });
			_dbContext.Connection.Execute("TESTIMONIAL_PACKAGE.DELETE_TESTIMONIAL", parameters, commandType: CommandType.StoredProcedure);
		}
	}
}