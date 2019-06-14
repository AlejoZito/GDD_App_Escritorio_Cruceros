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
            //return new Crucero()
            //{
            //    Cod_Crucero = 1,
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
            //            }
            //        }
            //    },
            //};
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
            return new List<Crucero>(){
                new Crucero(){
                    Cod_Crucero = 1,
                Fabricante = new Fabricante()
                {
                    Cod_Fabricante = 1,
                    Detalle = "Motorola"
                },
                Modelo_Crucero = new ModeloCrucero()
                {
                    Cod_Modelo = 2,
                    Detalle = "Catamaran"
                },
                Cabinas = new List<Cabina>(){
                    new Cabina(){
                        Cod_Cabina = 2,
                        Numero = 3,
                        Piso = 1,
                        Tipo_Cabina = new TipoCabina(){
                            Cod_Tipo = 5,
                            Detalle = "Con cama"
                            }
                        }
                    }
                },
                new Crucero(){
                        Cod_Crucero = 2,
                    Fabricante = new Fabricante()
                    {
                        Cod_Fabricante = 1,
                        Detalle = "A"
                    },
                    Modelo_Crucero = new ModeloCrucero()
                    {
                        Cod_Modelo = 2,
                        Detalle = "X"
                    },
                    Cabinas = new List<Cabina>(){
                        new Cabina(){
                            Cod_Cabina = 2,
                            Numero = 3,
                            Piso = 1,
                            Tipo_Cabina = new TipoCabina(){
                                Cod_Tipo = 5,
                                Detalle = "B"
                            }
                        }
                    },
                }
            };
        }

        public static void Add(Crucero t)
        {

        }

        public static void Edit(Crucero t)
        {
            
        }

        public static void Delete(Crucero t)
        {
            throw new NotImplementedException();
        }
    }
}
