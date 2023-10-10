using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia
{
    internal class Conexion
    {
        private static string _cnn = "Data Source=.; Initial Catalog = Ventas; Integrated Security = true";

        public static string Cnn
        {
            get { return _cnn; }
        }


        internal static string Con(EntidadesCompartidas.Usuario pUsu = null)
        {
            if (pUsu == null)
                return "Data Source =.; Initial Catalog = VentasM; Integrated Security = true";
            else
                return "Data Source =.; Initial Catalog = Ventas; User="
                    + pUsu.UsuLog + "; Password = '" + pUsu.PassLog + " '";


        }
    }
}
