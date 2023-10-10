using System;
using System.Collections.Generic;
using System.Linq;



public partial class AltaFactura : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            lblError.Text = "";
            txtCantidad.Text = "0";
            txtCodigoArticulo.Text = "";
            btnAgregar.Enabled = false;

            Session["LineasF"] = new List<RefWCF.LineasFactura>();
        }
    }

    protected void btnAgregar_Click(object sender, EventArgs e)
    {
        RefWCF.Factura F = null;

        try
        {
            List< RefWCF.LineasFactura> lineas = (List< RefWCF.LineasFactura>)Session["LineasF"];

            //cargo la factura
            F = new RefWCF.Factura()
            {
                Fecha = Convert.ToDateTime(txtFecha.Text),
                UnUsu = (RefWCF.Usuario)Session["Usuario"],
                ListaL = lineas.ToArray(),
                Nro = Convert.ToInt32(txtNro.Text),
            };
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;
        }

        try
        {
            //agrego la factura
            new RefWCF.ServicioClient().AgregarFactura(F);

            lblError.Text = "Alta con Exito";

            //dejo pronto para otra factura
            txtNro.Text = "";
            txtCantidad.Text = "";
            txtCodigoArticulo.Text = "";

            Session["LineasF"] = new List<RefWCF.LineasFactura>();
            gvProductos.DataSource = Session["LineasF"];
            gvProductos.DataBind();

            btnAgregar.Enabled = false;

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void btnAgregarArticulo_Click(object sender, EventArgs e)
    {
        try
        {
            List<RefWCF.LineasFactura> lineas = (List<RefWCF.LineasFactura>)Session["LineasF"];

            // obtengo y agrego articulo
            int codArt = Convert.ToInt32(txtCodigoArticulo.Text); ;
            int cantidad = Convert.ToInt32(txtCantidad.Text);

            RefWCF.Articulo _unArticulo = new RefWCF.ServicioClient().BuscarArticulo(codArt);

            if (_unArticulo == null)
                throw new Exception("El articulo con el codigo especificado no existe");
            else
            {
                //determino si el codigo esta duplicado
                bool repetido = lineas.Where(a => a.UnArt.CodAr == codArt).Any();

                if (repetido)
                {
                    lblError.Text = "No se agrega el articulo - Ya esta Presente en la Factura";
                    return;
                }

                //creo y agrego la linea de la factura
                RefWCF.LineasFactura _linea = new RefWCF.LineasFactura()
                {
                    UnArt = _unArticulo,
                    Cant = cantidad
                };

                lineas.Add(_linea);

                gvProductos.DataSource = lineas;
                gvProductos.DataBind();

                //habilito poder agregar factura
                btnAgregar.Enabled = true;
            }//fin else
        }//fin try
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
 
}