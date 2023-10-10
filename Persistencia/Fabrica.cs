using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    public class Fabrica
    {
        public static IPersistenciaArticulo GetPA()
        {
            return PersistenciaArticulo.GetInstancia();
        }

        public static IPersistenciaFactura GetPF()
        {
            return PersistenciaFactura.GetInstancia();
        }

        public static IPersistenciaUsuario GetPU()
        {
            return PersistenciaUsuario.GetInstancia();
        }

    }
}
