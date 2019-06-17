using FrbaCrucero.DAL.Domain;
using FrbaCrucero.DAL.Enums;
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
            SqlConnection conn = Repository.GetConnection();
            SqlCommand cmd = new SqlCommand("TIRANDO_QUERIES.sp_autenticar_usuario", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@username", usuario.Username);
            cmd.Parameters.AddWithValue("@password", usuario.Password);
            SqlParameter ret = new SqlParameter();
            ret.Direction = ParameterDirection.ReturnValue;
            cmd.Parameters.Add(ret);
            cmd.ExecuteReader();

            switch ((int)ret.Value)
            {
                case (int)CodigosErrorLogAdministrador.UsuarioBloqueado:
                    cmd.Dispose();
                    conn.Close();
                    conn.Dispose();
                    throw new Exception("Usuario bloqueado, debe esperar 10 minutos para volver a intentarlo");
                case (int)CodigosErrorLogAdministrador.UsuarioContraseniaIncorrectas:
                    cmd.Dispose();
                    conn.Close();
                    conn.Dispose();
                    throw new Exception("Usuario o contraseña incorrectos");
                case (int)CodigosErrorLogAdministrador.UsuarioInexistente:
                    cmd.Dispose();
                    conn.Close();
                    conn.Dispose();
                    throw new Exception("Usuario no existente");
                case (int)CodigosErrorLogAdministrador.UsuarioCorrecto:
                    cmd.Dispose();
                    conn.Close();
                    conn.Dispose();
                    //Restauro conexión para limpiar dataReader
                    conn = Repository.GetConnection();
                    SqlCommand comando = new SqlCommand(@"SELECT * FROM TIRANDO_QUERIES.Usuario WHERE usua_username = @username", conn);
                    comando.Parameters.AddWithValue("@username", usuario.Username);
                    DataTable dataTable = new DataTable();
                    SqlDataAdapter dataAdapter = new SqlDataAdapter(comando);
                    dataAdapter.Fill(dataTable);
                    DataRow registroUsuario = dataTable.Rows[0];
                    int codigoUsuario = int.Parse(registroUsuario["usua_codigo"].ToString());

                    var usuarioLoggeado = new Usuario
                    {
                        Cod_Usuario = codigoUsuario,
                        Roles = RolDAO.GetAllForID(codigoUsuario),
                        Username = registroUsuario["usua_username"].ToString()
                    };
                    
                    comando.Dispose();
                    conn.Close();
                    conn.Dispose();
                    return usuarioLoggeado;
                default:
                    throw new Exception("Ocurrió un error al intentar loggear en la aplicación");
            }
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
