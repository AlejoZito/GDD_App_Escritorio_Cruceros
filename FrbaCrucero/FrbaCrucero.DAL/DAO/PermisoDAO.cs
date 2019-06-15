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
    public class PermisoDAO
    {
        public Permiso GetByID(int id)
        {
            var conn = Repository.GetConnection();
            string comando = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Permiso WHERE perm_codigo = {0}", id);
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                DataRow registroPermiso = dataTable.Rows[0];

                var permiso = new Permiso
                {
                    Cod_Permiso = int.Parse(registroPermiso["perm_codigo"].ToString()),
                    Nombre = registroPermiso["perm_nombre"].ToString(),
                };

                conn.Close();
                conn.Dispose();

                return permiso;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar obtener el permiso", ex);
            }
        }

        public List<Permiso> GetAllForIDRol(int idRol) 
        {
            DataTable dataTable;
            SqlDataAdapter dataAdapter;
            var conn = Repository.GetConnection();

            string comando = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Permiso_Rol WHERE pr_rol_codigo = {0}", idRol);

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                List<Permiso> permisos = new List<Permiso>();

                foreach (DataRow fila in dataTable.Rows)
                {
                    var codigoPermiso = int.Parse(fila["pr_perm_codigo"].ToString());

                    var permiso = this.GetByID(codigoPermiso);

                    permisos.Add(permiso);
                }

                dataAdapter.Dispose();
                conn.Dispose();
                conn.Close();

                return permisos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al listar los permisos del rol", ex);
            }
        }
    }
}
