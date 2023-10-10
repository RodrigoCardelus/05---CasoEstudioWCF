using System;
using System.Collections.Generic;
using System.Linq;



public partial class AbmArticulos: System.Web.UI.Page 
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void BtnListar_Click(object sender, EventArgs e)
    {
        try
        {
            //cargo la grilla con la info
            gvListado.DataSource = new RefWCF.ServicioClient().ListarArticulo().ToList();
            gvListado.DataBind();

        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void BtnBuscar_Click(object sender, EventArgs e)
    {
        try
        {

            //busco
            RefWCF.Articulo _unArticulo = new RefWCF.ServicioClient().BuscarArticulo(Convert.ToInt32(txtCodigo.Text));

            //determino accion
            if (_unArticulo == null)
            {
                //no existe articulo es un alta, limpio campos
                txtNombre.Text = "";
                txtPrecio.Text = "";
                BtnAlta.Enabled = true;
                BtnBaja.Enabled = false;
                BtnModificar.Enabled = false;


            }
            else
            {
                //existe, cargo y permito eliminar o modificar
                txtNombre.Text = _unArticulo.NomAr;
                txtPrecio.Text = _unArticulo.Precio.ToString();
                BtnAlta.Enabled = false;
                BtnBaja.Enabled = true;
                BtnModificar.Enabled = true;
                Session["Articulo"] = _unArticulo;
            }
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void BtnAlta_Click(object sender, EventArgs e)
    {
        RefWCF.Articulo A = null;

        try
        {
            A = new RefWCF.Articulo()
            {
                CodAr = Convert.ToInt32(txtCodigo.Text),
                NomAr = txtNombre.Text.Trim(),
                Precio = Convert.ToInt32(txtPrecio.Text)
            };
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
            return;
        }

        try
        {
            new RefWCF.ServicioClient().AgregarArticulo(A, (RefWCF.Usuario)Session["Usuario"]);

            //Si llego aca, todo salio ok
            lblError.Text = "Alta con Exito";

            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCodigo.Text = "";

            BtnAlta.Enabled = false;
            BtnBaja.Enabled = false;
            BtnModificar.Enabled = false;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }

    protected void BtnBaja_Click(object sender, EventArgs e)
    {
        try
        {
            RefWCF.Articulo _unArt = (RefWCF.Articulo)Session["Articulo"];

            new RefWCF.ServicioClient().EliminarArticulo(_unArt);

            //Si llego aca, todo salio ok
            lblError.Text = "Baja con Exito";

            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCodigo.Text = "";

            BtnAlta.Enabled = false;
            BtnBaja.Enabled = false;
            BtnModificar.Enabled = false;
        }
        catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }

    }

    protected void BtnModificar_Click(object sender, EventArgs e)
    {
        try
        {

            //obtengo objeto, y lo modifico. 
            RefWCF.Articulo _unArt = (RefWCF.Articulo)Session["Articulo"];
            _unArt.NomAr = txtNombre.Text.Trim();
            _unArt.Precio = Convert.ToInt32(txtPrecio.Text);

            //ejecuto operacion de actualizar en bd
            new RefWCF.ServicioClient().ModificarArticulo(_unArt);

            //Si llego aca, todo salio ok
            lblError.Text = "Modificacion con Exito";

            txtNombre.Text = "";
            txtPrecio.Text = "";
            txtCodigo.Text = "";

            BtnAlta.Enabled = false;
            BtnBaja.Enabled = false;
            BtnModificar.Enabled = false;
        }
         catch (Exception ex)
        {
            lblError.Text = ex.Message;
        }
    }
}
