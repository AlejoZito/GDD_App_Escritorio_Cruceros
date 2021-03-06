﻿using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAL.DAO
{
    public static class PuertoDAO
    {
        public static void Add(Puerto puerto)
        {
            if (ValidarExistenciaPuerto(puerto.Nombre))
            {
                throw new Exception("El puerto ya existe");
            }

            try
            {
                var conn = Repository.GetConnection();
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

        public static void Edit(Puerto puerto)
        {
            puerto.Nombre = puerto.Nombre.Trim().ToUpper();

            var conn = Repository.GetConnection();
            string select = string.Format(@"SELECT puer_nombre FROM TIRANDO_QUERIES.Puerto WHERE puer_codigo = {0}", puerto.Cod_Puerto);
            SqlDataAdapter dataAdapter = new SqlDataAdapter(select, conn);
            DataTable dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            var filaSinModificar = dataTable.Rows[0];
            var nombreSinModificar = filaSinModificar["puer_nombre"].ToString();

            if (!string.Equals(puerto.Nombre, nombreSinModificar))
            {
                if (ValidarExistenciaPuerto(puerto.Nombre))
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

        public static IList<Puerto> GetAll()
        {
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            SqlConnection conn = Repository.GetConnection();
            string comando = @"SELECT * FROM TIRANDO_QUERIES.Puerto WHERE puer_activo = 1";

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                IList<Puerto> puertos = new List<Puerto>();

                foreach (DataRow fila in dataTable.Rows)
                {
                    var puerto = new Puerto
                    {
                        Cod_Puerto = int.Parse(fila["puer_codigo"].ToString()),
                        Nombre = fila["puer_nombre"].ToString(),
                        Activo = bool.Parse(fila["puer_activo"].ToString())
                    };

                    puertos.Add(puerto);
                }

                dataAdapter.Dispose();
                conn.Dispose();
                conn.Close();

                return puertos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al intentar listar los puertos", ex);
            }
        }

        public static IList<Puerto> GetAllWithFilters(string likeFilter, string exactFilter, int? idDropdown)//ToDo agregar filtros
        {
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            SqlConnection conn = Repository.GetConnection();
            SqlCommand comando = new SqlCommand(@"SELECT * FROM TIRANDO_QUERIES.Puerto where 1 = 1", conn);
            //WHERE puer_activo = 1", conn); Mostrar los inactivos tambien, para poder activarlos.

            if (!string.IsNullOrWhiteSpace(likeFilter))
            {
                comando.CommandText += "AND (puer_codigo like '%' + @likeParameter + '%' OR " +
                                            "puer_nombre like '%' + @likeParameter + '%' ) ";
                comando.Parameters.AddWithValue("@likeParameter", likeFilter);
            }

            if (!string.IsNullOrWhiteSpace(exactFilter))
            {
                int codigoPuerto;
                if (int.TryParse(exactFilter, out codigoPuerto))
                {
                    comando.CommandText += "AND (puer_codigo = @exactFilter)";
                    comando.Parameters.AddWithValue("@exactFilter", codigoPuerto);
                }
                else
                {
                    throw new Exception("El filtro exacto solo admite codigos de puertos");
                }

            }

            if (idDropdown != null && idDropdown != 0)
            {
                //Si es activo, idDropdown viene con "2", si es inactivo con "1"

                comando.CommandText += "AND puer_activo = @puertoActivo ";
                comando.Parameters.AddWithValue("@puertoActivo", idDropdown.Value - 1);
            }

            comando.CommandText += "ORDER BY puer_nombre ASC";

            try
            {
                dataAdapter = new SqlDataAdapter(comando);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                IList<Puerto> puertos = new List<Puerto>();

                foreach (DataRow fila in dataTable.Rows)
                {
                    var puerto = new Puerto
                    {
                        Cod_Puerto = int.Parse(fila["puer_codigo"].ToString()),
                        Nombre = fila["puer_nombre"].ToString(),
                        Activo = bool.Parse(fila["puer_activo"].ToString())
                    };

                    puertos.Add(puerto);
                }

                dataAdapter.Dispose();
                conn.Dispose();
                conn.Close();

                return puertos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al intentar listar los puertos", ex);
            }
        }

        public static Puerto GetByID(int id)
        {
            var conn = Repository.GetConnection();
            string comando = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Puerto WHERE puer_codigo = {0}", id);
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                DataRow registroPuerto = dataTable.Rows[0];

                var idPuerto = int.Parse(registroPuerto["puer_codigo"].ToString());

                var puerto = new Puerto
                {
                    Cod_Puerto = idPuerto,
                    Activo = bool.Parse(registroPuerto["puer_activo"].ToString()),
                    Nombre = registroPuerto["puer_nombre"].ToString()
                };

                conn.Close();
                conn.Dispose();

                return puerto;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar obtener el puerto", ex);
            }
        }

        private static bool ValidarExistenciaPuerto(string nombre)
        {
            try
            {
                string query = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Puerto WHERE puer_nombre LIKE @nombre");
                SqlConnection conn = Repository.GetConnection();
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

        public static void Delete(int id)
        {
            var conn = Repository.GetConnection();
            SqlCommand comando = null;

            try
            {
                if (PuertoEstaEnUso(id))
                {
                    //Baja logica
                    comando = new SqlCommand(@"UPDATE TIRANDO_QUERIES.Puerto SET puer_activo = 0 WHERE puer_codigo=@id", conn);

                    comando.Parameters.AddWithValue("@id", id);
                    comando.ExecuteNonQuery();

                    throw new Exception("El puerto es parte de un recorrido, no puede ser eliminado. El mismo fue desactivado. ");
                }
                else
                {
                    try
                    {
                        comando = new SqlCommand(@"DELETE TIRANDO_QUERIES.Puerto WHERE puer_codigo=@id", conn);

                        comando.Parameters.AddWithValue("@id", id);
                        comando.ExecuteNonQuery();
                    }
                    catch (Exception ex)
                    {
                        throw new Exception("Ocurrió un error al intentar eliminar el puerto", ex);
                    }
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

        private static bool PuertoEstaEnUso(int id)
        {
            List<Tramo> tramosUsandoElPuerto = TramoDAO.GetByIDPuerto(id);
            return (tramosUsandoElPuerto != null && tramosUsandoElPuerto.Count > 0);
        }
    }
}
