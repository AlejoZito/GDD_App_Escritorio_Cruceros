using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAL.DAO
{
    public class FabricanteDAO : IDAO<Fabricante>
    {
        public Fabricante GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<Fabricante> GetAll()
        {
            return new List<Fabricante>(){
                new Fabricante(){Cod_Fabricante = 1, Detalle = "Samsung"},
                new Fabricante(){Cod_Fabricante = 2, Detalle = "Coca cola"}
            };
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
