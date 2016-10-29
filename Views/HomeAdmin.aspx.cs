using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomeAdmin : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UsuarioOnline"] == null)
        {
            Response.Redirect("~/Views/Login.aspx");
        }
        else
        {
            Usuario user = (Usuario)Session["UsuarioOnline"];
            if (user.Tipo_Usuario != 1)
            {
                Response.Redirect("~/Views/Logout.aspx");
            }
        }
    }
    protected void CadastrarProblema()
    {
        Response.Redirect("~/Views/CadastrarProblema.aspx");
    }
    protected void ManututencaoProblema()
    {
        Response.Redirect("~/Views/ManutencaoProblema.aspx");
    }
}