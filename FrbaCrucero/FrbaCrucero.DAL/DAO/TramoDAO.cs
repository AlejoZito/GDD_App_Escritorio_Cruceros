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
    public static class TramoDAO
    {
        public static void Add(IList<Tramo> tramos, int idRecorrido)
        {
            var conn = Repository.GetConnection();
            int orden = 1;
            SqlCommand comando = new SqlCommand();
            
            foreach (var tramo in tramos)
            {
                comando = new SqlCommand(@"INSERT INTO TIRANDO_QUERIES.Tramo(tram_recorrido, tram_puerto_desde, tram_puerto_hasta, tram_precio, tram_orden) VALUES(@cod_recorrido, @cod_puerto_desde, @cod_puerto_hasta, @precio, @orden)", conn);
                comando.Parameters.Add("@tram_recorrido", SqlDbType.Int);
                comando.Parameters["@tram_recorrido"].Value = idRecorrido;
                comando.Parameters.Add("@tram_puerto_desde", SqlDbType.Int);
                comando.Parameters["@tram_puerto_desde"].Value = tramo.Puerto_Desde.Cod_Puerto;
                comando.Parameters.Add("@tram_puerto_hasta", SqlDbType.Int);
                comando.Parameters["@tram_puerto_hasta"].Value = tramo.Puerto_Hasta.Cod_Puerto;
                comando.Parameters.Add("@tram_precio", SqlDbType.Decimal);
                comando.Parameters["@tram_precio"].Value = tramo.Precio;
                comando.Parameters.Add("@tram_orden", SqlDbType.Int);
                comando.Parameters["@tram_orden"].Value = orden;
                orden++;

                comando.ExecuteNonQuery();
            }

            comando.Dispose();
            conn.Close();
            conn.Dispose();
        }

        public static void Edit(IList<Tramo> tramos, int idRecorrido)
        {
            var conn = Repository.GetConnection();
            SqlCommand comando = new SqlCommand(@"DELETE TIRANDO_QUERIES.Tramo WHERE tram_recorrido = @idRecorrido");
            comando.Parameters.Add("@tram_recorrido", SqlDbType.Int);
            comando.Parameters["@tram_recorrido"].Value = idRecorrido;
            comando.ExecuteNonQuery();
            comando.Dispose();
            conn.Close();
            conn.Dispose();

            TramoDAO.Add(tramos, idRecorrido);
        }

        public static IList<Tramo> GetAllForID(int idRecorrido) 
        {
            DataTable dataTable;
            SqlDataAdapter dataAdapter;
            var conn = Repository.GetConnection();
            string comando = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Tramo WHERE tram_recorrido = {0}", idRecorrido);

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                IList<Tramo> tramos = new List<Tramo>();

                foreach (DataRow fila in dataTable.Rows)
                {
                    var codigoPuertoDesde = int.Parse(fila["tram_puerto_desde"].ToString());
                    var codigoPuertoHasta = int.Parse(fila["tram_puerto_hasta"].ToString());

                    var tramo = new Tramo
                    {
                        Orden = int.Parse(fila["tram_orden"].ToString()),
                        Precio = decimal.Parse(fila["tram_precio"].ToString()),
                        Puerto_Desde = PuertoDAO.GetByID(codigoPuertoDesde),
                        Puerto_Hasta = PuertoDAO.GetByID(codigoPuertoHasta),
                        IdRecorrido = int.Parse(fila["tram_recorrido"].ToString())
                    };

                    tramos.Add(tramo);
                }

                dataAdapter.Dispose();
                conn.Dispose();
                conn.Close();

                return tramos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al intentar listar los tramos", ex);
            }
        }

        public static void Delete(Tramo t) 
        {
            throw new NotImplementedException();
        }

        public static Tramo GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public static List<Tramo> GetAll()
        {
            throw new NotImplementedException();
        }

        public static void Add(Tramo t)
        {
            throw new NotImplementedException();
        }

        public static void Edit(Tramo t)
        {
            throw new NotImplementedException();
        }
    }
}
