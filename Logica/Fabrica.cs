using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logica
{
    public class Fabrica
    {
        public static ILogicaArticulo GetLA()
        {
            return LogicaArticulo.GetInstancia();
        }

        public static ILogicaFactura GetLF()
        {
            return LogicaFactura.GetInstancia();
        }

        public static ILogicaUsuario GetLU()
        {
            return LogicaUsuario.GetInstancia();
        }

    }
}
