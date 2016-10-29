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
       
        Problema problema = new Problema();
        grdDados.DataSource = problema.Localiza();
        grdDados.DataBind();

    }
}
