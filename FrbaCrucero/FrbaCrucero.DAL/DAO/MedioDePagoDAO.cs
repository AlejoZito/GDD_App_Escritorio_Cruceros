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
        private readonly Repository repositorio = new Repository();

        public List<MedioDePago> GetAll()
        {
            DataTable dataTable;
            SqlDataAdapter dataAdapter;
            var conn = repositorio.GetConnection();

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
                        Cod_Medio_De_Pago = (int)fila["pago_codigo"],
                        Medio_De_Pago = fila["pago_medio_pago"].ToString(),
                        Cuotas = (int)fila["pago_cuotas"]
                    });
                }

                return mediosDePago;

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al listar los permisos del rol", ex);
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
