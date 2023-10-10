using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

using EntidadesCompartidas;


namespace ServicioWCF
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IServicio" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IServicio
    {
        #region Articulos

        [OperationContract]
        void AgregarArticulo(Articulo A, Usuario u);

        [OperationContract]
        void EliminarArticulo(Articulo A);

        [OperationContract]
        void ModificarArticulo(Articulo A);

        [OperationContract]
        Articulo BuscarArticulo(int pCodigo);

        [OperationContract]
        List<Articulo> ListarArticulo();

        #endregion

        #region Factura

        [OperationContract]
        void AgregarFactura(Factura F);

        [OperationContract]
        List<Factura> ListarFacturas();

        #endregion

        #region Usuario

        [OperationContract]
        void Logueo(Usuario U);

        [OperationContract]
        Usuario BuscoUsuario(string pUsu);
        #endregion
    }
}
