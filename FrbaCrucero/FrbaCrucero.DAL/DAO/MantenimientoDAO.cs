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
            var conn = Repository.GetConnection();
            SqlCommand comando = new SqlCommand(@"SELECT * FROM [TIRANDO_QUERIES].[Mantenimiento] WHERE [mant_crucero] = @mant_crucero", conn);

            DataTable dataTable = new DataTable();

            comando.Parameters.Add("@mant_crucero", SqlDbType.Int);
            comando.Parameters["@mant_crucero"].Value = idCrucero;

            try
            {
                SqlDataAdapter dataAdapter = new SqlDataAdapter()
                {
                    SelectCommand = comando
                };

                dataAdapter.Fill(dataTable);

                List<Mantenimiento> mantenimientos = new List<Mantenimiento>();

                foreach (DataRow fila in dataTable.Rows)
                {

                    int idMantenimiento = int.Parse(fila["mant_codigo"].ToString());
                    int cruceroID = int.Parse(fila["mant_crucero"].ToString());

                    var mantenimiento = new Mantenimiento
                    {
                        Cod_Mantenimiento = idMantenimiento,
                        Crucero = new Crucero()
                        {
                            Cod_Crucero = cruceroID
                        },
                        Fecha_Desde = (DateTime)fila["mant_fecha_desde"],
                        Fecha_Hasta = (DateTime)fila["mant_fecha_hasta"]
                    };

                    mantenimientos.Add(mantenimiento);
                }

                conn.Close();
                conn.Dispose();

                return mantenimientos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar listar los fabricantes", ex);
            }
        }

        public static void Add(Mantenimiento m)
        {
            try
            {
                var conn = Repository.GetConnection();

                //Inserto la cabina y obtengo el id
                SqlCommand comando = new SqlCommand(@"INSERT INTO [TIRANDO_QUERIES].[Mantenimiento]([mant_crucero], [mant_fecha_desde], [mant_fecha_hasta]) " +
                                                    "VALUES (@mant_crucero, @mant_fecha_desde, @mant_fecha_hasta)", conn);
                comando.Parameters.Add("@mant_crucero", SqlDbType.Int);
                comando.Parameters["@mant_crucero"].Value = m.Crucero.Cod_Crucero;

                comando.Parameters.Add("@mant_fecha_desde", SqlDbType.DateTime);
                comando.Parameters["@mant_fecha_desde"].Value = m.Fecha_Desde;

                comando.Parameters.Add("@mant_fecha_hasta", SqlDbType.DateTime);
                comando.Parameters["@mant_fecha_hasta"].Value = m.Fecha_Hasta;

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
