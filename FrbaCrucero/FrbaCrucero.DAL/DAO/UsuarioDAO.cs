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
    public static class UsuarioDAO
    {
        public static Usuario AuthenticateUser(Usuario usuario)
        {
            var conn = Repository.GetConnection();

            throw new NotImplementedException();
        }

        public static bool RolUsuarioAdministradorExistente()
        {
            try
            {
                string query = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Rol WHERE rol_nombre LIKE 'Administrativo'");
                SqlConnection conn = Repository.GetConnection();
                SqlCommand cmd = new SqlCommand(query, conn);
                bool existeRol = cmd.ExecuteScalar() != null;
                cmd.Dispose();
                conn.Close();
                conn.Dispose();
                return existeRol;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar validar existencia del rol de administrador", ex);
            }
        }
    }
}
