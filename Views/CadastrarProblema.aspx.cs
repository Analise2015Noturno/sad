using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class CadastrarProblema : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (Session["UsuarioOnline"] == null)
        {
            Response.Redirect("~/Views/Login.aspx");
        }else
        {
            Usuario user = (Usuario)Session["UsuarioOnline"];
            if(user.Tipo_Usuario != 1)
            {
                Response.Redirect("~/Views/Logout.aspx");
            }
        }
    }

    protected void btnGravarProblema_Click(object sender, EventArgs e)
    {
        String titulo = txtTitulo.Value;
        String descricao = txtDescricao.Value;
        bool liberado = true;

        if (txtTitulo.Value.Equals(""))
        {
            formTitulo.Attributes["class"] = "form-group has-error";
            helpBlockTitulo.InnerText = "Título é preenchimento obrigatório";
            liberado = false;
        }


        if (txtDescricao.Value.Equals(""))
        {
            formDescricao.Attributes["class"] = "form-group has-error";
            helpBlockDescricao.InnerText = "Descrição é preenchimento obrigatório";
            liberado = false;
        }

        if (liberado)
        {
            Problema problema = new Problema();

            problema.TituloProblema = txtTitulo.Value;
            problema.DescricaoProblema = txtDescricao.Value;
            Usuario user = (Usuario)Session["UsuarioOnline"];
            problema.id_usuario_problema = user.IdUsuario;

            if ( problema.Inserir() ) { alerta.Attributes["class"] = "alert alert-success bottom20"; alerta.InnerText = "Problema Cadastrado com Sucesso."; txtTitulo.Value = ""; txtDescricao.Value = ""; }
            else { alerta.Attributes["class"] = "alert alert-danger bottom20"; alerta.InnerText = problema.message;  }



        } 

    }
}