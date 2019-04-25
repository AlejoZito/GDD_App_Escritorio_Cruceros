using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace FrbaCrucero.Core
{
    public class Repository
    {
        public string Select(string query) 
        {
            var connection = GetConnection();
            SqlCommand command;
            SqlDataReader dataReader;
            string output = "";

            connection.Open();
            command = new SqlCommand(query, connection);
            dataReader = command.ExecuteReader();

            while (dataReader.Read()) 
            {
                output = output + dataReader.GetValue(0) + "\n";
            }

            dataReader.Close();
            command.Dispose();
            connection.Close();

            return output;
        }

        private SqlConnection GetConnection()
        {
            var connectionString = ConfigurationManager.ConnectionStrings["GD1C2019"].ConnectionString;
            SqlConnection connection = new SqlConnection(connectionString);
            return connection;
        }
    }
}
