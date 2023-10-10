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
    public class Usuario
    {
        string _UsuLog;
        string _PassLog;

        [DataMember]
        public string UsuLog
        {
            get { return _UsuLog; }
            set {
                if (value.Trim().Length <= 2 && value.Trim().Length > 15)
                    throw new Exception("Error en nombre Usuario");
                _UsuLog = value; }
        }

        [DataMember]
        public string PassLog
        {
            get { return _PassLog; }
            set {
                if (value.Trim().Length <= 2 && value.Trim().Length > 5)
                    throw new Exception("Error en password");
                _PassLog = value; }
        }

        //constructor completo
        public Usuario(string pUsu, string pPass)
        {
            UsuLog = pUsu;
            PassLog = pPass;
        }

        public Usuario() { }
    }
}
