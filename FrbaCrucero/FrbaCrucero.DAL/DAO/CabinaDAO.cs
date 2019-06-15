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
    public static class CabinaDAO
    {
        public static Cabina GetByID(int id)
        {
            var conn = Repository.GetConnection();
            string comando = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Cabina WHERE cabi_codigo = {0}", id);
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                DataRow registroCabina = dataTable.Rows[0];

                int idCabina = int.Parse(registroCabina["cabi_codigo"].ToString());
                int idCrucero = int.Parse(registroCabina["cabi_crucero"].ToString());
                int idTipoCabina = int.Parse(registroCabina["cabi_cod_tipo"].ToString());

                var cabina = new Cabina
                {
                    Cod_Cabina = idCabina,
                    Numero = int.Parse(registroCabina["cabi_numero"].ToString()),
                    Piso = int.Parse(registroCabina["cabi_piso"].ToString()),
                    Tipo_Cabina = TipoCabinaDAO.GetByID(idTipoCabina),
                    IdCrucero = int.Parse(registroCabina["cabi_crucero"].ToString())
                };

                conn.Close();
                conn.Dispose();

                return cabina;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar obtener la cabina", ex);
            }
        }

        public static List<Cabina> GetByRutaDeViaje(int _RutaDeViajeSeleccionada)
        {
            return new List<Cabina>(){
                new Cabina(){Cod_Cabina = 1, Numero = 1, Piso = 1, Tipo_Cabina = new TipoCabina(){Cod_Tipo = 1, Detalle = "A", Porc_Recargo = 1}},
                new Cabina(){Cod_Cabina = 2, Numero = 2, Piso = 2, Tipo_Cabina = new TipoCabina(){Cod_Tipo = 1, Detalle = "A", Porc_Recargo = 1}},
            };
        }

        public static List<Cabina> GetAllForId(int idCrucero)
        {
            DataTable dataTable;
            SqlDataAdapter dataAdapter;
            var conn = Repository.GetConnection();
            string comando = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Cabina WHERE cabi_crucero = {0}", idCrucero);

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                List<Cabina> cabinas = new List<Cabina>();

                foreach (DataRow fila in dataTable.Rows)
                {
                    var idCabina = int.Parse(fila["cabi_codigo"].ToString());
                    var idTipoCabina = int.Parse(fila["cabi_cod_tipo"].ToString());

                    var cabina = new Cabina
                    {
                        Cod_Cabina = idCabina,
                        Numero = int.Parse(fila["cabi_numero"].ToString()),
                        Tipo_Cabina = TipoCabinaDAO.GetByID(idTipoCabina),
                        Piso = int.Parse(fila["cabi_piso"].ToString()),
                        IdCrucero = int.Parse(fila["cabi_crucero"].ToString())
                    };

                    cabinas.Add(cabina);
                }

                dataAdapter.Dispose();
                conn.Dispose();
                conn.Close();

                return cabinas;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrio un error al intentar listar los tramos", ex);
            }
        }

        public static List<Cabina> GetAll()
        {
            throw new NotImplementedException();
        }

        public static void Add(IList<Cabina> cabinas, int idCrucero)
        {
            var conn = Repository.GetConnection();
            SqlCommand comando = new SqlCommand();

            foreach (var cabina in cabinas)
            {
                comando = new SqlCommand(@"INSERT INTO TIRANDO_QUERIES.Cabina(cabi_numero, cabi_piso, cabi_cod_tipo, cabi_crucero) VALUES(@numero, @piso, @tipoCabina, @idCrucero)", conn);
                comando.Parameters.Add("@cabi_numero", SqlDbType.Int);
                comando.Parameters["@cabi_numero"].Value = cabina.Numero;
                comando.Parameters.Add("@cabi_piso", SqlDbType.Int);
                comando.Parameters["@cabi_piso"].Value = cabina.Piso;
                comando.Parameters.Add("@cabi_cod_tipo", SqlDbType.Int);
                comando.Parameters["@cabi_cod_tipo"].Value = cabina.Tipo_Cabina.Cod_Tipo;
                comando.Parameters.Add("@cabi_crucero", SqlDbType.Int);
                comando.Parameters["@cabi_crucero"].Value = idCrucero;

                comando.ExecuteNonQuery();
            }

            comando.Dispose();
            conn.Close();
            conn.Dispose();
        }

        public static void Edit(IList<Cabina> cabinas, int idCrucero)
        {
            var cabinasAnteriores = CabinaDAO.GetAllForId(idCrucero);
            var cabinasNuevas = cabinas.Except(cabinasAnteriores).ToList();

            CabinaDAO.Add(cabinasNuevas, idCrucero);
        }

        public static void Delete(Cabina t)
        {
            throw new NotImplementedException();
        }
    }
}
