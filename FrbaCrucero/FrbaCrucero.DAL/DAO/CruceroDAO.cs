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
    public static class CruceroDAO
    {
        public static Crucero GetByID(int id)
        {           
            var conn = Repository.GetConnection();
            string comando = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Crucero WHERE cruc_codigo = {0}", id);
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                DataRow registroCrucero = dataTable.Rows[0];

                var idCrucero = int.Parse(registroCrucero["cruc_codigo"].ToString());
                var idModelo = int.Parse(registroCrucero["cruc_modelo"].ToString());
                var idFabricante = int.Parse(registroCrucero["cruc_fabricante"].ToString());

                var crucero = new Crucero
                {
                    Cod_Crucero = idCrucero,
                    Activo = bool.Parse(registroCrucero["cruc_activo"].ToString()),
                    Identificador = registroCrucero["cruc_identificador"].ToString(),
                    Modelo_Crucero = ModeloCruceroDAO.GetByID(idModelo),
                    Cabinas = CabinaDAO.GetAllForId(idCrucero),
                    Fabricante = FabricanteDAO.GetByID(idFabricante)
                };

                conn.Close();
                conn.Dispose();

                return crucero;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar obtener el crucero", ex);
            }
        }

        public static List<Crucero> GetAll()
        {
            var conn = Repository.GetConnection();
            string comando = @"SELECT * FROM TIRANDO_QUERIES.Crucero WHERE cruc_activo = 1";
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                List<Crucero> cruceros = new List<Crucero>();

                foreach (DataRow fila in dataTable.Rows)
                {
                    var idCrucero = int.Parse(fila["cruc_codigo"].ToString());
                    var idFabricante = int.Parse(fila["cruc_fabricante"].ToString());
                    var idModelo = int.Parse(fila["cruc_modelo"].ToString());

                    var crucero = new Crucero
                    {
                        Cod_Crucero = idCrucero,
                        Cabinas = CabinaDAO.GetAllForId(idCrucero),
                        Identificador = fila["cruc_identificador"].ToString(),
                        Fabricante = FabricanteDAO.GetByID(idFabricante),
                        Modelo_Crucero = ModeloCruceroDAO.GetByID(idModelo),
                        Activo = bool.Parse(fila["cruc_activo"].ToString())
                    };

                    cruceros.Add(crucero);
                }

                conn.Close();
                conn.Dispose();

                return cruceros;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar listar los fabricantes", ex);
            }

            //return new List<Crucero>(){
            //    new Crucero(){
            //        Cod_Crucero = 1,
            //    Fabricante = new Fabricante()
            //    {
            //        Cod_Fabricante = 1,
            //        Detalle = "Motorola"
            //    },
            //    Modelo_Crucero = new ModeloCrucero()
            //    {
            //        Cod_Modelo = 2,
            //        Detalle = "Catamaran"
            //    },
            //    Cabinas = new List<Cabina>(){
            //        new Cabina(){
            //            Cod_Cabina = 2,
            //            Numero = 3,
            //            Piso = 1,
            //            Tipo_Cabina = new TipoCabina(){
            //                Cod_Tipo = 5,
            //                Detalle = "Con cama"
            //                }
            //            }
            //        }
            //    },
            //    new Crucero(){
            //            Cod_Crucero = 2,
            //        Fabricante = new Fabricante()
            //        {
            //            Cod_Fabricante = 1,
            //            Detalle = "A"
            //        },
            //        Modelo_Crucero = new ModeloCrucero()
            //        {
            //            Cod_Modelo = 2,
            //            Detalle = "X"
            //        },
            //        Cabinas = new List<Cabina>(){
            //            new Cabina(){
            //                Cod_Cabina = 2,
            //                Numero = 3,
            //                Piso = 1,
            //                Tipo_Cabina = new TipoCabina(){
            //                    Cod_Tipo = 5,
            //                    Detalle = "B"
            //                }
            //            }
            //        },
            //    }
            //};
        }

        public static void Add(Crucero crucero)
        {
            crucero.Identificador = crucero.Identificador.ToUpper().Trim();

            try
            {
                var conn = Repository.GetConnection();

                //Inserto la cabina y obtengo el id
                SqlCommand comando = new SqlCommand(@"INSERT INTO TIRANDO_QUERIES.Crucero(cruc_identificador, cruc_fabricante, cruc_modelo, cruc_activo) VALUES(@identificador, @fabricante, @modelo, @activo)", conn);
                comando.Parameters.AddWithValue("@identificador", crucero.Identificador);
                comando.Parameters.Add("@fabricante", SqlDbType.Int);
                comando.Parameters["@fabricante"].Value = crucero.Fabricante.Cod_Fabricante;
                comando.Parameters.Add("@modelo", SqlDbType.Int);
                comando.Parameters["@modelo"].Value = crucero.Modelo_Crucero.Cod_Modelo;
                crucero.Activo = true;
                comando.Parameters.Add("@activo", SqlDbType.Bit);
                comando.Parameters["@activo"].Value = crucero.Activo;
                int idCrucero = Convert.ToInt32(comando.ExecuteScalar());

                comando.Dispose();
                conn.Close();
                conn.Dispose();

                //Inserto las cabinas en base con el id de cabina
                CabinaDAO.Add(crucero.Cabinas, idCrucero);

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar crear el crucero", ex);
            }
        }

        public static void Edit(Crucero crucero)
        {
            crucero.Identificador = crucero.Identificador.ToUpper().Trim();

            try
            {
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar editar el crucero");
            }
        }

        public static void Delete(Crucero crucero)
        {
            try
            {
                var conn = Repository.GetConnection();
                SqlCommand comando = new SqlCommand(@"UPDATE TIRANDO_QUERIES.Crucero SET cruc_activo = 0 WHERE cruc_codigo = @idCrucero");
                comando.Parameters.Add("@idCrucero");
                comando.Parameters["@idCrucero"].Value = crucero.Cod_Crucero;
                comando.ExecuteNonQuery();

                conn.Close();
                conn.Dispose();
                comando.Dispose();
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar eliminar el crucero", ex);
            }
        }

        public static bool ExisteCrucero(Crucero crucero)
        {
            string query = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Crucero WHERE cruc_identificador LIKE '{0}'", crucero.Identificador);
            SqlConnection conn = Repository.GetConnection();
            DataTable dataTable = new DataTable();
            SqlDataAdapter dataAdapter = new SqlDataAdapter(query, conn);
            
            dataAdapter.Fill(dataTable);
            conn.Close();
            conn.Dispose();
            
            if (dataTable.Rows.Count == 0)
            {
                return false;
            }

            var filaSinModificar = dataTable.Rows[0];
            int idCrucero = int.Parse(filaSinModificar["cruc_codigo"].ToString());

            if (idCrucero == crucero.Cod_Crucero)
            {
                return false;
            }

            return true;
        }
    }
}
