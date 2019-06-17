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

            //ToDo
            if (fechasEntre != null && fechasEntre.Count > 0)
            {
                //Filtrar entre fechas. El primer item de la lista es DESDE, el segundo es HASTA
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

        }

        public void Edit(RutaDeViaje t)
        {

        }

        public void Delete(RutaDeViaje t)
        {
            throw new NotImplementedException();
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
                                                " [TIRANDO_QUERIES].Tramo Tramo_DESTINO, [TIRANDO_QUERIES].Recorrido Recorridos " +
                                                "WHERE  " +
                                                "   CONVERT(VARCHAR(10), Ruta.rv_fecha_salida, 111) = CONVERT(VARCHAR(10), @fecha_salida, 111) AND " +
                                                "   Ruta.rv_recorrido = Recorridos.reco_codigo AND " +
                                                "   Recorridos.reco_activo = 1 AND " +
                                                "   Tramo_INICIAL.tram_recorrido = Ruta.rv_recorrido AND " +
                                                "   Tramo_DESTINO.tram_recorrido = Ruta.rv_recorrido AND " +
                                                "	Tramo_INICIAL.tram_orden = 1 AND " +
                                                "	Tramo_INICIAL.tram_puerto_desde = @puerto_desde AND " +
                                                "	Tramo_DESTINO.tram_puerto_hasta = @puerto_destino ", conn);

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
    }
}
