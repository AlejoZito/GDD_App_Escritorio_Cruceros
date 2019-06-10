using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAL.DAO
{
    public interface IDAO<T>
    {
        T GetByID(int id);
        List<T> GetAll();
        void Add(T t);
        void Edit(T t);
        void Delete(T t);
    }
}
