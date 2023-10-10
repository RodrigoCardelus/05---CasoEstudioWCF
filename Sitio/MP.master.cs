using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class MP : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        //verifico si hay usuario logueado
        if (!(Session["Usuario"] is RefWCF.Usuario))
            Response.Redirect("~/default.aspx");
    }

    protected void BtnDeslogueo_Click(object sender, EventArgs e)
    {
        Session["Usuario"] = null;
        Response.Redirect("~/default.aspx");
    }
}
