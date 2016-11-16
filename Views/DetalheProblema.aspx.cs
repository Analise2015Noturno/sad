using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class DetalheProblema : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Usuario user = (Usuario)Session["UsuarioOnline"];
        if (user == null) Response.Redirect("~/Views/Login.aspx");
        else
            if (user.Tipo_Usuario != 2) Response.Redirect("~/Views/Logout.aspx");

        //se chegou até aqui e não é postback, então carrega o problema
        if (!Page.IsPostBack)
        {
            if (Request["codigo"] != null)
            {
                int codigo;
                try { codigo = int.Parse(Request["codigo"]); }
                catch { codigo = -1; }

                if (codigo > 0)
                {
                    Problema problema = new Problema();
                    if (problema.Carregar(codigo))
                    {
                        titulo.InnerText = problema.TituloProblema;
                        descricao.InnerText = problema.DescricaoProblema;
                        atualizacao.InnerText = problema.DataHoraAtualizacao.ToShortDateString() + " " + problema.DataHoraAtualizacao.ToShortTimeString();
                        linha.Attributes["class"] = "row";
                    }
                    else
                       Alerta( problema.message );

                }
                else
                    Alerta("Código Inválido");
            }
        }
    }

    private void Alerta(String message)
    {
        alerta.Attributes["class"] =  "alert alert-danger";
        alerta.InnerText = message;
    }

}

