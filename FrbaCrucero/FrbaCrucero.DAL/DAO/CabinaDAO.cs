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

        public static void Add(Cabina t)
        {
            throw new NotImplementedException();
        }

        public static void Edit(Cabina t)
        {
            throw new NotImplementedException();
        }

        public static void Delete(Cabina t)
        {
            throw new NotImplementedException();
        }
    }
}
