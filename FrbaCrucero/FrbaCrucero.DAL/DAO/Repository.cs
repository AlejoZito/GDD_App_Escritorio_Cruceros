using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FrbaCrucero.DAL.DAO
{
    public class Repository
    {
        public SqlConnection GetConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["GD1C2019"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        }
    }
}
