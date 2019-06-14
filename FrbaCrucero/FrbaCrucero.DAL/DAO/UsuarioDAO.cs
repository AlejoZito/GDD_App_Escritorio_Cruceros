using FrbaCrucero.DAL.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAL.DAO
{
    public class UsuarioDAO
    {
        public Usuario AuthenticateUser(Usuario usuario)
        {
            var conn = Repository.GetConnection();

            throw new NotImplementedException();
        }

    }
}
