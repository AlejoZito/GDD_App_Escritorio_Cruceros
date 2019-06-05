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
                SqlCommand comando = new SqlCommand("INSERT INTO TIRANDO_QUERIES.Puerto(nombre, activo) values(@nombre, @activo)", conn);

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

        public void ModificarPuerto(Puerto puerto, string nombreSinModificar) 
        {
            puerto.Nombre = puerto.Nombre.Trim().ToUpper();

            if (!string.Equals(puerto.Nombre, nombreSinModificar)) 
            {
                if (ValidarPuerto(puerto.Nombre)) 
                {
                    throw new Exception("El nuevo nombre ingresado corresponde a un puerto ya existente");
                };
            }

            try
            {
                var conn = repositorio.GetConnection();
                SqlCommand comando = new SqlCommand("UPDATE TIRANDO_QUERIES.Puerto SET nombre=@nombre, activo=@activo WHERE cod_puerto=@cod_puerto", conn);

                puerto.Nombre = puerto.Nombre.Trim().ToUpper();
                comando.Parameters.AddWithValue("@nombre", puerto.Nombre);
                puerto.Activo = true;
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

        private bool ValidarPuerto(string nombre)
        {
            try
            {
                string query = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Puerto WHERE nombre LIKE @nombre");
                SqlConnection conn = repositorio.GetConnection();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre.Trim().ToUpper());
                bool existePuerto = cmd.ExecuteScalar() == null;
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
