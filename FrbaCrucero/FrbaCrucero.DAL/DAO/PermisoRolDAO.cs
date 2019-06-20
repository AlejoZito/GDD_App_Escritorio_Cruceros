using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAL.DAO
{
    public static class PermisoRolDAO
    {
        public static void Add(IList<Permiso> permisos, int rol_id)
        {
            try
            {
                var conn = Repository.GetConnection();
                SqlCommand comando = new SqlCommand();

                //Inserto el rol y sus permisos                
                foreach (var permiso in permisos)
                {
                    comando = new SqlCommand(@"INSERT INTO TIRANDO_QUERIES.Permiso_Rol(pr_rol_codigo,pr_perm_codigo) values(@idRol,@idPermiso)", conn);
                    comando.Parameters.AddWithValue("@idPermiso",permiso);
                    comando.Parameters.AddWithValue("@idRol", rol_id);
                    comando.ExecuteNonQuery();
                }

                comando.Dispose();
                conn.Close();
                conn.Dispose();

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al registrar el rol y sus permisos", ex);
            }
        }
    }
}
