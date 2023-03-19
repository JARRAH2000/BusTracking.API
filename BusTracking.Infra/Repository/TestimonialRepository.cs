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
using System.Configuration;

namespace BusTracking.Infra.Repository
{
	public class TestimonialRepository : ITestimonialRepository
	{
		private readonly IDbContext _dbContext;
		public TestimonialRepository(IDbContext dbContext)
		{
			_dbContext = dbContext;
		}
		public async Task<IEnumerable<Testimonial?>> GetAllTestimonials()
		{
			return await _dbContext.Connection.QueryAsync<Testimonial?, User?, Testimonial?>("TESTIMONIAL_PACKAGE.GET_ALL_TESTIMONIALS", (testimonial, user) =>
			{
				if (testimonial != null)
					testimonial.User = user;
				return testimonial;
			}, splitOn: "Id", commandType: CommandType.StoredProcedure);
		}
		public async Task<IEnumerable<Testimonial?>> GetPublishedTestimonials()
		{
			return await _dbContext.Connection.QueryAsync<Testimonial?, User?, Testimonial?>("TESTIMONIAL_PACKAGE.GET_PUBLISHED_TESTIMONIALS", (testimonial, user) =>
			{
				if (testimonial != null)
					testimonial.User = user;
				return testimonial;
			}, splitOn: "Id", commandType: CommandType.StoredProcedure);
		}
		public async Task<IEnumerable<Testimonial?>> GetUnPublishedTestimonials()
		{
			return await _dbContext.Connection.QueryAsync<Testimonial?, User?, Testimonial?>("TESTIMONIAL_PACKAGE.GET_UNPUBLISHED_TESTIMONIALS", (testimonial, user) =>
			{
				if (testimonial != null)
					testimonial.User = user;
				return testimonial;
			}, splitOn: "Id", commandType: CommandType.StoredProcedure);
		}
		public async Task<Testimonial?> GetTestimonialById(int id)
		{
			DynamicParameters parameters = new DynamicParameters(new { TESTID = id });
			IEnumerable<Testimonial?> testimonials = await _dbContext.Connection.QueryAsync<Testimonial?, User?, Testimonial?>("TESTIMONIAL_PACKAGE.GET_TESTIMONIAL_BY_ID", (testimonial, user) =>
			{
				if (testimonial != null) testimonial.User = user;
				return testimonial;
			}, splitOn: "Id", param: parameters, commandType: CommandType.StoredProcedure);
			return testimonials.FirstOrDefault();
			//return _dbContext.Connection.Query("TESTIMONIAL_PACKAGE.GET_TESTIMONIAL_BY_ID", parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
		}
		public void CreateTestimonial(Testimonial testimonial)
		{
			DynamicParameters parameters = new DynamicParameters(new
			{
				MSG = testimonial.Message,
				SENDER = testimonial.Userid,
				STIME = testimonial.Sendtime
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