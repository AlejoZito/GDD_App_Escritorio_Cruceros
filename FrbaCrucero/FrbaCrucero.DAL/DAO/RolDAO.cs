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
    public class RolDAO
    {
        private readonly PermisoDAO permisoDAO = new PermisoDAO();

        public List<Rol> GetAllForID(int idUsuario)
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

                    var rolUsuario = this.GetByID(codigoRol);

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

        public Rol GetByID(int id) 
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
                    Permisos = permisoDAO.GetAllForID(idRol)
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
    }
}
