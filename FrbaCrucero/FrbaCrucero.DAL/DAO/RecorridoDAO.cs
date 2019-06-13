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
    public class RecorridoDAO : IDAO<Recorrido>
    {
        private readonly Repository repositorio = new Repository();
        private readonly TramoDAO tramoDAO = new TramoDAO();

        public void Add(Recorrido recorrido)
        {
            ValidarTramos(recorrido.Tramos);

            try
            {
                var conn = repositorio.GetConnection();

                //Inserto el recorrido y obtengo el id
                SqlCommand comando = new SqlCommand(@"INSERT INTO TIRANDO_QUERIES.Recorrido(reco_activo) VALUES(@activo)", conn);
                recorrido.Activo = true;
                comando.Parameters.Add("@activo", SqlDbType.Bit);
                comando.Parameters["@activo"].Value = recorrido.Activo;
                int idRecorrido = Convert.ToInt32(comando.ExecuteScalar());

                comando.Dispose();
                conn.Close();
                conn.Dispose();

                //Inserto los tramos en base con el id de recorrido
                tramoDAO.Add(recorrido.Tramos, idRecorrido);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar crear el puerto", ex);
            }
        }

        public void Edit(Recorrido recorridoModificado)
        {
            ValidarTramos(recorridoModificado.Tramos);

            try
            {
                tramoDAO.Edit(recorridoModificado.Tramos, recorridoModificado.Cod_Recorrido);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar modificar el recorrido", ex);
            }
        }

        public List<Recorrido> GetAll()
        {
            var conn = repositorio.GetConnection();
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
                        Tramos = tramoDAO.GetAllForID(idRecorrido)
                    };

                    recorridos.Add(recorrido);
                }

                conn.Close();
                conn.Dispose();

                return recorridos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar listar los recorridos", ex);
            }
        }

        public Recorrido GetByID(int id)
        {
            //return new Recorrido()
            //{
            //    Cod_Recorrido = 2,
            //    Activo = true,
            //    Tramos = new List<Tramo>(){
            //            new Tramo(){
            //                Orden = 1,
            //                Precio = 150,
            //                Puerto_Desde = new Puerto(){
            //                    Cod_Puerto = 8,
            //                    Nombre = "Bangladesh"
            //                },
            //                Puerto_Hasta = new Puerto(){
            //                    Cod_Puerto = 9,
            //                    Nombre = "Zimbabwe",
            //                }
            //            },
            //            new Tramo(){
            //                Orden = 2,
            //                Precio = 200,                            
            //                Puerto_Desde= new Puerto(){
            //                    Cod_Puerto = 9,
            //                    Nombre = "Zimbabwe",
            //                },
            //                Puerto_Hasta = new Puerto(){
            //                    Cod_Puerto = 10,
            //                    Nombre = "Delhi"
            //                },
            //            }
            //        }
            //};
            var conn = repositorio.GetConnection();
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
                    Tramos = tramoDAO.GetAllForID(idRecorrido)
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

        public void Delete(Recorrido recorrido)
        {
            try
            {
                var conn = repositorio.GetConnection();
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

        private void ValidarTramos(IList<Tramo> tramos)
        {
            if (!tramos.Any())
            {
                throw new Exception("No se han seleccionado tramos");
            }
            else
            {
                foreach (Tramo tramo in tramos)
                {
                    if (tramo.Puerto_Desde.Cod_Puerto == tramo.Puerto_Hasta.Cod_Puerto)
                    {
                        throw new Exception("El puerto desde no puede ser el mismo que el puerto hasta");
                    }
                }
            }
        }
    }
}
