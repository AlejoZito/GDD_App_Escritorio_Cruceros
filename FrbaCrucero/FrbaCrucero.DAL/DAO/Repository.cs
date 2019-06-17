using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace FrbaCrucero.DAL.DAO
{
    public static class Repository
    {
        public static SqlConnection GetConnection()
        {
            try
            {
                var connectionString = ConfigurationManager.ConnectionStrings["GD1C2019"].ConnectionString;
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                return connection;
            }
            catch (Exception ex) 
            {
                throw new Exception("Ocurrio un error al intentar establecer conexión con la base", ex);
            }
        }
    }
}
