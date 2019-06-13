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
    public class RutaDeViajeDAO
    {
        private readonly Repository repositorio = new Repository();

        public RutaDeViaje GetByID(int id)
        {
            return new RutaDeViaje()
            {
                Cod_Ruta = 1,
                Crucero = (new CruceroDAO()).GetByID(1),
                Fecha_Inicio = DateTime.Today,
                Fecha_Fin = null,
                Fecha_Fin_Estimada = DateTime.Today.AddDays(10),
                Recorrido = (new RecorridoDAO()).GetByID(1)
            };

        }

        public List<RutaDeViaje> GetAll()
        {
            var conn = repositorio.GetConnection();
            string comando = @"SELECT * FROM TIRANDO_QUERIES.Ruta_Viaje";
            DataTable dataTable;
            SqlDataAdapter dataAdapter;

            try
            {
                dataAdapter = new SqlDataAdapter(comando, conn);
                dataTable = new DataTable();

                dataAdapter.Fill(dataTable);
                List<RutaDeViaje> recorridos = new List<RutaDeViaje>();

                foreach (DataRow fila in dataTable.Rows)
                {

                    var rutaDeViaje = new RutaDeViaje()
                    {
                        Cod_Ruta = int.Parse(fila["rv_codigo"].ToString()),
                        Crucero = (new CruceroDAO()).GetByID(int.Parse(fila["rv_crucero"].ToString())),
                        Fecha_Inicio = (DateTime)fila["rv_fecha_salida"],
                        Fecha_Fin = fila["rv_fecha_salida"] is DBNull ? null : (DateTime?)fila["rv_fecha_llegada"],
                        Fecha_Fin_Estimada = (DateTime)fila["rv_fecha_llegada_estimada"],
                        Recorrido = (new RecorridoDAO()).GetByID(int.Parse(fila["rv_recorrido"].ToString()))
                    };

                    recorridos.Add(rutaDeViaje);
                };

                return recorridos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar listar los recorridos", ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public List<RutaDeViaje> GetAllWithFilters(string likeFilter, string exactFilter, int? idDropdown)
        {
            var conn = repositorio.GetConnection();
            SqlCommand comando = new SqlCommand(@"SELECT * FROM TIRANDO_QUERIES.Ruta_Viaje " +
                                                "join TIRANDO_QUERIES.Crucero on rv_crucero = cruc_codigo " +
                                                "join TIRANDO_QUERIES.Modelo_Crucero on cruc_modelo = mc_codigo " +
                                                "where 1=1 ", conn);
            DataTable dataTable = new DataTable();
            
            if(!string.IsNullOrWhiteSpace(likeFilter)){
                comando.CommandText += "AND (rv_codigo like '%' + @likeParameter + '%' OR " +
                                            "cruc_identificador like '%' + @likeParameter + '%' OR " +
                                            "mc_detalle like '%' + @likeParameter + '%') ";
                comando.Parameters.AddWithValue("@likeParameter", likeFilter);
            }

            if (!string.IsNullOrWhiteSpace(exactFilter))
            {
                comando.CommandText += "AND rv_codigo = @exactFilter ";
                comando.Parameters.AddWithValue("@exactFilter", exactFilter);
            }

            if (idDropdown != null && idDropdown != 0)
            {
                comando.CommandText += "AND cruc_codigo = @codigoCrucero ";
                comando.Parameters.AddWithValue("@codigoCrucero", idDropdown.Value);
            }

            SqlDataAdapter dataAdapter = new SqlDataAdapter()
            {
                SelectCommand = comando
            };

            try
            {        
                dataAdapter.Fill(dataTable);
                List<RutaDeViaje> recorridos = new List<RutaDeViaje>();

                foreach (DataRow fila in dataTable.Rows)
                {

                    var rutaDeViaje = new RutaDeViaje()
                    {
                        Cod_Ruta = int.Parse(fila["rv_codigo"].ToString()),
                        Crucero = (new CruceroDAO()).GetByID(int.Parse(fila["rv_crucero"].ToString())),
                        Fecha_Inicio = (DateTime)fila["rv_fecha_salida"],
                        Fecha_Fin = fila["rv_fecha_salida"] is DBNull ? null : (DateTime?)fila["rv_fecha_llegada"],
                        Fecha_Fin_Estimada = (DateTime)fila["rv_fecha_llegada_estimada"],
                        Recorrido = (new RecorridoDAO()).GetByID(int.Parse(fila["rv_recorrido"].ToString()))
                    };

                    recorridos.Add(rutaDeViaje);
                };

                return recorridos;
            }
            catch (Exception ex)
            {
                throw new Exception("Ocurrió un error al intentar listar las rutas de viaje", ex);
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
        }

        public void Add(RutaDeViaje t)
        {

        }

        public void Edit(RutaDeViaje t)
        {

        }

        public void Delete(RutaDeViaje t)
        {
            throw new NotImplementedException();
        }
    }
}
