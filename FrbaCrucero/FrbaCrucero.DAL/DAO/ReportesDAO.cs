using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAL.DAO
{
    public class ReportesDAO
    {
        /// <summary>
        /// TOP 5 DE LOS RECORRIDOS CON MÁS PASAJES COMPRADOS
        /// Recibe @semestre y @anio
        /// </summary>
        /// <param name="semestre"></param>
        /// <param name="anio"></param>
        /// <returns></returns>
        public static DataTable GetRecorridosConPasajesMasComprados(int semestre, int anio)
        {
            var conn = Repository.GetConnection();
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            //Inserto la cabina y obtengo el id
            SqlCommand comando = new SqlCommand(@"SELECT TOP 5 r.reco_codigo AS RECORRIDO, " +
                                                " (SELECT p1.puer_nombre FROM [TIRANDO_QUERIES].Tramo t " +
                                                " JOIN [TIRANDO_QUERIES].Puerto p1 ON p1.puer_codigo = t.tram_puerto_desde " +
                                                " JOIN [TIRANDO_QUERIES].Puerto p2 ON p2.puer_codigo = t.tram_puerto_hasta " +
                                                " WHERE r.reco_codigo = t.tram_recorrido " +
                                                " AND t.tram_orden = 1 " +
                                                " ) AS ORIGEN, " +
                                                " (SELECT p2.puer_nombre FROM [TIRANDO_QUERIES].Tramo t " +
                                                " JOIN [TIRANDO_QUERIES].Puerto p1 ON p1.puer_codigo = t.tram_puerto_desde " +
                                                " JOIN [TIRANDO_QUERIES].Puerto p2 ON p2.puer_codigo = t.tram_puerto_hasta " +
                                                " WHERE r.reco_codigo = t.tram_recorrido " +
                                                " AND t.tram_orden = (SELECT MAX(t2.tram_orden) FROM [TIRANDO_QUERIES].Tramo t2 WHERE t.tram_recorrido = r.reco_codigo) " +
                                                " ) AS DESTINO " +
                                                " FROM [TIRANDO_QUERIES].Recorrido r " +
                                                " JOIN [TIRANDO_QUERIES].Ruta_Viaje rv ON rv_recorrido = r.reco_codigo " +
                                                " JOIN [TIRANDO_QUERIES].Pasaje p ON p.pasa_ruta = rv.rv_codigo " +
                                                " WHERE @anio = YEAR(p.pasa_fecha_pago) " +
                                                " AND MONTH(p.pasa_fecha_pago) BETWEEN (SELECT CASE WHEN @semestre = 1 THEN 1 ELSE 7 END) AND (SELECT CASE WHEN @semestre = 6 THEN 1 ELSE 12 END) " +
                                                " AND r.reco_invalido <> 1 " +
                                                " GROUP BY r.reco_codigo " +
                                                " ORDER BY COUNT(DISTINCT p.pasa_codigo) DESC", conn);

            comando.Parameters.Add("@semestre", SqlDbType.Int);
            comando.Parameters["@semestre"].Value = semestre;

            comando.Parameters.Add("@anio", SqlDbType.Int);
            comando.Parameters["@anio"].Value = anio;

            try
            {
                dataAdapter = new SqlDataAdapter(comando);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        /// <summary>
        /// TOP 5 DE LOS CRUCEROS CON MAYOR CANTIDAD DE DÍAS FUERA DE SERVICIO
        /// </summary>
        /// <returns></returns>
        public static DataTable GetCrucerosConMasDiasFueraDeServicio()
        {
            var conn = Repository.GetConnection();
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            //Inserto la cabina y obtengo el id
            SqlCommand comando = new SqlCommand(@"SELECT TOP 5 c.cruc_codigo AS CRUCERO,c.cruc_identificador AS IDENTIFICADOR,c.cruc_fabricante AS FABRICANTE, " +
                                                "SUM(DATEDIFF(day,m.mant_fecha_desde,m.mant_fecha_hasta)) AS DIAS_FUERA_DE_SERVICIO " +
                                                "FROM [TIRANDO_QUERIES].Crucero c " +
                                                "JOIN [TIRANDO_QUERIES].Mantenimiento m ON c.cruc_codigo = m.mant_crucero " +
                                                "GROUP BY c.cruc_codigo,c.cruc_identificador,c.cruc_fabricante " +
                                                "ORDER BY 4 DESC", conn);
            try
            {
                dataAdapter = new SqlDataAdapter(comando);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        /// <summary>
        /// TOP 5 DE LOS RECORRIDOS CON MÁS CABINAS LIBRES EN CADA UNO DE LOS VIAJES REALIZADOS
        /// </summary>
        /// <param name="semestre"></param>
        /// <param name="anio"></param>
        /// <returns></returns>
        public static DataTable GetCrucerosConMasCabinasLibresEnCadaViaje()
        {
            var conn = Repository.GetConnection();
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            //Inserto la cabina y obtengo el id
            SqlCommand comando = new SqlCommand(@"SELECT TOP 5 r.reco_codigo AS RECORRIDO, " +
                                                "(SELECT COUNT(cabi_codigo) FROM [TIRANDO_QUERIES].Cabina ca " +
                                                "JOIN [TIRANDO_QUERIES].Crucero cr ON ca.cabi_crucero = cr.cruc_codigo " +
                                                "JOIN [TIRANDO_QUERIES].Ruta_Viaje rv2 ON rv2.rv_crucero = cr.cruc_codigo " +
                                                "WHERE rv2.rv_recorrido = r.reco_codigo) - COUNT(pasa_cabina) AS CABINAS_LIBRES " +
                                                "FROM [TIRANDO_QUERIES].Recorrido r " +
                                                "JOIN [TIRANDO_QUERIES].Ruta_Viaje rv ON rv_recorrido = r.reco_codigo " +
                                                "JOIN [TIRANDO_QUERIES].Pasaje p ON p.pasa_ruta = rv.rv_codigo " +
                                                "WHERE r.reco_invalido <> 1 " +
                                                "GROUP BY r.reco_codigo " +
                                                "ORDER BY 2 DESC", conn);
            try
            {
                dataAdapter = new SqlDataAdapter(comando);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);
                return dataTable;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }
    }
}
