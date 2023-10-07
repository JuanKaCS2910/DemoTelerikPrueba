using Microsoft.Extensions.Configuration;

using System;
using System.Data.SqlClient;
using System.Data;

namespace DemoTelerik.Infraestructura.Data
{
	public class DapperContext
	{
		private readonly IConfiguration _configuration;
		private readonly string _connectionString;

		public DapperContext(IConfiguration configuration)
		{
			this._configuration = configuration;
			this._connectionString = configuration.GetConnectionString("FisioterapiaConnection");
		}

		public IDbConnection CreateConnection() => new SqlConnection(this._connectionString);
	}
}
