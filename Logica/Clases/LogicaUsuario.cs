using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;



namespace Logica
{
   internal class LogicaUsuario : ILogicaUsuario
    {
        #region singleton
        private static LogicaUsuario _instancia = null;

        private LogicaUsuario() { }

        public static LogicaUsuario GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaUsuario();

            return _instancia;
        }
        #endregion

        public void Logueo(Usuario U)
        {
            Persistencia.Fabrica.GetPU().Logueo(U);
        }

        public Usuario BuscoUsuario(string pUsu)
        {
            return (Persistencia.Fabrica.GetPU().BuscoUsuario(pUsu));
        }

    }
}
