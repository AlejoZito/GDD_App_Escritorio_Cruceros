using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAL.DAO
{
    public class PasajeDAO
    {
        /// <summary>
        /// Realizar pago de pasaje y retornar voucher de compra
        /// </summary>
        /// <returns></returns>
        public string ComprarPasaje(
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
        public string ReservarPasaje(
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
        public string PagarReserva(
            int idReserva,
            int idMedioDePago)
        {
            return "";
        }

        /// <summary>
        /// Obtener reserva por ID.
        /// </summary>
        /// <returns></returns>
        public Reserva GetReservaByID()
        {
            return new Reserva();
        }

        public void VencerReservasVencidas()
        {

        }

        //    public List<Cabina> ObtenerCabinasDisponibles()
        //{

        //    "SELECT Cabina.[cabi_codigo], Cabina.[cabi_numero], Cabina.[cabi_piso], Tipo_Cabina.[tc_porc_recargo] " +
        //    " FROM [TIRANDO_QUERIES].[Cabina] Cabina " +
        //    " INNER JOIN [TIRANDO_QUERIES].[Tipo_Cabina] Tipo_Cabina ON Tipo_Cabina.[tc_codigo] = Cabina.cabi_cod_tipo " +
        //    " WHERE " +
        //    " 	[cabi_crucero] = (SELECT [rv_crucero] FROM [TIRANDO_QUERIES].[Ruta_Viaje] WHERE [rv_codigo]=@ruta_codigo) AND " +
        //    " 	[cabi_codigo] NOT IN ( " +
        //    " 		SELECT [pasa_cabina] FROM [TIRANDO_QUERIES].[Pasaje] " +
        //    " 		WHERE  " +
        //    " 			[pasa_ruta]=@ruta_codigo AND " +
        //    " 			[pasa_estado] IN (Select [ep_codigo] FROM [TIRANDO_QUERIES].[Estado_Pasaje] WHERE [ep_estado]='Vigente' OR [ep_estado]='Desconocido') " +
        //    " 	) AND " +
        //    " 	[cabi_codigo] NOT IN ( " +
        //    " 		SELECT [rese_cabina] FROM [TIRANDO_QUERIES].[Reserva] " +
        //    " 		WHERE " +
        //    " 			[rese_ruta]=@ruta_codigo AND " +
        //    " 			[rese_estado] IN (Select [er_codigo] FROM [TIRANDO_QUERIES].[Estado_Reserva] WHERE [er_estado]='Vigente' OR [er_estado]='Desconocido') " +
        //    " 	);";
        //}
    }
}
