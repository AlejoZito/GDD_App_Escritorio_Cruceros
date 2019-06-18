using FrbaCrucero.DAL.Domain;
using FrbaCrucero.DAL.Enums;
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

        public static ReservaAPagar GetReservaAPagarByID(int idReserva)
        {
            var conn = Repository.GetConnection();
            string comando = string.Format(@"SELECT rese_precio AS precio, " +
                                                "rv_fecha_salida AS fecha_salida, " +
                                                "(SELECT p.puer_nombre FROM [TIRANDO_QUERIES].Puerto p " +
                                                "JOIN [TIRANDO_QUERIES].Tramo t " +
                                                "ON t.tram_puerto_desde = p.puer_codigo " +
                                                "WHERE t.tram_recorrido = rv.rv_recorrido " +
                                                "AND t.tram_orden = 1) AS puerto_desde, " +
                                                "(SELECT p.puer_nombre " +
                                                "FROM [TIRANDO_QUERIES].Puerto p " +
                                                "JOIN [TIRANDO_QUERIES].Tramo t " +
                                                "ON t.tram_puerto_hasta = p.puer_codigo " +
                                                "WHERE t.tram_recorrido = rv.rv_recorrido " +
                                                "AND t.tram_orden = (SELECT MAX(tram_orden) " +
                                                                    "FROM [TIRANDO_QUERIES].Tramo t2 " +
                                                                    "WHERE t2.tram_recorrido = rv.rv_recorrido)) AS puerto_hasta, " +
                                                "c.clie_apellido, " +
                                                "c.clie_nombre, " +
                                                "rese_estado " +
                                           "FROM [TIRANDO_QUERIES].Reserva " +
                                           "JOIN [TIRANDO_QUERIES].Ruta_Viaje rv ON rese_ruta = rv.rv_codigo " +
                                           "JOIN [TIRANDO_QUERIES].Recorrido r ON rv.rv_recorrido = r.reco_codigo " +
                                           "JOIN [TIRANDO_QUERIES].Cliente c ON rese_cliente = c.clie_codigo " +
                                           "WHERE rese_codigo = {0} AND reco_invalido <> 1", idReserva);
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                if (dataTable.Rows.Count == 0)
                {
                    throw new Exception("No se encuentra registrada ninguna reserva con ese número");
                }

                DataRow registroReserva = dataTable.Rows[0];

                int estadoReserva = int.Parse(registroReserva["rese_estado"].ToString());

                switch (estadoReserva)
                {
                    case (int)EstadoDeReserva.Vencida:
                        throw new Exception("La reserva esta vencida, por favor realice una nueva reserva o una compra nueva");
                    case (int)EstadoDeReserva.Cancelado:
                        throw new Exception("La reserva esta cancelada, por favor realice una nueva reserva o una compra nueva");
                    case (int)EstadoDeReserva.Pagado:
                        throw new Exception("La reserva ya se encuentra pagada");
                    default:
                        break;
                }

                decimal precio = decimal.Parse(registroReserva["precio"].ToString());
                string fechaSalida = registroReserva["fecha_salida"].ToString();
                string puertoDesde = registroReserva["puerto_desde"].ToString();
                string puertoHasta = registroReserva["puerto_hasta"].ToString();
                string nombreCliente = registroReserva["clie_nombre"].ToString();
                string apellidoCliente = registroReserva["clie_apellido"].ToString();

                var reserva = new ReservaAPagar
                {
                    Apellido = apellidoCliente,
                    FechaSalida = fechaSalida,
                    Nombre = nombreCliente,
                    Precio = precio,
                    PuertoDesde = puertoDesde,
                    PuertoHasta = puertoHasta
                };

                conn.Close();
                conn.Dispose();

                return reserva;
            }
            catch (Exception ex)
            {
                throw ex;
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
