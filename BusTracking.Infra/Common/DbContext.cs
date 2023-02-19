using BusTracking.Core.Common;
using Microsoft.Extensions.Configuration;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
namespace BusTracking.Infra.Common
{
	public class DbContext:IDbContext
	{
		private readonly IConfiguration _configuration;
		private DbConnection? _connection;
		public DbContext(IConfiguration configuration)
		{
			_configuration = configuration;
			//_connection = connection;
		}
		public DbConnection Connection
		{
			get
			{
				if (_connection == null)
				{
					_connection = new OracleConnection(_configuration["ConnectionStrings:DBConnectionString"]);
				}
				else if (_connection.State == ConnectionState.Closed)
				{
					_connection.Open();
				}
				return _connection;
			}
		}
	}
}
