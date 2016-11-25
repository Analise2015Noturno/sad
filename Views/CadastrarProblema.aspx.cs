using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class CadastrarProblema : System.Web.UI.Page
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

        carregarProblemas();


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
            problema.id_usuario_problema = ((Usuario)Session["UsuarioOnline"]).IdUsuario;

            //decide se vai gravar novo problema ou alterar problema já existent
            if (txtCodigoProblema.Value.Equals(""))
            {
                if (problema.Inserir()) { alerta.Attributes["class"] = "alert alert-success bottom20"; alerta.InnerText = "Problema Cadastrado com Sucesso."; txtTitulo.Value = ""; txtDescricao.Value = ""; txtCodigoProblema.Value = ""; }
                else { alerta.Attributes["class"] = "alert alert-danger bottom20"; alerta.InnerText = problema.message; }
            }
            else
            {
                problema.IdProblema = int.Parse(txtCodigoProblema.Value);
                if (problema.Alterar()) { alerta.Attributes["class"] = "alert alert-success bottom20"; alerta.InnerText = "Problema Alterado com Sucesso."; txtTitulo.Value = ""; txtDescricao.Value = ""; txtCodigoProblema.Value = ""; }
                else { alerta.Attributes["class"] = "alert alert-danger bottom20"; alerta.InnerText = problema.message; }
            }

            carregarProblemas();

        }

    }

    private void carregarProblemas()
    {
        //carregar problemas
        panelProblemas.Controls.Clear();
        Table table = new Table();
        table.CssClass = "superFancyTable";
        TableHeaderRow hr = new TableHeaderRow();
        TableHeaderCell hc1 = new TableHeaderCell();
        TableHeaderCell hc2 = new TableHeaderCell();
        TableHeaderCell hc3 = new TableHeaderCell();
        hc1.Text = "Problema";
        hc2.Text = "Descrição";
        hr.Controls.Add(hc1);
        hr.Controls.Add(hc2);
        hr.Controls.Add(hc3);
        table.Controls.Add(hr);
        List<Problema> problemas = Problema.carregarProblemas();
        foreach (Problema problema in problemas)
        {
            TableRow row = new TableRow();
            TableCell cellNome = new TableCell();
            TableCell cellDescricao = new TableCell();
            TableCell cellToolbar = new TableCell();

            //prepara toolbar
            //prepara toolbar
            HyperLink linkApagar = new HyperLink();
            HyperLink linkEditar = new HyperLink();
            HtmlGenericControl editar = new HtmlGenericControl("span");
            HtmlGenericControl apagar = new HtmlGenericControl("span");
            linkApagar.NavigateUrl = "javascript:apagarProblema(" + problema.IdProblema + ");";
            linkEditar.NavigateUrl = "javascript:editarProblema(" + problema.IdProblema + ");";
            editar.Attributes["class"] = "glyphicon glyphicon-pencil ";
            apagar.Attributes["class"] = "glyphicon glyphicon-trash";
            linkApagar.Controls.Add(apagar);
            linkEditar.Controls.Add(editar);
            linkEditar.Attributes.CssStyle.Add("margin-right", "10px;");
            cellToolbar.Attributes["class"] = "text-center";
            cellToolbar.Controls.Add(linkEditar);
            cellToolbar.Controls.Add(linkApagar);

            cellNome.Text = problema.TituloProblema;
            cellNome.ID = "titulo" + problema.IdProblema;
            cellDescricao.Text = problema.DescricaoProblema;
            cellDescricao.ID = "descricao" + problema.IdProblema;

            row.Controls.Add(cellNome);
            row.Controls.Add(cellDescricao);
            row.Controls.Add(cellToolbar);

            table.Controls.Add(row);
        }
        panelProblemas.Controls.Add(table);
    }
}