using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using EntidadesCompartidas;
using System.Data;
using System.Data.SqlClient;



namespace Persistencia
{
   internal class PersistenciaUsuario:IPersistenciaUsuario
    {
        #region singleton
        private static PersistenciaUsuario _instancia = null;

        private PersistenciaUsuario() { }

        public static PersistenciaUsuario GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaUsuario();

            return _instancia;
        }
        #endregion

        public void Logueo(Usuario U)
        {
            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("Logueo", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@UsuL", U.UsuLog);
            _comando.Parameters.AddWithValue("@PassL", U.PassLog);

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (!_lector.HasRows)
                {
                    throw new Exception("Error - No es correcto el usuario y/o la contraseña");
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
        }

        public Usuario BuscoUsuario(string pUsu)
        {
            Usuario _unU = null;

            SqlConnection _cnn = new SqlConnection(Conexion.Cnn);

            SqlCommand _comando = new SqlCommand("BuscoUsuario", _cnn);
            _comando.CommandType = System.Data.CommandType.StoredProcedure;
            _comando.Parameters.AddWithValue("@Usu", pUsu);

            try
            {
                _cnn.Open();
                SqlDataReader _lector = _comando.ExecuteReader();
                if (_lector.HasRows)
                {
                    _lector.Read();
                    _unU = new Usuario(pUsu, (string)_lector["PassLog"]);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _cnn.Close();
            }
            return _unU;
        }

    }
}
