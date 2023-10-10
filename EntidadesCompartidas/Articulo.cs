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
     public class Articulo
    {
        private int _codAr;
        private string _nomAr;
        private int _precio;

        [DataMember]
        public int CodAr
        {
            get { return _codAr; }
            set {
                if (value <= 0)
                    throw new Exception("El codigo debe ser positivo");
                _codAr = value;
            }
        }

        [DataMember]
        public string NomAr
        {
            get { return _nomAr; }
            set {
                if (value.Trim().Length <= 2 && value.Trim().Length > 25)
                    throw new Exception("Error en nombre");
                _nomAr = value; }
        }

        [DataMember]
        public Int32 Precio
        {
            get { return _precio; }
            set {
                if (value <= 0)
                    throw new Exception("El precio debe ser positivo");
                _precio = value; }
        }



        public Articulo (int pCod, string pNom, int pPrecio)
        {
            CodAr = pCod;
            NomAr = pNom;
            Precio = pPrecio;
        }

        public Articulo() { }

     }
}
