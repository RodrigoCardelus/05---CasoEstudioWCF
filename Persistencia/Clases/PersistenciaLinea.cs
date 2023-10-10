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
    internal class PersistenciaLinea
    {
        #region singleton
        private static PersistenciaLinea _instancia = null;

        private PersistenciaLinea() { }

        public static PersistenciaLinea GetInstancia()
        {
            if (_instancia == null)
                _instancia = new PersistenciaLinea();

            return _instancia;
        }
        #endregion

        internal void AgregarLinea(int nroFact, LineasFactura L, SqlTransaction trn)
        {
            SqlCommand oComando = new SqlCommand("AltaLinea ", trn.Connection);
            oComando.CommandType = CommandType.StoredProcedure;

            SqlParameter _numF = new SqlParameter("@numFact", nroFact);
            SqlParameter _codArt = new SqlParameter("@codArt", L.UnArt.CodAr);
            SqlParameter _cant = new SqlParameter("@cantidad", L.Cant);

            SqlParameter _Retorno = new SqlParameter("@Retorno", SqlDbType.Int);
            _Retorno.Direction = ParameterDirection.ReturnValue;

            oComando.Parameters.Add(_numF);
            oComando.Parameters.Add(_codArt);
            oComando.Parameters.Add(_cant);
            oComando.Parameters.Add(_Retorno);

            int oAfectados = -1;

            try
            {
                oComando.Transaction = trn;
                oComando.ExecuteNonQuery();
                oAfectados = (int)oComando.Parameters["@Retorno"].Value;
                if (oAfectados == -1)
                    throw new Exception("EL Codigo de Articulo no Existe");
                if (oAfectados == -2)
                    throw new Exception("EL Numero de Factura no existe");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        internal List<LineasFactura> ListarLineas(int nroFact)
        {
            List<LineasFactura> _Lista = new List<LineasFactura>();

            SqlConnection _Conexion = new SqlConnection(Conexion.Cnn);
            SqlCommand _Comando = new SqlCommand("ListoLineas", _Conexion);
            _Comando.CommandType = CommandType.StoredProcedure;

            _Comando.Parameters.AddWithValue("@numFact", nroFact);

            SqlDataReader _Reader;
            try
            {
                _Conexion.Open();
                _Reader = _Comando.ExecuteReader();

                while (_Reader.Read())
                {
                    int _cant = (int)_Reader["Cant"];
                    int _codArt = (int)_Reader["CodArt"];
                    Articulo a = PersistenciaArticulo.GetInstancia().BuscarArticulo(_codArt);
                    LineasFactura f = new LineasFactura(a, _cant);
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
