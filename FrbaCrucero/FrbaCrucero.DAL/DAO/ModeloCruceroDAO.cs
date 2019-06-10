using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAL.DAO
{
    public class ModeloCruceroDAO : IDAO<ModeloCrucero>
    {
        public ModeloCrucero GetByID(int id)
        {
            throw new NotImplementedException();
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
