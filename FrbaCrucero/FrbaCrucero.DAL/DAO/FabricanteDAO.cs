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
    public class FabricanteDAO : IDAO<Fabricante>
    {
        private readonly Repository repositorio = new Repository();

        public Fabricante GetByID(int id)
        {
            var conn = repositorio.GetConnection();
            string comando = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Fabricante WHERE fabr_codigo = {0}", id);
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                DataRow registroFabricante = dataTable.Rows[0];

                var idFabricante = int.Parse(registroFabricante["fabr_codigo"].ToString());

                var fabricante = new Fabricante
                {
                    Cod_Fabricante = idFabricante,
                    Detalle = registroFabricante["fabr_detalle"].ToString(),
                };

                conn.Close();
                conn.Dispose();

                return fabricante;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar obtener el fabricante", ex);
            }
        }

        public List<Fabricante> GetAll()
        {
            var conn = repositorio.GetConnection();
            string comando = @"SELECT * FROM TIRANDO_QUERIES.Fabricante";
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                List<Fabricante> fabricantes = new List<Fabricante>();

                foreach (DataRow fila in dataTable.Rows)
                {
                    var idFabricante = int.Parse(fila["fabr_codigo"].ToString());

                    var fabricante = new Fabricante
                    {
                        Cod_Fabricante = idFabricante,
                        Detalle = fila["fabr_detalle"].ToString(),
                    };

                    fabricantes.Add(fabricante);
                }

                conn.Close();
                conn.Dispose();

                return fabricantes;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar listar los fabricantes", ex);
            }
        }

        public void Add(Fabricante t)
        {
            throw new NotImplementedException();
        }

        public void Edit(Fabricante t)
        {
            throw new NotImplementedException();
        }

        public void Delete(Fabricante t)
        {
            throw new NotImplementedException();
        }
    }
}
