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
    public static class PasajeDAO
    {
        /// <summary>
        /// Realizar pago de pasaje y retornar voucher de compra
        /// </summary>
        /// <returns></returns>
        public static string ComprarPasaje(
            int idCabina,
            int idMedioDePago,
            int idRutaDeViaje,
            string nombreCliente,
            string apellidoCliente,
            string dniCliente,
            string telefonoCliente,
            string direccionCliente,
            string mailCliente,
            DateTime fechaNacimientoCliente)
        {
            return "";
        }

        /// <summary>
        /// Realizar reserva de pasaje y retornar voucher de reserva (codigo de reserva)
        /// </summary>
        /// <returns></returns>
        public static string ReservarPasaje(
            int idCabina,
            int idRutaDeViaje,
            string nombreCliente,
            string apellidoCliente,
            string dniCliente,
            string telefonoCliente,
            string direccionCliente,
            string mailCliente,
            DateTime fechaNacimientoCliente)
        {
            return "";
        }

        /// <summary>
        /// Realizar pago de reserva y retornar voucher de compra
        /// </summary>
        /// <returns></returns>
        public static string PagarReserva(
            int idReserva,
            int idMedioDePago)
        {
            return "";
        }

        /// <summary>
        /// Obtener reserva por ID.
        /// </summary>
        /// <returns></returns>
        
        public static Reserva GetReservaByID(int idReserva)
        {
            var conn = Repository.GetConnection();
            string comando = string.Format(@"SELECT * FROM [TIRANDO_QUERIES].[Reserva] WHERE [rese_codigo] = {0}", idReserva);
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                DataRow registroReserva = dataTable.Rows[0];

                int cod_reserva = int.Parse(registroReserva["rese_codigo"].ToString());
                decimal precio = decimal.Parse(registroReserva["cabi_crucero"].ToString());
                DateTime fecha = DateTime.Parse(registroReserva["rese_fecha"].ToString());
                int cod_cabina = int.Parse(registroReserva["rese_cabina"].ToString());
                int cod_cliente = int.Parse(registroReserva["rese_cliente"].ToString());
                int cod_estado = int.Parse(registroReserva["rese_estado"].ToString());
                int cod_ruta = int.Parse(registroReserva["rese_ruta"].ToString());

                var reserva = new Reserva
                {
                    Cod_Reserva = cod_reserva,
                    Precio = precio,
                    Fecha_Reserva = fecha,
                    Cabina = CabinaDAO.GetByID(cod_cabina),
                    Cliente = ClienteDAO.GetByID(cod_cliente),
                    Estado = EstadoReservaDAO.GetByID(cod_estado),
                    Ruta = (new RutaDeViajeDAO()).GetByID(cod_ruta)
                };

                conn.Close();
                conn.Dispose();

                return reserva;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar obtener la cabina", ex);
            }
        }

        public static void ActualizarReservasVencidas()
        {
            try
            {
                SqlConnection conn = Repository.GetConnection();
                SqlCommand cmd = new SqlCommand("TIRANDO_QUERIES.sp_vencer_reservas", conn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.ExecuteNonQuery();
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar actualizar reservar vencidas", ex);
            }
        }

    }
}
