using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class ListarFacturas : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            try
            {
                Session["ListaFacturas"] = new RefWCF.ServicioClient().ListarFacturas().ToList();

                //cargo la grilla con la info
                dgvFacturas.DataSource = Session["ListaFacturas"];
                dgvFacturas.DataBind();

            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }

        }
    }

    protected void dgvFacturas_SelectedIndexChanged(object sender, EventArgs e)
    {
        try
        {
            //obtengo fuente de datos
            List<RefWCF.Factura> _listaFacturasOriginal = (List<RefWCF.Factura>)Session["ListaFacturas"];
            List<RefWCF.Factura> _listaFacturasFiltro = (List<RefWCF.Factura>)Session["ListaFacturas"];


            //busco datos
            List<RefWCF.LineasFactura> _listaLineas = null;

            if (_listaFacturasFiltro == null) // no hay filtro, uso original completo 
                _listaLineas = _listaFacturasOriginal[dgvFacturas.SelectedIndex].ListaL.ToList();
            else // si hay filtro, uso las facturas asocciadas
                _listaLineas = _listaFacturasFiltro[dgvFacturas.SelectedIndex].ListaL.ToList();

            //cargo la grilla con la info
            dgvLineas.DataSource = _listaLineas;
            dgvLineas.DataBind();

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void BtnFiltro1_Click(object sender, EventArgs e)
    {
        try
        {
            List<RefWCF.Factura> _listaFacturas = (List<RefWCF.Factura>)Session["ListaFacturas"];

            //primero que usuario a buscar exista
            RefWCF.Usuario unU = new RefWCF.ServicioClient().BuscoUsuario(TxtUsu.Text.Trim());
            if (unU == null)
                throw new Exception("No existe Usuario - no se filtra");

            //filtro con linq
            List<RefWCF.Factura> resultado = (from unF in _listaFacturas
                                              where unF.UnUsu.UsuLog == unU.UsuLog
                                              select unF).ToList();


            //muestro resultado y GUARDO EN MEMORIA(lo necesito por las lineas - segunda grilla)
            dgvFacturas.DataSource = resultado;
            dgvFacturas.DataBind();
            Session["Resultado"] = resultado;



        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;

        }
    }

    protected void BtnFiltro2_Click(object sender, EventArgs e)
    {
        try
        {
            List<RefWCF.Factura> _listaFacturas = (List<RefWCF.Factura>)Session["ListaFacturas"];

            //primero que usuario a buscar exista
            RefWCF.Articulo unA = new RefWCF.ServicioClient().BuscarArticulo
                (Convert.ToInt32(TxtArt.Text));

            if (unA == null)
                throw new Exception("No existe Articulo - no se filtra");

            //filtro con linq
            List<RefWCF.Factura> resultado = (from unF in _listaFacturas
                                              from unL in unF.ListaL
                                              where unL.UnArt.CodAr == unA.CodAr
                                              select unF).ToList();


            //muestro resultado y GUARDO EN MEMORIA(lo necesito por las lineas - segunda grilla)
            dgvFacturas.DataSource = resultado;
            dgvFacturas.DataBind();
            Session["Resultado"] = resultado;



        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;

        }
    }

    protected void btnLimpiar_Click(object sender, EventArgs e)
    {
        Session["Resultado"] = null;

        //cargo la grilla con la info
        dgvFacturas.DataSource = (List<RefWCF.Factura>)Session["ListaFacturas"];
        dgvFacturas.DataBind();

    }
} 