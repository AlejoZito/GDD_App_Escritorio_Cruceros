using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAL.DAO
{
    public class CabinaDAO : IDAO<Cabina>
    {
        public Cabina GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Cabina> GetAll()
        {
            return new List<Cabina>(){
                new Cabina(){Cod_Cabina = 1, Numero = 1, Piso = 1},
                new Cabina(){Cod_Cabina = 2, Numero = 2, Piso = 2},
            };
        }

        public void Add(Cabina t)
        {
            throw new NotImplementedException();
        }
        public void Edit(Cabina t)
        {
            throw new NotImplementedException();
        }
        public void Delete(Cabina t)
        {
            throw new NotImplementedException();
        }

        public List<Cabina> GetByRutaDeViaje(int _RutaDeViajeSeleccionada)
        {
            return new List<Cabina>(){
                new Cabina(){Cod_Cabina = 1, Numero = 1, Piso = 1, Tipo_Cabina = new TipoCabina(){Cod_Tipo = 1, Detalle = "A", Porc_Recargo = 1}},
                new Cabina(){Cod_Cabina = 2, Numero = 2, Piso = 2, Tipo_Cabina = new TipoCabina(){Cod_Tipo = 1, Detalle = "A", Porc_Recargo = 1}},
            };
        }

        public List<Cabina> GetAllForId(int idCrucero)
        {
            throw new NotImplementedException();
        }
    }
}
