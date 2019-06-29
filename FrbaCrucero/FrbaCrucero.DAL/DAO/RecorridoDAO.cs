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
    public static class RecorridoDAO
    {
        public static void Add(Recorrido recorrido)
        {
            var conn = Repository.GetConnection();

            //Inserto el recorrido y obtengo el id
            SqlCommand comando = new SqlCommand(@"INSERT INTO TIRANDO_QUERIES.Recorrido(reco_activo) VALUES(@activo); " +
                                                 "SELECT CAST(scope_identity() AS int)", conn);
            try
            {
                recorrido.Activo = true;
                comando.Parameters.Add("@activo", SqlDbType.Bit);
                comando.Parameters["@activo"].Value = recorrido.Activo;
                int idRecorrido = Convert.ToInt32(comando.ExecuteScalar());

                //Inserto los tramos en base con el id de recorrido
                TramoDAO.Add(recorrido.Tramos, idRecorrido);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar crear el recorrido", ex);
            }
            finally
            {
                comando.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }

        public static void Edit(Recorrido recorridoModificado)
        {
            var conn = Repository.GetConnection();
            try
            {

                //Actualizo el campo activo
                SqlCommand comando = new SqlCommand(@"UPDATE TIRANDO_QUERIES.Recorrido set reco_activo = @activo WHERE reco_codigo = @idRecorrido ", conn);

                comando.Parameters.Add("@activo", SqlDbType.Bit);
                comando.Parameters["@activo"].Value = recorridoModificado.Activo;

                comando.Parameters.Add("@idRecorrido", SqlDbType.Int);
                comando.Parameters["@idRecorrido"].Value = recorridoModificado.Cod_Recorrido;

                comando.ExecuteNonQuery();

                //Elimino y reinserto los tramos
                TramoDAO.Edit(recorridoModificado.Tramos, recorridoModificado.Cod_Recorrido);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar modificar el recorrido", ex);
            }
            finally
            {
                conn.Dispose();
            }
        }

        public static List<Recorrido> GetAll()
        {
            var conn = Repository.GetConnection();
            string comando = @"SELECT * FROM TIRANDO_QUERIES.Recorrido";
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                List<Recorrido> recorridos = new List<Recorrido>();

                foreach (DataRow fila in dataTable.Rows)
                {
                    var idRecorrido = int.Parse(fila["reco_codigo"].ToString());

                    var recorrido = new Recorrido
                    {
                        Cod_Recorrido = idRecorrido,
                        Activo = bool.Parse(fila["reco_activo"].ToString()),
                        Tramos = TramoDAO.GetAllForID(idRecorrido)
                    };

                    recorridos.Add(recorrido);
                }

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

        public static List<Recorrido> GetAllWithFilters(string likeFilter, string exactFilter, int? idDropdown)
        {
            var conn = Repository.GetConnection();
            SqlCommand comando = new SqlCommand(@"SELECT r.* FROM TIRANDO_QUERIES.Recorrido r " +
                                                "join TIRANDO_QUERIES.Tramo on r.reco_codigo = tram_recorrido " +
                                                "join TIRANDO_QUERIES.Puerto p1 on tram_puerto_desde = p1.puer_codigo " +
                                                "join TIRANDO_QUERIES.Puerto p2 on tram_puerto_hasta = p2.puer_codigo " +
                                                "where reco_invalido=0 ", conn);
            DataTable dataTable = new DataTable();

            if (!string.IsNullOrWhiteSpace(likeFilter))
            {
                comando.CommandText += "AND (p1.puer_nombre like '%' + @likeParameter + '%' OR " +
                                            "p2.puer_nombre like '%' + @likeParameter + '%') ";
                comando.Parameters.AddWithValue("@likeParameter", likeFilter);
            }

            if (!string.IsNullOrWhiteSpace(exactFilter))
            {
                comando.CommandText += "AND r.reco_codigo = @exactFilter ";
                comando.Parameters.AddWithValue("@exactFilter", exactFilter);
            }

             if (idDropdown != null && idDropdown != 0)
            {
                comando.CommandText += "AND (p1.puer_codigo  = @codigoPuerto OR " +
                                            "p2.puer_codigo  = @codigoPuerto) ";
                comando.Parameters.AddWithValue("@codigoPuerto", idDropdown.Value);
            }
            
            comando.CommandText += "group by r.reco_codigo, r.reco_activo, r.reco_invalido";

            SqlDataAdapter dataAdapter = new SqlDataAdapter()
            {
                SelectCommand = comando
            };

            try
            {
                dataAdapter.Fill(dataTable);
                List<Recorrido> recorridos = new List<Recorrido>();

                foreach (DataRow fila in dataTable.Rows)
                {
                    var idRecorrido = int.Parse(fila["reco_codigo"].ToString());

                    var recorrido = new Recorrido
                    {
                        Cod_Recorrido = idRecorrido,
                        Activo = bool.Parse(fila["reco_activo"].ToString()),
                        Tramos = TramoDAO.GetAllForID(idRecorrido)
                    };

                    recorridos.Add(recorrido);
                }

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

        public static Recorrido GetByID(int id)
        {
            var conn = Repository.GetConnection();
            string comando = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Recorrido WHERE reco_codigo = {0}", id);
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                DataRow registroRecorrido = dataTable.Rows[0];

                var idRecorrido = int.Parse(registroRecorrido["reco_codigo"].ToString());

                var recorrido = new Recorrido
                {
                    Cod_Recorrido = idRecorrido,
                    Activo = bool.Parse(registroRecorrido["reco_activo"].ToString()),
                    Tramos = TramoDAO.GetAllForID(idRecorrido)
                };

                conn.Close();
                conn.Dispose();

                return recorrido;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar obtener el recorrido", ex);
            }
        }

        public static void Delete(int id)
        {            
            var conn = Repository.GetConnection();
            SqlCommand comando = null;

            try
            {
                if (RecorridoEstaEnUso(id))
                {
                    //BAJA LOGICA
                    comando = new SqlCommand(@"UPDATE TIRANDO_QUERIES.Recorrido set reco_activo = 0 WHERE reco_codigo = @idRecorrido ", conn);

                    comando.Parameters.Add("@idRecorrido", SqlDbType.Int);
                    comando.Parameters["@idRecorrido"].Value = id;

                    comando.ExecuteNonQuery();

                    throw new Exception("El recorrido está en uso y no puede ser eliminado. El mismo fue desactivado.");
                }
                else
                {
                    comando = new SqlCommand(@"DELETE TIRANDO_QUERIES.Tramo WHERE tram_recorrido = @idRecorrido
                                               DELETE TIRANDO_QUERIES.Recorrido WHERE reco_codigo = @idRecorrido", conn);
                    comando.Parameters.Add("@idRecorrido", SqlDbType.Int);
                    comando.Parameters["@idRecorrido"].Value = id;
                    comando.ExecuteNonQuery();
                }
            }
            catch (Exception) 
            {
                throw;
            }
            finally
            {
                comando.Dispose();
                conn.Close();
                conn.Dispose();
            }
        }

        private static bool RecorridoEstaEnUso(int id)
        {
            List<RutaDeViaje> rutasDeViaje = RutaDeViajeDAO.GetAllByIDRecorrido(id);
            return rutasDeViaje != null && rutasDeViaje.Count > 0;
        }
    }
}
