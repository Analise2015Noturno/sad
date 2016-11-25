using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Views_CadastrarQuestoes : System.Web.UI.Page
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

        if (!Page.IsPostBack)
        {
            List<Problema> problemas = Problema.carregarProblemas();
            foreach (Problema problema in problemas)
            {
                selProblema.Items.Add(new ListItem(problema.TituloProblema, problema.IdProblema.ToString()));
            }
        }

        if (selProblema.SelectedIndex > -1) carregarQuestoes(int.Parse(selProblema.SelectedValue));
    }

    protected void btnGravarQuestao_Click(object sender, EventArgs e)
    {
        bool podeGravar = true;
        int codigoProblema = 0;

        if (txtQuestao.Value.Equals(""))
        {
            formTitulo.Attributes["class"] = "form-group has-error";
            helpBlockQuestao.InnerText = "Questão é preenchimento obrigatório";
            podeGravar = false;
        }
        if (txtResposta.Value.Equals(""))
        {
            formDescricao.Attributes["class"] = "form-group has-error";
            helpBlockResposta.InnerText = "Resposta é preenchimento obrigatório";
            podeGravar = false;
        }
        else
        {
            try
            {
                codigoProblema = int.Parse(txtResposta.Value);
                if( (codigoProblema<0) || (codigoProblema>10) )
                {
                    formDescricao.Attributes["class"] = "form-group has-error";
                    helpBlockResposta.InnerText = "Resposta deve ser entre 0 e 10.";
                    podeGravar = false;
                }
            }
            catch
            {
                formDescricao.Attributes["class"] = "form-group has-error";
                helpBlockResposta.InnerText = "Resposta deve ser númerica.";
                podeGravar = false;
            }
        }

        if (podeGravar)
        {
            Questao questao = new Questao();
            questao.questao = txtQuestao.Value;
            questao.resposta = codigoProblema;
            questao.IdProblema = int.Parse(selProblema.SelectedValue);

            //decide se vai criar um novo registro ou altear um registro antigo
            if (txtCodigoQuestao.Value.Equals(""))
            {
                if (questao.Inserir()) { alerta.Attributes["class"] = "alert alert-success bottom20"; alerta.InnerText = "Solução Cadastrada com Sucesso."; txtQuestao.Value = ""; txtResposta.Value = ""; txtCodigoQuestao.Value = ""; carregarQuestoes(questao.IdProblema); }
                else { alerta.Attributes["class"] = "alert alert-danger bottom20"; alerta.InnerText = questao.message; }
            }
            else
            {
                questao.id_questao = int.Parse(txtCodigoQuestao.Value);
                if (questao.Alterar()) { alerta.Attributes["class"] = "alert alert-success bottom20"; alerta.InnerText = "Solução Alterada com Sucesso."; txtQuestao.Value = ""; txtResposta.Value = ""; txtCodigoQuestao.Value = ""; carregarQuestoes(questao.IdProblema); }
                else { alerta.Attributes["class"] = "alert alert-danger bottom20"; alerta.InnerText = questao.message; }
            }

        }
    }

    protected void selProblema_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCodigoQuestao.Value = "";
        txtQuestao.Value = "";
        txtResposta.Value = "";
        alerta.Attributes["class"] = "invisible";
        carregarQuestoes(int.Parse(selProblema.SelectedValue));
    }

    private void carregarQuestoes(int codigoProblema)
    {
        sectionQuestoes.Controls.Clear();
        List<Questao> questoes = Questao.carregaQuestoes(codigoProblema);
        Table table = new Table();
        table.CssClass = "invisible";
        TableHeaderRow rh = new TableHeaderRow();
        TableHeaderCell hc1 = new TableHeaderCell();
        TableHeaderCell hc2 = new TableHeaderCell();
        TableHeaderCell hc3 = new TableHeaderCell();
        hc1.Text = "Questão";
        hc2.Text = "Resposta";
        rh.Controls.Add(hc1);
        rh.Controls.Add(hc2);
        rh.Controls.Add(hc3);
        table.Controls.Add(rh);

        foreach (Questao questao in questoes)
        {
            TableRow row = new TableRow();
            TableCell cellQuestao = new TableCell();
            TableCell cellResposta = new TableCell();
            TableCell cellToolbar = new TableCell();

            //prepara toolbar
            HyperLink linkApagar = new HyperLink();
            HyperLink linkEditar = new HyperLink();
            HtmlGenericControl editar = new HtmlGenericControl("span");
            HtmlGenericControl apagar = new HtmlGenericControl("span");
            linkApagar.NavigateUrl = "javascript:apagarQuestao(" + questao.id_questao + " , " + questao.IdProblema + ");";
            linkEditar.NavigateUrl = "javascript:editarQuestao(" + questao.id_questao + ");";
            editar.Attributes["class"] = "glyphicon glyphicon-pencil ";
            apagar.Attributes["class"] = "glyphicon glyphicon-trash";
            linkApagar.Controls.Add(apagar);
            linkEditar.Controls.Add(editar);
            linkEditar.Attributes.CssStyle.Add("margin-right", "10px;");
            cellToolbar.Attributes["class"] = "text-center";


            cellQuestao.Text = questao.questao;
            cellQuestao.ID = "questao" + questao.id_questao;
            cellResposta.Text = questao.resposta.ToString();
            cellResposta.ID = "resposta" + questao.id_questao;
            cellToolbar.Controls.Add(linkEditar);
            cellToolbar.Controls.Add(linkApagar);

            row.Controls.Add(cellQuestao);
            row.Controls.Add(cellResposta);
            row.Controls.Add(cellToolbar);

            table.Controls.Add(row);
            table.CssClass = "superFancyTable bottom20";


        }

        sectionQuestoes.Controls.Add(table);
    }


}