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
                        //mostra os detalhes do problema
                        titulo.InnerText = problema.TituloProblema;
                        descricao.InnerText = problema.DescricaoProblema;
                        atualizacao.InnerText = problema.DataHoraAtualizacao.ToShortDateString() + " " + problema.DataHoraAtualizacao.ToShortTimeString();
                        linha.Attributes["class"] = "row";

                        //mostra todas as questões do problema
                        Table table = new Table();
                        table.CssClass = "superFancyTable";
                        TableHeaderRow hr = new TableHeaderRow();
                        TableHeaderCell hc1 = new TableHeaderCell();
                        TableHeaderCell hc2 = new TableHeaderCell();
                        hc1.Text = "Questão";
                        hc2.Text = "Resposta";
                        hr.Controls.Add(hc1);
                        hr.Controls.Add(hc2);
                        table.Controls.Add(hr);

                        List<Questao> questoes = Questao.carregaQuestoes(codigo);
                        foreach( Questao q in questoes )
                        {
                            TableRow row = new TableRow();
                            TableCell cellQuestao = new TableCell();
                            TableCell cellResposta = new TableCell();
                            cellQuestao.Text = q.questao;
                            cellResposta.Text = q.resposta.ToString();
                            row.Controls.Add(cellQuestao);
                            row.Controls.Add(cellResposta);
                            table.Controls.Add(row);
                        }
                        panelQuestoes.Controls.Add(table);


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

