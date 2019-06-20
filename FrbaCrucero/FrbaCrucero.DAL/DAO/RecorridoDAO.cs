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
            string comando = @"SELECT * FROM TIRANDO_QUERIES.Recorrido WHERE reco_activo = 1";
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

        public static void Delete(Recorrido recorrido)
        {
            try
            {
                var conn = Repository.GetConnection();
                SqlCommand comando = new SqlCommand(@"UPDATE TIRANDO_QUERIES.Recorrido SET reco_activo = 0 WHERE reco_codigo = @idRecorrido");
                comando.Parameters.Add("@idRecorrido");
                comando.Parameters["@idRecorrido"].Value = recorrido.Cod_Recorrido;
                comando.ExecuteNonQuery();

                conn.Close();
                conn.Dispose();
                comando.Dispose();
            }
            catch (Exception ex) 
            {
                throw new Exception("Ocurrió un error al intentar eliminar el recorrido", ex);
            }
        }
    }
}
