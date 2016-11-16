using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class HomeCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UsuarioOnline"] == null)
            Response.Redirect("/Views/Login.aspx");
    }
     

    protected void btPesquisa_Click(object sender, EventArgs e)
    {
        Problema problema = new Problema();
        problema.TituloProblema = txtPesquisa.Text;
        grdDados.DataSource = problema.Localiza();
        grdDados.DataBind();
    }
}
