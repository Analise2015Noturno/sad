using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class DetalheProblema : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        Usuario user = (Usuario)Session["UsuarioOnline"];
        if (user == null) Response.Redirect("~/Views/Login.aspx");
        else
            if (user.Tipo_Usuario != 2) Response.Redirect("~/Views/Logout.aspx");

        //recupera codigo do problema
        int codigo = 0;
        if (Request["codigo"] != null)
        {
            try { codigo = int.Parse(Request["codigo"]); }
            catch { codigo = -1; }
        }

        //se chegou até aqui e não é postback, então carrega o problema
        if (codigo > 0)
        {
            Problema problema = new Problema();
            if (problema.Carregar(codigo))
            {
                //mostra os detalhes do problema
                titulo.InnerText = problema.TituloProblema;
                descricao.InnerHtml = problema.DescricaoProblema.Replace(Environment.NewLine, "<br />");
                if (problema.DataHoraAtualizacao.Year != 1)
                {
                    atualizacao.InnerText = problema.DataHoraAtualizacao.ToShortDateString() + " " + problema.DataHoraAtualizacao.ToShortTimeString();
                    sectionAtualizacao.Attributes["class"] = "col-md-12";
                }
                else sectionAtualizacao.Attributes.CssStyle["display"] = "none";
                
                linha.Attributes["class"] = "row";

                carregarSolucoes(codigo);
                carregarQuestoes(codigo);
                carregarFeedbacks(codigo);

            }
            else
                Alerta(problema.message);

        }
        else
            Alerta("Código Inválido");
    }


    private void Alerta(String message)
    {
        alerta.Attributes["class"] = "alert alert-danger";
        alerta.InnerText = message;
    }


    protected void btnGravaFeedBack_Click(object sender, EventArgs e)
    {
        bool podeGravar = true;

        if (txtFeedBack.Value.Equals(""))
        {
            sectionFeedBack.Attributes["class"] = "form-group has-error";
            podeGravar = false;
        }

        if (podeGravar)
        {
            Feedback feedback = new Feedback();
            feedback.id_solucao = int.Parse(selSolucoes.SelectedItem.Value);
            feedback.detalhe_feedback = txtFeedBack.Value;
            feedback.id_usuario = ((Usuario)Session["UsuarioOnline"]).IdUsuario;
            if (feedback.Inserir()) { alerta.Attributes["class"] = "alert alert-success bottom20"; alerta.InnerText = "Feedback Cadastrado com Sucesso."; txtFeedBack.Value = ""; }
            else { alerta.Attributes["class"] = "alert alert-danger bottom20"; alerta.InnerText = feedback.message; }

        }

    }

    private void carregarSolucoes(int codigoProblema)
    {
        //mostra todas as soluções do problema
        sectionSolucoes.Controls.Clear();
        List<Solucao> solucoes = Solucao.carregarSolucoes(codigoProblema);
        Panel row = new Panel();
        row.CssClass = "row";
        int iRowController = 0;
        foreach (Solucao solucao in solucoes)
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

            panel.CssClass = "col-md-4 text-center bottom20";
            coluna.CssClass = "col-md-12 caixaFancy";
            texto.Attributes["class"] = "lead";

            coluna.Controls.Add(header);
            coluna.Controls.Add(texto);
            coluna.Controls.Add(link);
            panel.Controls.Add(coluna);
            row.Controls.Add(panel);
            //controlador de linhas
            iRowController++;
            if (iRowController > 0 && (iRowController % 3) == 0)
            {
                sectionSolucoes.Controls.Add(row);
                row = new Panel();
                row.CssClass = "row";
            }

            //aproveita para carregar o dropdownlist também
            selSolucoes.Items.Add(new ListItem(solucao.Nome, solucao.Id.ToString()));

        }
        sectionSolucoes.Controls.Add(row);
    }

    private void carregarQuestoes(int codigoProblema)
    {
        //mostra todas as questões do problema
        Table table = new Table();
        table.CssClass = "invisible";
        TableHeaderRow hr = new TableHeaderRow();
        TableHeaderCell hc1 = new TableHeaderCell();
        TableHeaderCell hc2 = new TableHeaderCell();
        hc1.Text = "Questão";
        hc2.Text = "Resposta";
        hr.Controls.Add(hc1);
        hr.Controls.Add(hc2);
        table.Controls.Add(hr);

        List<Questao> questoes = Questao.carregaQuestoes(codigoProblema);
        foreach (Questao q in questoes)
        {
            TableRow row = new TableRow();
            TableCell cellQuestao = new TableCell();
            TableCell cellResposta = new TableCell();
            cellQuestao.Text = q.questao;
            cellResposta.Text = q.resposta.ToString();
            row.Controls.Add(cellQuestao);
            row.Controls.Add(cellResposta);
            table.Controls.Add(row);
            table.CssClass = "superFancyTable";
        }
        panelQuestoes.Controls.Add(table);
    }

    private void carregarFeedbacks(int codigoProblema)
    {
        Table table = new Table();
        table.CssClass = "invisible";
        TableHeaderRow hr = new TableHeaderRow();
        TableHeaderCell hc1 = new TableHeaderCell();
        TableHeaderCell hc2 = new TableHeaderCell();
        TableHeaderCell hc3 = new TableHeaderCell();
        TableHeaderCell hc4 = new TableHeaderCell();
        hc1.Text = "Solução";
        hc2.Text = "Usuário";
        hc3.Text = "Feedback";
        hc4.Text = "Data";
        hr.Controls.Add(hc1);
        hr.Controls.Add(hc2);
        hr.Controls.Add(hc3);
        hr.Controls.Add(hc4);
        table.Controls.Add(hr);

        List<Feedback> feedbacks = Feedback.carregaFeedBacks(codigoProblema);
        foreach (Feedback f in feedbacks)
        {
            TableRow row = new TableRow();
            TableCell cellSolucao = new TableCell();
            TableCell cellUsuario = new TableCell();
            TableCell cellDetalhe = new TableCell();
            TableCell cellData = new TableCell();
            cellSolucao.Text = f.nome_solucao;
            cellUsuario.Text = f.nome_usuario;
            cellDetalhe.Text = f.detalhe_feedback;
            cellData.Text = f.dt_feedback.ToLocalTime().ToString();
            row.Controls.Add(cellSolucao);
            row.Controls.Add(cellUsuario);
            row.Controls.Add(cellDetalhe);
            row.Controls.Add(cellData);
            table.Controls.Add(row);
            table.CssClass = "superFancyTable";
        }
        panelFeedBacks.Controls.Add(table);
    }

}

