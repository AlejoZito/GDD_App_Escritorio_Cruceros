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

            SqlCommand comando = new SqlCommand("TIRANDO_QUERIES.sp_rep_estadistico_recorridos_mas_comprados", conn);
            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.Add("@semestre", SqlDbType.Int);
            comando.Parameters["@semestre"].Value = semestre;

            comando.Parameters.Add("@anio", SqlDbType.Int);
            comando.Parameters["@anio"].Value = anio;

            try
            {
                dataAdapter = new SqlDataAdapter()
                {
                    SelectCommand = comando
                };
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
        public static DataTable GetCrucerosConMasDiasFueraDeServicio(int semestre, int anio)
        {
            var conn = Repository.GetConnection();
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            SqlCommand comando = new SqlCommand("TIRANDO_QUERIES.sp_rep_estadistico_crucero_mas_fuera_servicio", conn);
            comando.CommandType = CommandType.StoredProcedure;

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
        /// TOP 5 DE LOS RECORRIDOS CON MÁS CABINAS LIBRES EN CADA UNO DE LOS VIAJES REALIZADOS
        /// </summary>
        /// <param name="semestre"></param>
        /// <param name="anio"></param>
        /// <returns></returns>
        public static DataTable GetCrucerosConMasCabinasLibresEnCadaViaje(int semestre, int anio)
        {
            var conn = Repository.GetConnection();
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            SqlCommand comando = new SqlCommand("TIRANDO_QUERIES.sp_rep_estadistico_reco_mas_cabinas_libres", conn);
            comando.CommandType = CommandType.StoredProcedure;

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
    }
}
