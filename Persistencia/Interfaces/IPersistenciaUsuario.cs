using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using EntidadesCompartidas;


namespace Persistencia
{
    public interface IPersistenciaUsuario
    {
        void Logueo(Usuario U);
        Usuario BuscoUsuario(string pUsu);
    }
}
