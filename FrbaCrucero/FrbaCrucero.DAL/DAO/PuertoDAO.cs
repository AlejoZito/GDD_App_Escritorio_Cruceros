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
    public class PuertoDAO
    {
        private readonly Repository repositorio = new Repository();

        public void NuevoPuerto(Puerto puerto)
        {
            if (ValidarPuerto(puerto.Nombre))
            {
                throw new Exception("El puerto ya existe");
            }

            try
            {
                var conn = repositorio.GetConnection();
                SqlCommand comando = new SqlCommand(@"INSERT INTO TIRANDO_QUERIES.Puerto(puer_nombre, puer_activo) values(@nombre, @activo)", conn);

                puerto.Nombre = puerto.Nombre.Trim().ToUpper();
                comando.Parameters.AddWithValue("@nombre", puerto.Nombre);
                puerto.Activo = true;
                comando.Parameters.Add("@activo", SqlDbType.Bit);
                comando.Parameters["@activo"].Value = puerto.Activo;
                comando.ExecuteNonQuery();

                comando.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar crear el puerto", ex);
            }
        }

        public void ModificarPuerto(Puerto puerto)
        {
            puerto.Nombre = puerto.Nombre.Trim().ToUpper();

            var conn = repositorio.GetConnection();
            string select = string.Format(@"SELECT puer_nombre FROM TIRANDO_QUERIES.Puerto WHERE puer_codigo = {0}", puerto.Cod_Puerto);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conn);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            var filaSinModificar = dataTable.Rows[0];
            var nombreSinModificar = filaSinModificar["puer_nombre"].ToString();

            if (!string.Equals(puerto.Nombre, nombreSinModificar))
            {
                if (ValidarPuerto(puerto.Nombre))
                {
                    throw new Exception("El nuevo nombre ingresado corresponde a un puerto ya existente");
                };
            }

            try
            {
                SqlCommand comando = new SqlCommand(@"UPDATE TIRANDO_QUERIES.Puerto SET puer_nombre=@nombre, puer_activo=@activo WHERE puer_codigo=@cod_puerto", conn);

                comando.Parameters.AddWithValue("@nombre", puerto.Nombre);
                comando.Parameters.Add("@activo", SqlDbType.Bit);
                comando.Parameters["@activo"].Value = puerto.Activo;
                comando.Parameters.Add("@cod_puerto", SqlDbType.Int);
                comando.Parameters["@cod_puerto"].Value = puerto.Cod_Puerto;
                comando.ExecuteNonQuery();

                comando.Dispose();
                conn.Close();
                conn.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar modificar el puerto", ex);
            }
        }

        public IList<Puerto> ListarPuertos()
        {
            return new List<Puerto>(){
                new Puerto(){
                    Cod_Puerto = 1,
                    Nombre = "BsAs"
                }, new Puerto(){
                    Cod_Puerto = 2,
                    Nombre = "Colonia",
                } , new Puerto(){
                    Cod_Puerto = 3,
                    Nombre = "Porto Allegre"
                }, new Puerto(){
                    Cod_Puerto = 8,
                    Nombre = "Bangladesh"
                }, new Puerto(){
                    Cod_Puerto = 9,
                    Nombre = "Zimbabwe",
                }, new Puerto(){
                    Cod_Puerto = 10,
                    Nombre = "Delhi"
                }
            };
            //DataTable dataTable;
            //SqlDataAdapter dataAdapter;

            //SqlConnection conn = repositorio.GetConnection();
            //string comando = @"SELECT * FROM TIRANDO_QUERIES.Puerto";

            //try
            //{
            //    dataAdapter = new SqlDataAdapter(comando, conn);
            //    dataTable = new DataTable();

            //    dataAdapter.Fill(dataTable);
            //    IList<Puerto> puertos = new List<Puerto>();

            //    foreach (DataRow fila in dataTable.Rows)
            //    {
            //        var puerto = new Puerto
            //        {
            //            Cod_Puerto = int.Parse(fila["puer_codigo"].ToString()),
            //            Nombre = fila["puer_nombre"].ToString(),
            //            Activo = bool.Parse(fila["puer_activo"].ToString())
            //        };

            //        puertos.Add(puerto);
            //    }

            //    dataAdapter.Dispose();
            //    conn.Dispose();
            //    conn.Close();

            //    return puertos;
            //}
            //catch (Exception ex) 
            //{
            //    throw new Exception("Ocurrio un error al intentar listar los puertos", ex);
            //}
        }

        private bool ValidarPuerto(string nombre)
        {
            try
            {
                string query = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Puerto WHERE puer_nombre LIKE @nombre");
                SqlConnection conn = repositorio.GetConnection();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre.Trim().ToUpper());
                bool existePuerto = cmd.ExecuteScalar() != null;
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                return existePuerto;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar validar el puerto", ex);
            }
        }
    }
}
