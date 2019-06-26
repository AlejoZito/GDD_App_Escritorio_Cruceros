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
            var conn = Repository.GetConnection();
            string comandofake = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Cabina WHERE cabi_codigo = {0}", _RutaDeViajeSeleccionada);

            SqlCommand comando = new SqlCommand(@"SELECT Cabina.[cabi_codigo], Cabina.[cabi_numero], Cabina.[cabi_piso], Cabina.[cabi_cod_tipo], Cabina.[cabi_crucero] " +
                                                "FROM [TIRANDO_QUERIES].[Cabina] Cabina " +
                                                "INNER JOIN [TIRANDO_QUERIES].[Tipo_Cabina] Tipo_Cabina ON Tipo_Cabina.[tc_codigo] = Cabina.cabi_cod_tipo " +
                                                "WHERE " +
                                                "	[cabi_crucero] = (SELECT [rv_crucero] FROM [TIRANDO_QUERIES].[Ruta_Viaje] WHERE [rv_codigo]=@ruta_codigo) AND " +
                                                "	[cabi_codigo] NOT IN ( " +
                                                "		SELECT [pasa_cabina] FROM [TIRANDO_QUERIES].[Pasaje] " +
                                                "		WHERE  " +
                                                "			[pasa_ruta]=@ruta_codigo AND " +
                                                "			[pasa_estado] IN (Select [ep_codigo] FROM [TIRANDO_QUERIES].[Estado_Pasaje] WHERE [ep_estado]='Vigente' OR [ep_estado]='Desconocido') " +
                                                "	) AND " +
                                                "	[cabi_codigo] NOT IN ( " +
                                                "		SELECT [rese_cabina] FROM [TIRANDO_QUERIES].[Reserva] " +
                                                "		WHERE " +
                                                "			[rese_ruta]=@ruta_codigo AND " +
                                                "			[rese_estado] IN (Select [er_codigo] FROM [TIRANDO_QUERIES].[Estado_Reserva] WHERE [er_estado]='Vigente' OR [er_estado]='Desconocido') " +
                                                "	); ", conn);

            DataTable dataTable = new DataTable();
            comando.Parameters.AddWithValue("@ruta_codigo", _RutaDeViajeSeleccionada);
            SqlDataAdapter dataAdapter = new SqlDataAdapter()
            {
                SelectCommand = comando
            };

            try
            {
                dataAdapter.Fill(dataTable);
                List<Cabina> cabinas = new List<Cabina>();

                foreach (DataRow fila in dataTable.Rows)
                {

                    var cabina = new Cabina()
                    {
                        Cod_Cabina = int.Parse(fila["cabi_codigo"].ToString()),
                        Numero = int.Parse(fila["cabi_numero"].ToString()),
                        Piso = int.Parse(fila["cabi_piso"].ToString()),
                        Tipo_Cabina = TipoCabinaDAO.GetByID(int.Parse(fila["cabi_cod_tipo"].ToString())),
                        IdCrucero = int.Parse(fila["cabi_crucero"].ToString())
                    };

                    cabinas.Add(cabina);
                };

                conn.Close();
                conn.Dispose();

                return cabinas;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar obtener las cabinas de la ruta", ex);
            }

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
                comando.Parameters.Add("@numero", SqlDbType.Int);
                comando.Parameters["@numero"].Value = cabina.Numero;
                comando.Parameters.Add("@piso", SqlDbType.Int);
                comando.Parameters["@piso"].Value = cabina.Piso;
                comando.Parameters.Add("@tipoCabina", SqlDbType.Int);
                comando.Parameters["@tipoCabina"].Value = cabina.Tipo_Cabina.Cod_Tipo;
                comando.Parameters.Add("@idCrucero", SqlDbType.Int);
                comando.Parameters["@idCrucero"].Value = idCrucero;

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
