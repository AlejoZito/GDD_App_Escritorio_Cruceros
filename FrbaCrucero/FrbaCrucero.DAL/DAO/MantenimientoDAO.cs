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
    public class MantenimientoDAO
    {
        public static List<Mantenimiento> GetAllByCruceroID(int idCrucero)
        {
            DataTable dataTable;
            SqlDataAdapter dataAdapter;
            var conn = Repository.GetConnection();

            string comando = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Mantenimiento WHERE mant_crucero = {0}", idCrucero);

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                List<Mantenimiento> mantenimientos = new List<Mantenimiento>();

                foreach (DataRow fila in dataTable.Rows)
                {
                    var codigoMantenimiento = int.Parse(fila["mant_codigo"].ToString());
                    var fecha_desde = DateTime.Parse(fila["mant_fecha_desde"].ToString());
                    var fecha_hasta = DateTime.Parse(fila["mant_fecha_hasta"].ToString());
                    var m = new Mantenimiento
                    {
                        Cod_Mantenimiento = codigoMantenimiento,
                        Fecha_Desde = fecha_desde,
                        Fecha_Hasta = fecha_hasta
                    };
                    mantenimientos.Add(m);
                }

                dataAdapter.Dispose();
                conn.Dispose();
                conn.Close();

                return mantenimientos;
            }

            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al listar los mantenimientos del crucero", ex);
            }
        }

        public static void Add(Mantenimiento m)
        {
            try
            {
                var conn = Repository.GetConnection();

                //Se asume el mantenimiento es desde el dia que lo cargo, en el form va solo el hasta
                SqlCommand comando = new SqlCommand(@"INSERT INTO TIRANDO_QUERIES.Mantenimiento(mant_crucero,mant_fecha_desde,mant_fecha_hasta) values(@crucero,@desde,@hasta)", conn);

                comando.Parameters.AddWithValue("@crucero", m.Crucero);
                comando.Parameters.AddWithValue("@desde", DateTime.Now);
                comando.Parameters.AddWithValue("@hasta", m.Fecha_Hasta);
                comando.ExecuteNonQuery();

                comando.Dispose();
                conn.Close();
                conn.Dispose();

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar agregar el mantenimiento", ex);
            }
        }
    }
}
