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
    public class RecorridoDAO
    {
        private readonly Repository repositorio = new Repository();

        public void NuevoRecorrido(Recorrido recorrido) 
        {
            ValidarTramos(recorrido.Tramos);

            try
            {
                var conn = repositorio.GetConnection();
                
                //Inserto el recorrido y obtengo el id
                SqlCommand comando = new SqlCommand(@"INSERT INTO TIRANDO_QUERIES.Recorrido(reco_activo) VALUES(@activo)", conn);
                recorrido.Activo = true;
                comando.Parameters.Add("@activo", SqlDbType.Bit);
                comando.Parameters["@activo"].Value = recorrido.Activo;
                int idRecorrido = Convert.ToInt32(comando.ExecuteScalar());
                int orden = 1;

                //Inserto los tramos en base con el id de recorrido
                foreach (Tramo tramo in recorrido.Tramos)
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
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar crear el puerto", ex);
            }
        }

        public void ModificarRecorrido(Recorrido recorridoModificado)
        {
            ValidarTramos(recorridoModificado.Tramos);

            try
            {
                var conn = repositorio.GetConnection();

            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar modificar el recorrido", ex);
            }
        }

        public IList<Recorrido> ListarRecorridos()
        {
            var conn = repositorio.GetConnection();
            string comando = string.Format(@"SELECT FROM TIRANDO_QUERIES.Recorrido as r JOIN TIRANDO_QUERIES.Tramo as t ON r.reco_codigo = t.tram_recorrido JOIN TIRANDO_QUERIES.Puerto as p1 ON t.tram_puerto_desde = p1.puer_codigo JOIN TIRANDO_QUERIES.Puerto as p2 ON t.tram_puerto_hasta = p2.puer_codigo");

            throw new NotImplementedException();
        }

        private void ValidarTramos(IList<Tramo> tramos) 
        {
            if (!tramos.Any())
            {
                throw new Exception("No se han seleccionado tramos");
            }
            else
            {
                foreach (Tramo tramo in tramos)
                {
                    if (tramo.Puerto_Desde.Cod_Puerto == tramo.Puerto_Hasta.Cod_Puerto)
                    {
                        throw new Exception("El puerto desde no puede ser el mismo que el puerto hasta");
                    }
                }
            }
        }
    }
}
