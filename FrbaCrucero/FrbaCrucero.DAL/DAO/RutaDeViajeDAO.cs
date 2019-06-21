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
    public class RutaDeViajeDAO
    {
        public RutaDeViaje GetByID(int id)
        {
            var conn = Repository.GetConnection();
            SqlCommand comando = new SqlCommand(@"SELECT * " +
                                                "FROM TIRANDO_QUERIES.Ruta_Viaje " +
                                                "WHERE rv_codigo = @rutaCodigo", conn);

            DataTable dataTable = new DataTable();
            comando.Parameters.AddWithValue("@rutaCodigo", id);

            SqlDataAdapter dataAdapter = new SqlDataAdapter()
            {
                SelectCommand = comando
            };

            try
            {
                dataAdapter.Fill(dataTable);

                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    return new RutaDeViaje()
                    {
                        Cod_Ruta = int.Parse(dataTable.Rows[0]["rv_recorrido"].ToString()),
                        Crucero = CruceroDAO.GetByID(int.Parse(dataTable.Rows[0]["rv_crucero"].ToString())),
                        Fecha_Inicio = (DateTime)dataTable.Rows[0]["rv_fecha_salida"],
                        Fecha_Fin = (DateTime)dataTable.Rows[0]["rv_fecha_llegada"],
                        Fecha_Fin_Estimada = (DateTime)dataTable.Rows[0]["rv_fecha_llegada_estimada"],
                        Recorrido = RecorridoDAO.GetByID(int.Parse(dataTable.Rows[0]["rv_recorrido"].ToString()))
                    };
                }
                else
                    return null;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar listar las rutas de viaje", ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public static List<RutaDeViaje> GetAllByIDCrucero(int idCrucero) {
            var conn = Repository.GetConnection();
            string comando = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Ruta_Viaje WHERE rv_crucero = {0} AND rv_fecha_llegada IS NULL", idCrucero);
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                List<RutaDeViaje> recorridos = new List<RutaDeViaje>();

                foreach (DataRow fila in dataTable.Rows)
                {

                    var rutaDeViaje = new RutaDeViaje()
                    {
                        Cod_Ruta = int.Parse(fila["rv_codigo"].ToString()),
                        Crucero = null,
                        Fecha_Inicio = (DateTime)fila["rv_fecha_salida"],
                        Fecha_Fin = default(DateTime),
                        Fecha_Fin_Estimada = (DateTime)fila["rv_fecha_llegada_estimada"],
                        Recorrido = RecorridoDAO.GetByID(int.Parse(fila["rv_recorrido"].ToString()))
                    };

                    recorridos.Add(rutaDeViaje);
                };

                return recorridos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar listar los recorridos", ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public static void ActualizarCrucero(int crucero_a_reemplazar, int crucero_reemplazante)
        {
            try
            {
                var conn = Repository.GetConnection();
                SqlCommand comando = new SqlCommand(@"UPDATE [TIRANDO_QUERIES].[Ruta_Viaje] SET [rv_crucero]=@crucero_reemplazante WHERE [rv_crucero]=@crucero_a_reemplazar AND [rv_fecha_llegada] IS NULL", conn);
                comando.Parameters.Add("@crucero_a_reemplazar", SqlDbType.Int);
                comando.Parameters["@crucero_a_reemplazar"].Value = crucero_a_reemplazar;
                comando.Parameters.Add("@crucero_reemplazante", SqlDbType.Int);
                comando.Parameters["@crucero_reemplazante"].Value = crucero_reemplazante;
                comando.ExecuteNonQuery();

                conn.Close();
                conn.Dispose();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar cambiar el crucero de rutas", ex);
            }
        }

        public List<RutaDeViaje> GetAll()
        {
            var conn = Repository.GetConnection();
            string comando = @"SELECT * FROM TIRANDO_QUERIES.Ruta_Viaje";
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                List<RutaDeViaje> recorridos = new List<RutaDeViaje>();

                foreach (DataRow fila in dataTable.Rows)
                {

                    var rutaDeViaje = new RutaDeViaje()
                    {
                        Cod_Ruta = int.Parse(fila["rv_codigo"].ToString()),
                        Crucero = CruceroDAO.GetByID(int.Parse(fila["rv_crucero"].ToString())),
                        Fecha_Inicio = (DateTime)fila["rv_fecha_salida"],
                        Fecha_Fin = fila["rv_fecha_llegada"] is DBNull ? null : (DateTime?)fila["rv_fecha_llegada"],
                        Fecha_Fin_Estimada = (DateTime)fila["rv_fecha_llegada_estimada"],
                        Recorrido = RecorridoDAO.GetByID(int.Parse(fila["rv_recorrido"].ToString()))
                    };

                    recorridos.Add(rutaDeViaje);
                };

                return recorridos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar listar los recorridos", ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public List<RutaDeViaje> GetAllWithFilters(string likeFilter, string exactFilter, int? idDropdown, List<DateTime> fechasEntre)
        {
            var conn = Repository.GetConnection();
            SqlCommand comando = new SqlCommand(@"SELECT * FROM TIRANDO_QUERIES.Ruta_Viaje " +
                                                "join TIRANDO_QUERIES.Crucero on rv_crucero = cruc_codigo " +
                                                "join TIRANDO_QUERIES.Modelo_Crucero on cruc_modelo = mc_codigo " +
                                                "where 1=1 ", conn);
            DataTable dataTable = new DataTable();

            if (!string.IsNullOrWhiteSpace(likeFilter))
            {
                comando.CommandText += "AND (rv_codigo like '%' + @likeParameter + '%' OR " +
                                            "cruc_identificador like '%' + @likeParameter + '%' OR " +
                                            "mc_detalle like '%' + @likeParameter + '%') ";
                comando.Parameters.AddWithValue("@likeParameter", likeFilter);
            }

            if (!string.IsNullOrWhiteSpace(exactFilter))
            {
                comando.CommandText += "AND rv_codigo = @exactFilter ";
                comando.Parameters.AddWithValue("@exactFilter", exactFilter);
            }

            if (idDropdown != null && idDropdown != 0)
            {
                comando.CommandText += "AND cruc_codigo = @codigoCrucero ";
                comando.Parameters.AddWithValue("@codigoCrucero", idDropdown.Value);
            }

            //Filtrar entre fechas. El primer item de la lista es DESDE, el segundo es HASTA
            if (fechasEntre != null && fechasEntre.Count > 0)
            {
                comando.CommandText += "AND rv_fecha_salida BETWEEN @desde AND @hasta ";
                comando.CommandText += "AND rv_fecha_llegada_estimada BETWEEN @desde AND @hasta ";
                comando.Parameters.AddWithValue("@desde", (DateTime)fechasEntre[0]);
                comando.Parameters.AddWithValue("@hasta", (DateTime)fechasEntre[1]);
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter()
            {
                SelectCommand = comando
            };

            try
            {
                dataAdapter.Fill(dataTable);
                List<RutaDeViaje> recorridos = new List<RutaDeViaje>();

                foreach (DataRow fila in dataTable.Rows)
                {

                    var rutaDeViaje = new RutaDeViaje()
                    {
                        Cod_Ruta = int.Parse(fila["rv_codigo"].ToString()),
                        Crucero = CruceroDAO.GetByID(int.Parse(fila["rv_crucero"].ToString())),
                        Fecha_Inicio = (DateTime)fila["rv_fecha_salida"],
                        Fecha_Fin = fila["rv_fecha_llegada"] is DBNull ? null : (DateTime?)fila["rv_fecha_llegada"],
                        Fecha_Fin_Estimada = (DateTime)fila["rv_fecha_llegada_estimada"],
                        Recorrido = RecorridoDAO.GetByID(int.Parse(fila["rv_recorrido"].ToString()))
                    };

                    recorridos.Add(rutaDeViaje);
                };

                return recorridos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar listar las rutas de viaje", ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void Add(RutaDeViaje t)
        {

            try
            {
                var conn = Repository.GetConnection();

                //Inserto la ruta de viaje
                SqlCommand comando = new SqlCommand(@"INSERT INTO TIRANDO_QUERIES.Ruta_Viaje(rv_recorrido,rv_crucero,rv_fecha_salida,rv_fecha_llegada_estimada) 
                values(@recorrido,@crucero,@desde,@hasta_estimado)", conn);

                comando.Parameters.AddWithValue("@crucero", t.Crucero);
                comando.Parameters.AddWithValue("@recorrido", t.Recorrido);
                comando.Parameters.AddWithValue("@desde", t.Fecha_Inicio);
                comando.Parameters.AddWithValue("@hasta_estimado", t.Fecha_Fin_Estimada);
                comando.ExecuteNonQuery();

                comando.Dispose();
                conn.Close();
                conn.Dispose();

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar crear la ruta de viaje", ex);
            }
        }


        /// <summary>
        /// Metodo llamado desde la vista de compra de pasajes
        /// </summary>
        /// <param name="fechaPartida"></param>
        /// <param name="idPuertoSalida"></param>
        /// <param name="idPuertoLlegada"></param>
        /// <returns></returns>
        public List<RutaDeViaje> GetByFiltersPasaje(DateTime? fechaPartida, int idPuertoSalida, int idPuertoLlegada)
        {
            var conn = Repository.GetConnection();
            SqlCommand comando = new SqlCommand(@"SELECT " +
                                                "    Ruta.rv_codigo rv_codigo, " +
                                                "    Ruta.rv_recorrido rv_recorrido, " +
                                                "    Ruta.rv_fecha_salida rv_fecha_salida, " +
                                                "    Ruta.rv_fecha_llegada_estimada rv_fecha_llegada_estimada, " +
                                                "    Tramo_INICIAL.tram_puerto_desde, " +
                                                "    Tramo_DESTINO.tram_puerto_hasta, " +
                                                "    Ruta.rv_crucero rv_crucero " +
                                                "FROM [TIRANDO_QUERIES].Ruta_Viaje Ruta, [TIRANDO_QUERIES].Tramo Tramo_INICIAL, " +
                                                " [TIRANDO_QUERIES].Tramo Tramo_DESTINO, [TIRANDO_QUERIES].Recorrido Recorridos, " +
                                                " [TIRANDO_QUERIES].Crucero Crucero " +
                                                "WHERE " +
                                                "   CONVERT(VARCHAR(10), Ruta.rv_fecha_salida, 111) = CONVERT(VARCHAR(10), @fecha_salida, 111) AND " +
                                                "   Ruta.rv_recorrido = Recorridos.reco_codigo AND " +
                                                "   Recorridos.reco_activo = 1 AND " +
                                                "   Crucero.cruc_codigo = Ruta.rv_crucero AND " +
                                                "   Crucero.cruc_activo = 1 AND " +
                                                "   Tramo_INICIAL.tram_recorrido = Ruta.rv_recorrido AND " +
                                                "   Tramo_DESTINO.tram_recorrido = Ruta.rv_recorrido AND " +
                                                "	Tramo_INICIAL.tram_orden = 1 AND " +
                                                "	Tramo_INICIAL.tram_puerto_desde = @puerto_desde AND " +
                                                "	Tramo_DESTINO.tram_puerto_hasta = @puerto_destino AND " +
                                                "   ruta.rv_codigo NOT IN (SELECT DISTINCT rv_codigo FROM [TIRANDO_QUERIES].[Ruta_Viaje] Ruta " +
                                                "        LEFT JOIN  [TIRANDO_QUERIES].Crucero Crucero ON Ruta.rv_crucero = Crucero.cruc_codigo " +
                                                "        JOIN [TIRANDO_QUERIES].Mantenimiento M ON M.mant_crucero = Crucero.cruc_codigo " +
                                                "        WHERE M.mant_fecha_hasta > (SELECT getdate()) AND M.mant_fecha_hasta > Ruta.rv_fecha_salida)", conn);

            DataTable dataTable = new DataTable();
            comando.Parameters.AddWithValue("@fecha_salida", fechaPartida);
            comando.Parameters.AddWithValue("@puerto_desde", idPuertoSalida);
            comando.Parameters.AddWithValue("@puerto_destino", idPuertoLlegada);


            SqlDataAdapter dataAdapter = new SqlDataAdapter()
            {
                SelectCommand = comando
            };

            try
            {
                dataAdapter.Fill(dataTable);
                List<RutaDeViaje> recorridos = new List<RutaDeViaje>();

                foreach (DataRow fila in dataTable.Rows)
                {

                    var rutaDeViaje = new RutaDeViaje()
                    {
                        Cod_Ruta = int.Parse(fila["rv_codigo"].ToString()),
                        Crucero = CruceroDAO.GetByID(int.Parse(fila["rv_crucero"].ToString())),
                        Fecha_Inicio = (DateTime)fila["rv_fecha_salida"],
                        Fecha_Fin = null,
                        Fecha_Fin_Estimada = (DateTime)fila["rv_fecha_llegada_estimada"],
                        Recorrido = RecorridoDAO.GetByID(int.Parse(fila["rv_recorrido"].ToString()))
                    };

                    recorridos.Add(rutaDeViaje);
                };

                return recorridos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar listar las rutas de viaje", ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void Edit(RutaDeViaje rutaDeViaje)
        {
            throw new NotImplementedException();
        }
    }
}
