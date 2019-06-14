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
    public static class ModeloCruceroDAO
    {
        public static ModeloCrucero GetByID(int id)
        {
            var conn = Repository.GetConnection();
            string comando = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Modelo_Crucero WHERE mc_codigo = {0}", id);
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                DataRow registroModelo = dataTable.Rows[0];

                var idModelo = int.Parse(registroModelo["mc_codigo"].ToString());

                var modelo = new ModeloCrucero
                {
                    Cod_Modelo = idModelo,
                    Detalle = registroModelo["mc_detalle"].ToString(),
                };

                conn.Close();
                conn.Dispose();

                return modelo;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar obtener el modelo de crucero", ex);
            }
        }

        public static List<ModeloCrucero> GetAll()
        {
            var conn = Repository.GetConnection();
            string comando = @"SELECT * FROM TIRANDO_QUERIES.Modelo_Crucero";
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                List<ModeloCrucero> modelosDeCruceros = new List<ModeloCrucero>();

                foreach (DataRow fila in dataTable.Rows)
                {
                    var idModeloCrucero = int.Parse(fila["mc_codigo"].ToString());

                    var modeloCrucero = new ModeloCrucero
                    {
                        Cod_Modelo = idModeloCrucero,
                        Detalle = fila["mc_detalle"].ToString(),
                    };

                    modelosDeCruceros.Add(modeloCrucero);
                }

                conn.Close();
                conn.Dispose();

                return modelosDeCruceros;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar listar los modelos de cruceros", ex);
            }
        }

        public static void Add(ModeloCrucero t)
        {
            throw new NotImplementedException();
        }

        public static void Edit(ModeloCrucero t)
        {
            throw new NotImplementedException();
        }

        public static void Delete(ModeloCrucero t)
        {
            throw new NotImplementedException();
        }
    }
}
