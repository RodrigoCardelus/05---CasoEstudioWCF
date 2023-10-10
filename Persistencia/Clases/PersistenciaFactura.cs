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
    internal class PersistenciaFactura:IPersistenciaFactura
    {
        #region singleton
        private static PersistenciaFactura _instancia = null;

        private PersistenciaFactura() { }

        public static PersistenciaFactura GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaFactura();

            return _instancia;
        }
        #endregion

        public void AgregarFactura(Factura F)
        {
            SqlConnection oConexion = new SqlConnection(Conexion.Cnn);
            SqlCommand oComando = new SqlCommand("AltaFactura", oConexion);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _numF = new SqlParameter("@numFact", F.Nro);
            SqlParameter _usu = new SqlParameter("@NomUsu ", F.UnUsu.UsuLog);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(_numF);
            oComando.Parameters.Add(_usu);
            oComando.Parameters.Add(_Retorno);

            int oAfectados = -1;
            SqlTransaction _transaccion = null;

            try
            {
                oConexion.Open();
                _transaccion = oConexion.BeginTransaction();
                oComando.Transaction = _transaccion;

                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("EL Usuario no Existe");
                if (oAfectados == -2)
                    throw new Exception("EL Numero de Factura ya existe");

                foreach (LineasFactura L in F.ListaL)
                    PersistenciaLinea.GetInstancia().AgregarLinea(F.Nro, L, _transaccion);

                _transaccion.Commit();
            }
            catch (Exception ex)
            {
                _transaccion.Rollback();
                throw ex;
            }
            finally
            {
                oConexion.Close();
            }
        }

        public List<Factura> ListarFacturas()
        {
            List<Factura> _Lista = new List<Factura>();

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("ListoFacturas", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                while (_Reader.Read())
                {
                    int _nro = (int)_Reader["NumFact"];
                    DateTime _fecha = Convert.ToDateTime(_Reader["FechaFact"]);
                    string _usu = (string)_Reader["UsuLog"];
                    Usuario u = PersistenciaUsuario.GetInstancia().BuscoUsuario(_usu);
                    Factura f = new Factura(_nro, _fecha, u, PersistenciaLinea.GetInstancia().ListarLineas(_nro));
                    _Lista.Add(f);
                }

                _Reader.Close();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                _Conexion.Close();
            }

            return _Lista;
        }

    }
}
