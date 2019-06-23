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
    public static class CruceroDAO
    {
        public static Crucero GetByID(int id)
        {
            var conn = Repository.GetConnection();
            string comando = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Crucero WHERE cruc_codigo = {0}", id);
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                DataRow registroCrucero = dataTable.Rows[0];

                var idCrucero = int.Parse(registroCrucero["cruc_codigo"].ToString());
                var idModelo = int.Parse(registroCrucero["cruc_modelo"].ToString());
                var idFabricante = int.Parse(registroCrucero["cruc_fabricante"].ToString());

                var crucero = new Crucero
                {
                    Cod_Crucero = idCrucero,
                    Activo = bool.Parse(registroCrucero["cruc_activo"].ToString()),
                    Identificador = registroCrucero["cruc_identificador"].ToString(),
                    Modelo_Crucero = ModeloCruceroDAO.GetByID(idModelo),
                    Cabinas = CabinaDAO.GetAllForId(idCrucero),
                    Fabricante = FabricanteDAO.GetByID(idFabricante)
                };

                conn.Close();
                conn.Dispose();

                return crucero;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar obtener el crucero", ex);
            }
        }

        public static List<Crucero> GetAll()
        {
            var conn = Repository.GetConnection();
            string comando = @"SELECT * FROM TIRANDO_QUERIES.Crucero WHERE cruc_activo = 1";
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                List<Crucero> cruceros = new List<Crucero>();

                foreach (DataRow fila in dataTable.Rows)
                {
                    var idCrucero = int.Parse(fila["cruc_codigo"].ToString());
                    var idFabricante = int.Parse(fila["cruc_fabricante"].ToString());
                    var idModelo = int.Parse(fila["cruc_modelo"].ToString());

                    var crucero = new Crucero
                    {
                        Cod_Crucero = idCrucero,
                        Cabinas = CabinaDAO.GetAllForId(idCrucero),
                        Identificador = fila["cruc_identificador"].ToString(),
                        Fabricante = FabricanteDAO.GetByID(idFabricante),
                        Modelo_Crucero = ModeloCruceroDAO.GetByID(idModelo),
                        Activo = bool.Parse(fila["cruc_activo"].ToString())
                    };

                    cruceros.Add(crucero);
                }

                conn.Close();
                conn.Dispose();

                return cruceros;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar listar los fabricantes", ex);
            }
        }

        public static void Add(Crucero crucero)
        {
            crucero.Identificador = crucero.Identificador.ToUpper().Trim();

            try
            {
                var conn = Repository.GetConnection();

                //Inserto la cabina y obtengo el id
                SqlCommand comando = new SqlCommand(@"INSERT INTO TIRANDO_QUERIES.Crucero(cruc_identificador, cruc_fabricante, cruc_modelo, cruc_activo) VALUES(@identificador, @fabricante, @modelo, @activo)", conn);
                comando.Parameters.AddWithValue("@identificador", crucero.Identificador);
                comando.Parameters.Add("@fabricante", SqlDbType.Int);
                comando.Parameters["@fabricante"].Value = crucero.Fabricante.Cod_Fabricante;
                comando.Parameters.Add("@modelo", SqlDbType.Int);
                comando.Parameters["@modelo"].Value = crucero.Modelo_Crucero.Cod_Modelo;
                crucero.Activo = true;
                comando.Parameters.Add("@activo", SqlDbType.Bit);
                comando.Parameters["@activo"].Value = crucero.Activo;
                int idCrucero = Convert.ToInt32(comando.ExecuteScalar());

                comando.Dispose();
                conn.Close();
                conn.Dispose();

                //Inserto las cabinas en base con el id de cabina
                CabinaDAO.Add(crucero.Cabinas, idCrucero);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar crear el crucero", ex);
            }
        }

        public static void Edit(Crucero crucero)
        {
            crucero.Identificador = crucero.Identificador.ToUpper().Trim();

            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar editar el crucero", ex);
            }
        }

        public static void Delete(Crucero crucero)
        {
            try
            {
                var conn = Repository.GetConnection();
                SqlCommand comando = new SqlCommand(@"UPDATE TIRANDO_QUERIES.Crucero SET cruc_activo = 0 WHERE cruc_codigo = @idCrucero", conn);
                comando.Parameters.Add("@idCrucero", SqlDbType.Int);
                comando.Parameters["@idCrucero"].Value = crucero.Cod_Crucero;
                comando.ExecuteNonQuery();

                conn.Close();
                conn.Dispose();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar eliminar el crucero", ex);
            }
        }

        public static void DeleteByID(int id)
        {
            try
            {
                var conn = Repository.GetConnection();
                SqlCommand comando = new SqlCommand(@"UPDATE TIRANDO_QUERIES.Crucero SET cruc_activo = 0 WHERE cruc_codigo = @idCrucero", conn);
                comando.Parameters.Add("@idCrucero", SqlDbType.Int);
                comando.Parameters["@idCrucero"].Value = id;
                comando.ExecuteNonQuery();

                conn.Close();
                conn.Dispose();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar eliminar el crucero", ex);
            }
        }

        public static bool ExisteCrucero(Crucero crucero)
        {
            string query = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Crucero WHERE cruc_identificador LIKE '{0}'", crucero.Identificador);
            SqlConnection conn = Repository.GetConnection();
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);

            dataAdapter.Fill(dataTable);
            conn.Close();
            conn.Dispose();

            if (dataTable.Rows.Count == 0)
            {
                return false;
            }

            var filaSinModificar = dataTable.Rows[0];
            int idCrucero = int.Parse(filaSinModificar["cruc_codigo"].ToString());

            if (idCrucero == crucero.Cod_Crucero)
            {
                return false;
            }

            return true;
        }

        public static List<Crucero> GetAllByFechas(DateTime? fecha_Inicio, DateTime? fecha_Fin_Estimada)
        {
            var conn = Repository.GetConnection();

            SqlCommand comando = new SqlCommand(
                              @"SELECT DISTINCT cruc_codigo, cruc_fabricante, cruc_modelo, cruc_activo, cruc_identificador " +
                               "FROM [TIRANDO_QUERIES].Crucero c " +
                               "WHERE cruc_activo = 1 " +
                               "AND cruc_codigo NOT IN " +
                               "(SELECT m.mant_crucero FROM [TIRANDO_QUERIES].Mantenimiento m " +
                               "WHERE @fecha_desde BETWEEN m.mant_fecha_desde AND m.mant_fecha_hasta " +
                               "AND @fecha_hasta_estimada BETWEEN m.mant_fecha_desde AND m.mant_fecha_hasta " +
                               "UNION ALL " +
                               "SELECT rv.rv_crucero FROM [TIRANDO_QUERIES].Ruta_Viaje rv " +
                               "WHERE @fecha_desde BETWEEN rv.rv_fecha_salida AND rv.rv_fecha_llegada_estimada " +
                               "AND @fecha_hasta_estimada BETWEEN rv.rv_fecha_salida AND rv.rv_fecha_llegada_estimada) ", conn);

            DataTable dataTable = new DataTable();

            comando.Parameters.AddWithValue("@fecha_desde", fecha_Inicio.Value);
            comando.Parameters.AddWithValue("@fecha_hasta_estimada", fecha_Fin_Estimada.Value);

            SqlDataAdapter dataAdapter = new SqlDataAdapter()
            {
                SelectCommand = comando
            };

            try
            {
                dataAdapter.Fill(dataTable);
                List<Crucero> cruceros = new List<Crucero>();

                foreach (DataRow fila in dataTable.Rows)
                {
                    var idCrucero = int.Parse(fila["cruc_codigo"].ToString());
                    var idFabricante = int.Parse(fila["cruc_fabricante"].ToString());
                    var idModelo = int.Parse(fila["cruc_modelo"].ToString());

                    var crucero = new Crucero
                    {
                        Cod_Crucero = idCrucero,
                        Cabinas = CabinaDAO.GetAllForId(idCrucero),
                        Identificador = fila["cruc_identificador"].ToString(),
                        Fabricante = FabricanteDAO.GetByID(idFabricante),
                        Modelo_Crucero = ModeloCruceroDAO.GetByID(idModelo),
                        Activo = bool.Parse(fila["cruc_activo"].ToString())
                    };

                    cruceros.Add(crucero);
                }

                return cruceros;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar listar los fabricantes", ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }

        public static void DemorarViajes(int IDCrucero, int diasADemorar)
        {
            var conn = Repository.GetConnection();
            SqlCommand comando = new SqlCommand(@"[TIRANDO_QUERIES].sp_postergar_viajes", conn);

            comando.CommandType = CommandType.StoredProcedure;

            comando.Parameters.AddWithValue("@crucero", IDCrucero);
            comando.Parameters.AddWithValue("@dias", diasADemorar);

            try
            {
                comando.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al ejecutar el store procedure sp_postergar_viajes", ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public static int CancelarViajes(int IDCrucero)
        {

                var conn = Repository.GetConnection();
                SqlCommand comando = new SqlCommand(String.Format(@"UPDATE TIRANDO_QUERIES.Pasaje SET " +
                                                    "pasa_estado=(SELECT ep_codigo FROM [TIRANDO_QUERIES].[Estado_Pasaje] WHERE ep_motivo='Crucero completo VU') " +
                                                    "WHERE pasa_ruta IN (SELECT rv_codigo FROM [TIRANDO_QUERIES].[Ruta_Viaje] WHERE rv_crucero={0} AND [rv_fecha_llegada] IS NULL)", IDCrucero), conn);
            try
            {
                int rows = comando.ExecuteNonQuery();

                conn.Close();
                conn.Dispose();
                comando.Dispose();

                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar cancelar los pasajes del crucero", ex);
            }
        }

        public static int CancelarViajesMantenimiento(int IDCrucero)
        {

            var conn = Repository.GetConnection();
            SqlCommand comando = new SqlCommand(String.Format(@"UPDATE TIRANDO_QUERIES.Pasaje SET " +
                                                "pasa_estado=(SELECT ep_codigo FROM [TIRANDO_QUERIES].[Estado_Pasaje] WHERE ep_motivo='Desperfecto tecnico en crucero') " +
                                                "WHERE pasa_ruta IN (SELECT rv_codigo FROM [TIRANDO_QUERIES].[Ruta_Viaje] WHERE rv_crucero={0} AND [rv_fecha_llegada] IS NULL)", IDCrucero), conn);
            try
            {
                int rows = comando.ExecuteNonQuery();

                conn.Close();
                conn.Dispose();
                comando.Dispose();

                return rows;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar cancelar los pasajes del crucero", ex);
            }
        }

        public static List<RutaDeViaje> ObtenerPasajesSinFinalizar(int IDCrucero)
        {
            var conn = Repository.GetConnection();

            SqlCommand comando = new SqlCommand(
                              @"SELECT * FROM [TIRANDO_QUERIES].[Ruta_Viaje] " +
                               "WHERE [rv_crucero] = @id_crucero AND [rv_fecha_llegada] IS NULL", conn);

            DataTable dataTable = new DataTable();

            comando.Parameters.AddWithValue("@id_crucero", IDCrucero);

            SqlDataAdapter dataAdapter = new SqlDataAdapter()
            {
                SelectCommand = comando
            };

            try
            {
                dataAdapter.Fill(dataTable);
                List<RutaDeViaje> viajes = new List<RutaDeViaje>();

                foreach (DataRow fila in dataTable.Rows)
                {

                    var viaje = new RutaDeViaje
                    {
                        Cod_Ruta = int.Parse(fila["rv_codigo"].ToString()),
                        Crucero = new Crucero()
                        {
                            Cod_Crucero = IDCrucero
                        },
                        Fecha_Inicio = (DateTime)fila["rv_fecha_salida"],
                        Fecha_Fin = fila["rv_fecha_llegada"] is DBNull ? null : (DateTime?)fila["rv_fecha_llegada"],
                        Fecha_Fin_Estimada = (DateTime)fila["rv_fecha_llegada_estimada"],
                        Recorrido = new Recorrido()
                        {
                            Cod_Recorrido = int.Parse(fila["rv_recorrido"].ToString())
                        }
                    };

                    viajes.Add(viaje);
                }

                return viajes;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar obtener los pasajes del crucero", ex);
            }
        }

        public static List<Crucero> GetAllByCruceroReemplazo(int IDCrucero)
        {
            var conn = Repository.GetConnection();
            SqlCommand comando = new SqlCommand(@"[TIRANDO_QUERIES].sp_encontrar_cruceros_reemplazo", conn);

            comando.CommandType = CommandType.StoredProcedure;

            DataTable dataTable = new DataTable();

            comando.Parameters.AddWithValue("@crucero_a_reemplazar", IDCrucero);

            SqlDataAdapter dataAdapter = new SqlDataAdapter()
            {
                SelectCommand = comando
            };

            try
            {
                dataAdapter.Fill(dataTable);
                List<Crucero> cruceros = new List<Crucero>();

                foreach (DataRow fila in dataTable.Rows)
                {
                    var idCrucero = int.Parse(fila["cruc_codigo"].ToString());
                    var idFabricante = int.Parse(fila["cruc_fabricante"].ToString());
                    var idModelo = int.Parse(fila["cruc_modelo"].ToString());

                    var crucero = new Crucero
                    {
                        Cod_Crucero = idCrucero,
                        Cabinas = null,
                        Identificador = fila["cruc_identificador"].ToString(),
                        Fabricante = null,
                        Modelo_Crucero = null,
                        Activo = bool.Parse(fila["cruc_activo"].ToString())
                    };

                    cruceros.Add(crucero);
                }

                return cruceros;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar listar los fabricantes", ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }

        }

        public static Crucero GetByIDSinCabinas(int id)
        {
            var conn = Repository.GetConnection();
            string comando = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Crucero WHERE cruc_codigo = {0}", id);
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                DataRow registroCrucero = dataTable.Rows[0];

                var idCrucero = int.Parse(registroCrucero["cruc_codigo"].ToString());
                var idModelo = int.Parse(registroCrucero["cruc_modelo"].ToString());
                var idFabricante = int.Parse(registroCrucero["cruc_fabricante"].ToString());

                var crucero = new Crucero
                {
                    Cod_Crucero = idCrucero,
                    Activo = bool.Parse(registroCrucero["cruc_activo"].ToString()),
                    Identificador = registroCrucero["cruc_identificador"].ToString(),
                    Modelo_Crucero = ModeloCruceroDAO.GetByID(idModelo),
                    Cabinas = new List<Cabina>(),//CabinaDAO.GetAllForId(idCrucero),
                    Fabricante = FabricanteDAO.GetByID(idFabricante)
                };

                conn.Close();
                conn.Dispose();

                return crucero;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar obtener el crucero", ex);
            }
        }

        public static List<Crucero> GetAllWithFilters(string likeFilter, string exactFilter, int? idDropdown)
        {
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter;

            SqlConnection conn = Repository.GetConnection();
            SqlCommand comando = new SqlCommand(@"select * from TIRANDO_QUERIES.Crucero " +
                                                 "join TIRANDO_QUERIES.Modelo_Crucero on cruc_modelo = mc_codigo " +
                                                 "join TIRANDO_QUERIES.Fabricante on cruc_fabricante = fabr_codigo " +
                                                 "where cruc_activo = 1", conn);

            if (!string.IsNullOrWhiteSpace(likeFilter))
            {
                //Nombre de fabricante, modelo o identificador de crucero
                comando.CommandText += "AND (fabr_detalle like '%' + @likeParameter + '%' OR " +
		                               "     mc_detalle like '%' + @likeParameter + '%' OR " +
		                               "     cruc_identificador like '%' + @likeParameter + '%') ";
                comando.Parameters.AddWithValue("@likeParameter", likeFilter);
            }

            if (!string.IsNullOrWhiteSpace(exactFilter))
            {
                int codigoCrucero;
                if (int.TryParse(exactFilter, out codigoCrucero))
                {
                    comando.CommandText += "AND (cruc_codigo = @exactFilter) ";
                    comando.Parameters.AddWithValue("@exactFilter", codigoCrucero);
                }
                else
                {
                    throw new Exception("El filtro exacto solo admite codigos de crucero");
                }
            }

            if (idDropdown != null && idDropdown != 0)
            {
                //Id de fabricante
                comando.CommandText += "AND fabr_codigo = @idFabricante ";
                comando.Parameters.AddWithValue("@idFabricante", idDropdown.Value);
            }

            try
            {
                dataAdapter = new SqlDataAdapter(comando);
                dataAdapter.Fill(dataTable);
                List<Crucero> cruceros = new List<Crucero>();

                foreach (DataRow fila in dataTable.Rows)
                {
                    var idCrucero = int.Parse(fila["cruc_codigo"].ToString());
                    var idFabricante = int.Parse(fila["cruc_fabricante"].ToString());
                    var idModelo = int.Parse(fila["cruc_modelo"].ToString());

                    var crucero = new Crucero
                    {
                        Cod_Crucero = idCrucero,
                        Cabinas = CabinaDAO.GetAllForId(idCrucero),
                        Identificador = fila["cruc_identificador"].ToString(),
                        Fabricante = FabricanteDAO.GetByID(idFabricante),
                        Modelo_Crucero = ModeloCruceroDAO.GetByID(idModelo),
                        Activo = bool.Parse(fila["cruc_activo"].ToString())
                    };

                    cruceros.Add(crucero);
                }

                dataAdapter.Dispose();
                conn.Dispose();
                conn.Close();

                return cruceros;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al intentar listar los puertos", ex);
            }
        }
    }
}
