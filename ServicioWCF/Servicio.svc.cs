using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using EntidadesCompartidas;


namespace ServicioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Servicio" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione Servicio.svc o Servicio.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class Servicio : IServicio
    {

        #region Articulos

        void IServicio.AgregarArticulo(Articulo A, Usuario u)
        {
            Logica.Fabrica.GetLA().AgregarArticulo(A, u);
        }

        void IServicio.EliminarArticulo(Articulo A)

        {
            Logica.Fabrica.GetLA().EliminarArticulo(A);
        }

        void IServicio.ModificarArticulo(Articulo A)
        {
            Logica.Fabrica.GetLA().ModificarArticulo(A);
        }

        Articulo IServicio.BuscarArticulo(int pCodigo)
        {
            return (Logica.Fabrica.GetLA().BuscarArticulo(pCodigo));
        }

        List<Articulo> IServicio.ListarArticulo()
        {
            return (Logica.Fabrica.GetLA().ListarArticulo());
        }

        #endregion

        #region Factura

        void IServicio.AgregarFactura(Factura F)
        {
            Logica.Fabrica.GetLF().AgregarFactura(F);
        }

        List<Factura> IServicio.ListarFacturas()
        {
            return (Logica.Fabrica.GetLF().ListarFacturas());
        }

        #endregion

        #region Usuario

        void IServicio.Logueo(Usuario U)
        {
            Logica.Fabrica.GetLU().Logueo(U);
        }

        Usuario IServicio.BuscoUsuario(string pUsu)
        {
           return( Logica.Fabrica.GetLU().BuscoUsuario(pUsu));
        }

        #endregion
    }
}
