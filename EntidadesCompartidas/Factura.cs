using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.ServiceModel;
using System.Runtime.Serialization;

namespace EntidadesCompartidas
{
    [DataContract]
    public class Factura
    {
        private int _Nro;
        private DateTime _Fecha;
        private Usuario _UnUsu;
        private List<LineasFactura> _listaL;
 
      [DataMember]
        public int Nro
        {
            get { return _Nro; }
            set {_Nro = value; }
        }

        [DataMember]
        public DateTime Fecha
        {
            get { return _Fecha; }
            set { _Fecha = value; }
        }

        [DataMember]
        public List<LineasFactura> ListaL
        {
            get { return _listaL; }
            set {
                if (value == null)
                    throw new Exception("Una Factura Sin Lineas no se Admite");
                if (value.Count == 0)
                    throw new Exception("Debe seleccionar al menos un articulo obligatoriamente");
                _listaL = value;}
        }

        [DataMember]
        public Usuario UnUsu
        {
            get { return _UnUsu; }
            set {
                if (value == null)
                    throw new Exception("Debe tener el usuario que genero la factura");
                _UnUsu = value; }
        }

        public Factura (int pNro, DateTime pFecha, Usuario pUsu, List<LineasFactura> pLineas)
        {
            Nro = pNro;
            Fecha = pFecha;
            UnUsu = pUsu;
            ListaL = pLineas;
        }

        public Factura() { }

    }
}
