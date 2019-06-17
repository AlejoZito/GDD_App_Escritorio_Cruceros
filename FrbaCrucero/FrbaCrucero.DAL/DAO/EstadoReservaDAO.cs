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
    public static class EstadoReservaDAO
    {

        public static EstadoReserva GetByID(int idEstadoReserva)
        {
            var conn = Repository.GetConnection();
            string comando = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Estado_Reserva WHERE [er_codigo] = {0}", idEstadoReserva);
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

                DataRow registroEstadoReserva = dataTable.Rows[0];

                var EstadoReserva = new EstadoReserva
                {
                    Cod_Estado_Reserva = idEstadoReserva,
                    Estado = registroEstadoReserva["er_estado"].ToString(),
                    Motivo = registroEstadoReserva["er_motivo"].ToString(),
                };

                conn.Close();
                conn.Dispose();

                return EstadoReserva;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar obtener el estado reserva", ex);
            }
        }

        public static void Add(Cliente cliente)
        {

        }
    }
}
