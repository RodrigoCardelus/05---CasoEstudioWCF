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
    internal class LogicaFactura : ILogicaFactura
    {
        #region singleton
        private static LogicaFactura _instancia = null;

        private LogicaFactura() { }

        public static LogicaFactura GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaFactura();

            return _instancia;
        }
        #endregion

        public void AgregarFactura(Factura F)
        {
            Persistencia.Fabrica.GetPF().AgregarFactura(F);
        }

        public List<Factura> ListarFacturas()
        {
            return (Persistencia.Fabrica.GetPF().ListarFacturas());
        }

    }
}
