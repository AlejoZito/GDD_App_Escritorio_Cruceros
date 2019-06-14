﻿using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAL.DAO
{
    public class ModeloCruceroDAO : IDAO<ModeloCrucero>
    {
        private readonly Repository repositorio = new Repository();

        public ModeloCrucero GetByID(int id)
        {
            var conn = repositorio.GetConnection();
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

        public List<ModeloCrucero> GetAll()
        {
            return new List<ModeloCrucero>(){
                new ModeloCrucero(){Cod_Modelo = 1, Detalle = "Catamaran"},
                new ModeloCrucero(){Cod_Modelo = 2, Detalle = "Lancha a remo"}
            };
        }

        public void Add(ModeloCrucero t)
        {
            throw new NotImplementedException();
        }

        public void Edit(ModeloCrucero t)
        {
            throw new NotImplementedException();
        }

        public void Delete(ModeloCrucero t)
        {
            throw new NotImplementedException();
        }
    }
}
