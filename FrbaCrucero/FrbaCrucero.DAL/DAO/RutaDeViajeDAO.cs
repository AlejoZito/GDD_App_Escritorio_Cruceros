using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAL.DAO
{
    public class RutaDeViajeDAO : IDAO<RutaDeViaje>
    {
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
            return new List<RutaDeViaje>(){
                new RutaDeViaje()
                {
                    Cod_Ruta = 1,
                    Crucero = (new CruceroDAO()).GetByID(1),
                    Fecha_Inicio = DateTime.Today,
                    Fecha_Fin = null,
                    Fecha_Fin_Estimada = DateTime.Today.AddDays(10),
                    Recorrido = (new RecorridoDAO()).GetByID(1)
                },
                new RutaDeViaje()
                {
                    Cod_Ruta = 2,
                    Crucero = (new CruceroDAO()).GetByID(1),
                    Fecha_Inicio = DateTime.Today.AddDays(10),
                    Fecha_Fin = null,
                    Fecha_Fin_Estimada = DateTime.Today.AddDays(25),
                    Recorrido = (new RecorridoDAO()).GetByID(1)
                },
            };
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
