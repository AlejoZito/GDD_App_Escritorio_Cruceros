using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAL.DAO
{
    public class TipoCabinaDAO : IDAO<TipoCabina>
    {
        public TipoCabina GetByID(int id)
        {
            return null;
        }

        public List<TipoCabina> GetAll()
        {
            return new List<TipoCabina>(){
                new TipoCabina(){Cod_Tipo = 1, Detalle = "Luxury", Porc_Recargo = 1},
                new TipoCabina(){Cod_Tipo = 2, Detalle = "Turista", Porc_Recargo = 2}
            };
        }

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
