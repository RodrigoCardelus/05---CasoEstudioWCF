using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class _Default : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        

    }

    
    protected void BtnLogueo_Click(object sender, EventArgs e)
    {
        try
        {
            //obtengo datos y consulto 

            RefWCF.Usuario _unUsu = new RefWCF.Usuario();
            _unUsu.UsuLog = TxtUsuario.Text.Trim();
            _unUsu.PassLog = TxtPass.Text.Trim();     

            new RefWCF.ServicioClient().Logueo(_unUsu);

            //Existe
                Session["Usuario"] = _unUsu;
                Response.Redirect("~/AbmArticulos.aspx");
        }
        catch (Exception ex)
        {
            //sino doy mensaje de error
            LblError.Text = ex.Message;
            TxtPass.Text = "";
            TxtUsuario.Text = "";
        }
    }
}