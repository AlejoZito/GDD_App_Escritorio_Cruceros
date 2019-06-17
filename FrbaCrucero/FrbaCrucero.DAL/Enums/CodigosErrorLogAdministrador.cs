using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrbaCrucero.DAL.Enums
{
    public enum CodigosErrorLogAdministrador
    {
        UsuarioBloqueado = -3,
        UsuarioInexistente = -2,
        UsuarioContraseniaIncorrectas = -1,
        UsuarioCorrecto = 1
    }
}
