using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        dvLoginInvalido.Visible = false;
    }

    protected void Login_Click(object sender, EventArgs e)
    {
        Usuario user = new Usuario();
        user.Cpf = txtEmail.Text;
        user.Email = txtEmail.Text;
        user.Senha = txtSenha.Text;
        if (user.ValidarLogin())
        {
            Session["UsuarioOnline"] = user;
                Response.Redirect("~/");
        }
        else
        {
            dvLoginInvalido.Visible = true;
        }
    }
}