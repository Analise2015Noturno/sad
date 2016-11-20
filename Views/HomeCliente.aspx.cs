﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class HomeCliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["UsuarioOnline"] == null)
            Response.Redirect("/Views/Login.aspx");

        carregarProblemas();
    }
     

    protected void btPesquisa_Click(object sender, EventArgs e)
    {
        Problema problema = new Problema();
        problema.TituloProblema = txtPesquisa.Text;
        grdDados.DataSource = problema.Localiza();
        grdDados.DataBind();
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
            HyperLink linkDetalhes = new HyperLink();
            linkDetalhes.NavigateUrl = ResolveUrl("~/Views/DetalheProblema.aspx") + "?codigo=" + problema.IdProblema;
            linkDetalhes.CssClass = "btn btn-primary";
            linkDetalhes.Text = "Detalhes";
            cellToolbar.Controls.Add(linkDetalhes);

            cellNome.Text = problema.TituloProblema;
            cellNome.ID = "titulo" + problema.IdProblema;
            cellDescricao.Text = problema.DescricaoProblema;
            cellDescricao.ID = "descricao" + problema.IdProblema;
            cellToolbar.CssClass = "text-center";

            row.Controls.Add(cellNome);
            row.Controls.Add(cellDescricao);
            row.Controls.Add(cellToolbar);

            table.Controls.Add(row);
        }
        panelProblemas.Controls.Add(table);
    }

}
