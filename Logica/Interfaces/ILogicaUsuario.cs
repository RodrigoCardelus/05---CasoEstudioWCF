using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using EntidadesCompartidas;


namespace Logica
{
    public interface ILogicaUsuario
    {
        void Logueo(Usuario U);
        Usuario BuscoUsuario(string pUsu);
    }
}
