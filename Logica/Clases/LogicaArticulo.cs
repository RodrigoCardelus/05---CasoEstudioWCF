using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using EntidadesCompartidas;
using Persistencia;
using System.Data;
using System.Data.SqlClient;



namespace Logica
{
    internal class LogicaArticulo : ILogicaArticulo
    {
        #region singleton
        private static LogicaArticulo _instancia = null;

        private LogicaArticulo() { }

        public static LogicaArticulo GetInstancia()
        {
            if (_instancia == null)
                _instancia = new LogicaArticulo();

            return _instancia;
        }
        #endregion

        public void AgregarArticulo(Articulo A, Usuario u)
        {
            Persistencia.Fabrica.GetPA().AgregarArticulo(A, u);
        }

        public void EliminarArticulo(Articulo A)
        {
            Persistencia.Fabrica.GetPA().EliminarArticulo(A);
        }

        public void ModificarArticulo(Articulo A)
        {
            Persistencia.Fabrica.GetPA().ModificarArticulo(A);
        }

        public Articulo BuscarArticulo(int pCodigo)
        {
            return (Persistencia.Fabrica.GetPA().BuscarArticulo(pCodigo));
        }

        public List<Articulo> ListarArticulo()
        {
            return (Persistencia.Fabrica.GetPA().ListarArticulo());
        }
    }
}
