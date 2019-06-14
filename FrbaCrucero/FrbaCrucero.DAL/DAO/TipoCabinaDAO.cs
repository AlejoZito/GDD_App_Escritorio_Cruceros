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
    public class TipoCabinaDAO : IDAO<TipoCabina>
    {
        private readonly Repository repositorio = new Repository();

        public TipoCabina GetByID(int id)
        {
            var conn = repositorio.GetConnection();
            string comando = string.Format(@"SELECT * FROM TIRANDO_QUERIES.Tipo_Cabina WHERE tc_codigo = {0}", id);
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);

                DataRow registroTipoCabina = dataTable.Rows[0];

                var idTipoCabina = int.Parse(registroTipoCabina["tc_codigo"].ToString());

                var tipoCabina = new TipoCabina
                {
                    Cod_Tipo = idTipoCabina,
                    Detalle = registroTipoCabina["tc_detalle"].ToString(),
                    Porc_Recargo = decimal.Parse(registroTipoCabina["tc_porc_recargo"].ToString())
                };

                conn.Close();
                conn.Dispose();

                return tipoCabina;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar obtener el tipo de cabina", ex);
            }
        }

        public List<TipoCabina> GetAll()
        {
            //return new List<TipoCabina>(){
            //    new TipoCabina(){Cod_Tipo = 1, Detalle = "Luxury", Porc_Recargo = 1},
            //    new TipoCabina(){Cod_Tipo = 2, Detalle = "Turista", Porc_Recargo = 2}
            //};
            var conn = repositorio.GetConnection();
            string comando = @"SELECT * FROM TIRANDO_QUERIES.Tipo_Cabina";
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                List<TipoCabina> tiposDeCabinas = new List<TipoCabina>();

                foreach (DataRow fila in dataTable.Rows)
                {
                    var idTipoCabina = int.Parse(fila["tc_codigo"].ToString());

                    var tipoCabina = new TipoCabina
                    {
                        Cod_Tipo = idTipoCabina,
                        Detalle = fila["tc_detalle"].ToString(),
                        Porc_Recargo = decimal.Parse(fila["tc_porc_recargo"].ToString())
                    };

                    tiposDeCabinas.Add(tipoCabina);
                }

                conn.Close();
                conn.Dispose();

                return tiposDeCabinas;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar listar los tipos de cabina", ex);
            }
        }

        //No se implementan ADD, EDIT, DELETE dado que no tiene un ABM, se mantienen solo por la interfaz de DAO. El conjunto de tipos de cabina 
        //se asume ingresado por base y de selección acotada en abm de cruceros
        public void Add(TipoCabina t)
        {
            throw new NotImplementedException();
        }

        public void Edit(TipoCabina t)
        {
            throw new NotImplementedException();
        }

        public void Delete(TipoCabina t)
        {
            throw new NotImplementedException();
        }
    }
}
