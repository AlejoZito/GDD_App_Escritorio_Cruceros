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
    public class MedioDePagoDAO
    {
        public List<MedioDePago> GetAll()
        {
            DataTable dataTable;
            SqlDataAdapter dataAdapter;
            var conn = Repository.GetConnection();

            dataAdapter = new SqlDataAdapter(@"SELECT pago_codigo, pago_medio_pago, pago_cuotas FROM [TIRANDO_QUERIES].Pago " +
                                            "WHERE pago_codigo <> (select TOP(1)pago_codigo from [TIRANDO_QUERIES].Pago where pago_medio_pago = 'Desconocido')", conn);

            try
            {
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                List<MedioDePago> mediosDePago = new List<MedioDePago>();

                foreach (DataRow fila in dataTable.Rows)
                {
                    mediosDePago.Add(new MedioDePago()
                    {
                        Cod_Medio_De_Pago = int.Parse(fila["pago_codigo"].ToString()),
                        Medio_De_Pago = fila["pago_medio_pago"].ToString(),
                        Cuotas = (int)fila["pago_cuotas"]
                    });
                }

                return mediosDePago;

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al listar los medios de pago", ex);
            }
            finally
            {
                dataAdapter.Dispose();
                conn.Dispose();
                conn.Close();
            }

        }
    }
}
