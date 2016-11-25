using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Views_IniciarProblema : System.Web.UI.Page
{

    Problema problema = new Problema();
    int questaoAtual = 0;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UsuarioOnline"] == null)
            Response.Redirect("/Views/Login.aspx");

        //recupera codigo do problema
        try { problema.IdProblema = int.Parse(Request["p"]); problema.Carregar(problema.IdProblema);  }
        catch { Response.Redirect("~/"); }

        //recupera questao atual, se existir
        try { questaoAtual = int.Parse(Request["q"]); }
        catch { questaoAtual = 0; }


        //header
        HtmlGenericControl texto = new HtmlGenericControl();
        texto.InnerHtml = "<p class='lead'>" + problema.TituloProblema + "<p>" + "<p>" + problema.DescricaoProblema + "</p>";
        header.Controls.Add(texto);

        //marcador de perguntas
        List<Questao> questoes = Questao.carregaQuestoes(problema.IdProblema);
        string porcentagem = (((questaoAtual + 1) / (float)questoes.Count) * 100).ToString() + "%";
        progressbar.Attributes["aria-valuenow"] = porcentagem;
        progressbar.InnerText = porcentagem;
        progressbar.Attributes.CssStyle["width"] = porcentagem;

        //carregador de questão
        HtmlGenericControl questaoTexto = new HtmlGenericControl();
        if (questoes.Count > 1 && questaoAtual <= questoes.Count)
        {
            hrQuestao.InnerText = questoes[questaoAtual].questao;
            panelQuestao.CssClass = "text-center";
        }


        //verifica se é para ir para o próximo
        if (questaoAtual < questoes.Count )
        {
            HyperLink proximo = new HyperLink();
            HtmlGenericControl arrow = new HtmlGenericControl();
            arrow.InnerHtml = "<span class='glyphicon glyphicon-arrow-right' style='font-size:200%;'></span>";
            proximo.CssClass = "btn btn-default bt-lg";
            proximo.NavigateUrl = ResolveUrl("~/Views/IniciarProblema.aspx") + "?p=" + problema.IdProblema + "&q=" + (questaoAtual+1);
            proximo.Controls.Add(arrow);
            panelProximo.Controls.Add(proximo);
            panelProximo.CssClass = "text-center";
        }


    }




}