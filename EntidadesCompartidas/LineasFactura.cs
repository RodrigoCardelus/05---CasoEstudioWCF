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
    public class LineasFactura
    {
        private Articulo _UnArt;
        private int _Cant;

        [DataMember]
        public Articulo UnArt
        {
            get { return _UnArt; }
            set {
                if (value == null)
                    throw new Exception("Debe seleccionar un articulo obligatoriamente - Linea Factura");
                _UnArt = value; }
        }

        [DataMember]
        public int Cant
        {
            get { return _Cant; }
            set {
                if (value == 0)
                    throw new Exception("Debe deerminar cantidad vendida - Linea Factura");
                _Cant = value; }
        }


        public LineasFactura(Articulo punArt, int pCant)
        {
            UnArt = punArt;
            Cant = pCant;
        }

        public LineasFactura() { }

    }
}
