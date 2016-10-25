using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Diagnostics;

public partial class Site : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UsuarioOnline"] == null)
        {
            dvLogin.Visible = false;
        }
        else
        {
            Usuario user = (Usuario)Session["UsuarioOnline"];
            dvLogin.Visible = true;
            lbNome.Text = user.Nome;
        }
    }
}
