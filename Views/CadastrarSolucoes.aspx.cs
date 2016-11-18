using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Views_CadastrarSolucoes : System.Web.UI.Page
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

        if(!Page.IsPostBack)
        {
            List<Problema> problemas = Problema.carregarProblemas();
            foreach(Problema problema in problemas)
            {
                selProblema.Items.Add(new ListItem(problema.TituloProblema, problema.IdProblema.ToString()));
            }
        }

        if (selProblema.SelectedIndex > -1) carregarSolucoes(int.Parse(selProblema.SelectedValue));

    }

    protected void btnGravarSolucao_Click(object sender, EventArgs e)
    {
        bool podeGravar = true;

        if (txtTitulo.Value.Equals(""))
        {
            formTitulo.Attributes["class"] = "form-group has-error";
            helpBlockTitulo.InnerText = "Título é preenchimento obrigatório";
            podeGravar = false;
        }
        if (txtDescricao.Value.Equals(""))
        {
            formDescricao.Attributes["class"] = "form-group has-error";
            helpBlockDescricao.InnerText = "Descrição é preenchimento obrigatório";
            podeGravar = false;
        }

        if(podeGravar)
        {
            Solucao solucao = new Solucao();
            solucao.Nome = txtTitulo.Value;
            solucao.Descricao = txtDescricao.Value;
            solucao.Link = txtUrl.Value;
            solucao.IdProblema = int.Parse(selProblema.SelectedValue);
            if (solucao.Inserir()) { alerta.Attributes["class"] = "alert alert-success bottom20"; alerta.InnerText = "Solução Cadastrada com Sucesso."; txtTitulo.Value = ""; txtDescricao.Value = ""; txtUrl.Value = ""; carregarSolucoes(solucao.IdProblema); }
            else { alerta.Attributes["class"] = "alert alert-danger bottom20"; alerta.InnerText = solucao.message; }
        }

    }

    protected void selProblema_SelectedIndexChanged(object sender, EventArgs e)
    {
        carregarSolucoes(int.Parse(selProblema.SelectedValue));
    }

    private void carregarSolucoes(int codigoProblema)
    {
        sectionSolucoes.Controls.Clear();
        List<Solucao> solucoes = Solucao.carregarSolucoes(codigoProblema);
        foreach(Solucao solucao in solucoes)
        {
            Panel panel = new Panel();
            Panel coluna = new Panel();
            HtmlGenericControl header = new HtmlGenericControl("h3");
            HtmlGenericControl texto = new HtmlGenericControl("p");
            HyperLink link = new HyperLink();

            header.InnerText = solucao.Nome;
            texto.InnerText = solucao.Descricao;
            link.NavigateUrl = solucao.Link;
            link.Text = solucao.Link;

            panel.CssClass = "col-md-3 text-center bottom20";
            coluna.CssClass = "col-md-12 caixaFancy";
            texto.Attributes["class"] = "lead";

            coluna.Controls.Add(header);
            coluna.Controls.Add(texto);
            coluna.Controls.Add(link);
            panel.Controls.Add(coluna);

            sectionSolucoes.Controls.Add(panel);

        }

    }
}