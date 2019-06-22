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
    public static class RolDAO
    {
        public static List<Rol> GetAllForID(int idUsuario)
        {
            DataTable dataTable;
            SqlDataAdapter dataAdapter;
            var conn = Repository.GetConnection();

            string comando = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Rol_Usuario WHERE ru_usua_codigo = {0}", idUsuario);

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                List<Rol> roles = new List<Rol>();

                foreach (DataRow fila in dataTable.Rows)
                {
                    var codigoRol = int.Parse(fila["ru_rol_codigo"].ToString());

                    var rolUsuario = RolDAO.GetByID(codigoRol);

                    roles.Add(rolUsuario);
                }

                dataAdapter.Dispose();
                conn.Dispose();
                conn.Close();

                return roles;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al listar los roles del usuario", ex);
            }
        }

        public static Rol GetByID(int id) 
        {
            var conn = Repository.GetConnection();
            string comando = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Rol WHERE rol_codigo = {0}", id);
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                DataRow registroRol = dataTable.Rows[0];

                var idRol = int.Parse(registroRol["rol_codigo"].ToString());

                var rol = new Rol
                {
                    Activo = bool.Parse(registroRol["rol_activo"].ToString()),
                    Cod_rol = idRol,
                    Nombre = registroRol["rol_nombre"].ToString(),
                    Permisos = PermisoDAO.GetAllForIDRol(idRol)
                };

                conn.Close();
                conn.Dispose();

                return rol;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar obtener el rol", ex);
            }
        }

        public static List<Rol> GetAll()
        {
            var conn = Repository.GetConnection();
            string comando = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Rol");
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(comando, conn);
            List<Rol> roles = new List<Rol>();

            try
            {
                dataAdapter.Fill(dataTable);

                foreach (DataRow fila in dataTable.Rows)
                {
                    int idRol = int.Parse(fila["rol_codigo"].ToString());

                    Rol rol = new Rol
                    {
                        Cod_rol = idRol,
                        Activo = bool.Parse(fila["rol_activo"].ToString()),
                        Nombre = fila["rol_nombre"].ToString(),
                        Permisos = PermisoDAO.GetAllForIDRol(idRol)
                    };

                    roles.Add(rol);
                }

                conn.Close();
                conn.Dispose();
                return roles;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al listar los roles", ex);
            }
        }

        public static void Add(Rol rol)
        {

            if (ValidarExistenciaRol(rol.Nombre))
            {
                throw new Exception("El nombre de rol ya existe");
            }

            try
            {
                var conn = Repository.GetConnection();

                //Inserto el rol y obtengo el ID
                SqlCommand comando = new SqlCommand(@"INSERT INTO TIRANDO_QUERIES.Rol(rol_nombre) values(@nombre); " + "SELECT CAST(scope_identity() AS int)", conn);

                rol.Nombre = rol.Nombre.Trim().ToUpper();
                comando.Parameters.AddWithValue("@nombre", rol.Nombre);
                int idRol = Convert.ToInt32(comando.ExecuteScalar());

                comando.Dispose();
                conn.Close();
                conn.Dispose();

                //Inserto los permisos en base al rol id
                PermisoRolDAO.Add(rol.Permisos, idRol);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar crear el rol", ex);
            }
        }

        public static void Edit(Rol rol)
        {
            var conn = Repository.GetConnection();
            rol.Nombre = rol.Nombre.Trim().ToUpper();

            try
            {
                //Elimino los regitros de la tabla Permiso_Rol que tengan el rol_id a modificar
                SqlCommand comando = new SqlCommand(@"UPDATE TIRANDO_QUERIES.Rol SET rol_nombre = @nombre, rol_activo = @activo WHERE rol_codigo=@rol_id", conn);
                SqlCommand comando2 = new SqlCommand(@"DELETE TIRANDO_QUERIES.Permiso_Rol WHERE pr_rol_codigo=@rol_id", conn);

                //updateo el nombre
                comando.Parameters.AddWithValue("@rol_id", rol.Cod_rol);
                comando.Parameters.AddWithValue("@nombre", rol.Nombre);
                comando.Parameters.Add("@activo", SqlDbType.Bit);
                comando.Parameters["@activo"].Value = rol.Activo;
                comando.ExecuteNonQuery();
                //elimino los registros existentes en Permiso_Rol
                comando2.Parameters.AddWithValue("@rol_id", rol.Cod_rol);
                comando2.ExecuteNonQuery();

                comando2.Dispose();
                conn.Close();
                conn.Dispose();

                //Inserto en la tabla los valores nuevos
                PermisoRolDAO.Add(rol.Permisos, rol.Cod_rol);
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar modificar el puerto", ex);
            }
        }


        public static void Delete(int idRol)
        {
            var conn = Repository.GetConnection();

            try
            {
                //Baja logica
                SqlCommand comando = new SqlCommand(@"UPDATE TIRANDO_QUERIES.Rol SET rol_activo = 0 WHERE rol_codigo=@rol_id", conn);

                comando.Parameters.AddWithValue("@rol_id", idRol);
                comando.ExecuteNonQuery();

                comando.Dispose();
                conn.Close();
                conn.Dispose();

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar eliminar el puerto", ex);
            }
        }

        public static List<Rol> GetAllWithFilters(string likeFilter, string exactFilter, int? idDropdown)
        {
            var conn = Repository.GetConnection();
            SqlCommand comando = new SqlCommand(@"SELECT r.* FROM TIRANDO_QUERIES.Rol r " +
                                                "join TIRANDO_QUERIES.Permiso_Rol on rol_codigo = pr_rol_codigo " +
                                                "join TIRANDO_QUERIES.Permiso on pr_perm_codigo = perm_codigo " +
                                                "where 1=1 ", conn);
            DataTable dataTable = new DataTable();

            if (!string.IsNullOrWhiteSpace(likeFilter))
            {
                comando.CommandText += "AND (rol_nombre like '%' + @likeParameter + '%' OR " +
                                            "perm_nombre like '%' + @likeParameter + '%') ";
                comando.Parameters.AddWithValue("@likeParameter", likeFilter);
            }

            if (!string.IsNullOrWhiteSpace(exactFilter))
            {
                comando.CommandText += "AND rol_codigo = @exactFilter ";
                comando.Parameters.AddWithValue("@exactFilter", exactFilter);
            }

            if (idDropdown != null && idDropdown != 0)
            {
                comando.CommandText += "AND perm_codigo = @codigoPermiso ";
                comando.Parameters.AddWithValue("@codigoPermiso", idDropdown.Value);
            }

            comando.CommandText += "group by r.rol_nombre, r.rol_codigo, r.rol_activo";

            SqlDataAdapter dataAdapter = new SqlDataAdapter()
            {
                SelectCommand = comando
            };

            try
            {
                dataAdapter.Fill(dataTable);
                List<Rol> roles = new List<Rol>();

                foreach (DataRow fila in dataTable.Rows)
                {

                    int idRol = int.Parse(fila["rol_codigo"].ToString());

                    Rol rol = new Rol
                    {
                        Cod_rol = idRol,
                        Activo = bool.Parse(fila["rol_activo"].ToString()),
                        Nombre = fila["rol_nombre"].ToString(),
                        Permisos = PermisoDAO.GetAllForIDRol(idRol)
                    };

                    roles.Add(rol);
                }

                return roles;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar listar los roles", ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        private static bool ValidarExistenciaRol(string nombre)
        {
            try
            {
                string query = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Rol WHERE rol_nombre LIKE @nombre");
                SqlConnection conn = Repository.GetConnection();
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@nombre", nombre.Trim().ToUpper());
                bool existeRol = cmd.ExecuteScalar() != null;
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                return existeRol;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar validar el puerto", ex);
            }
        }
    }
}
