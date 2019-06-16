using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAL.DAO
{
    public static class ClienteDAO
    {
        public static Cliente GetByDNI(string dni)
        {
            var conn = Repository.GetConnection();
            string comando = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Cliente WHERE clie_dni = CAST('{0}' as DECIMAL(18,0))", dni);
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count == 0)
                {
                    return null;
                }

                DataRow registroCliente = dataTable.Rows[0];

                var idCliente = int.Parse(registroCliente["clie_codigo"].ToString());

                var cliente = new Cliente
                {
                    Cod_Cliente = idCliente,
                    Apellido = registroCliente["clie_apellido"].ToString(),
                    Direccion = registroCliente["clie_direccion"].ToString(),
                    Dni = int.Parse(registroCliente["clie_dni"].ToString()),
                    Fecha_Nac = DateTime.Parse(registroCliente["clie_fecha_nac"].ToString()),
                    Mail = registroCliente["clie_mail"].ToString(),
                    Nombre = registroCliente["clie_nombre"].ToString(),
                    Telefono = int.Parse(registroCliente["clie_telefono"].ToString())
                };

                conn.Close();
                conn.Dispose();

                return cliente;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar obtener el cliente", ex);
            }
        }

        public static void Add(Cliente cliente)
        {

        }
    }
}
