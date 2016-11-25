using System;
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
        TableHeaderCell hc0 = new TableHeaderCell();
        TableHeaderCell hc1 = new TableHeaderCell();
        TableHeaderCell hc3 = new TableHeaderCell();
        hc1.Text = "Problema";
        hr.Controls.Add(hc0);
        hr.Controls.Add(hc1);
        hr.Controls.Add(hc3);
        table.Controls.Add(hr);
        List<Problema> problemas = Problema.carregarProblemas();
        foreach (Problema problema in problemas)
        {
            TableRow row = new TableRow();
            TableCell cellProblema = new TableCell();
            TableCell cellToolbar = new TableCell();
            TableCell cellInicio = new TableCell();

            //prepara botões
            HyperLink linkDetalhes = new HyperLink();
            HyperLink linkIniciar = new HyperLink();
            linkIniciar.NavigateUrl = ResolveUrl("~/Views/IniciarProblema.aspx") + "?p=" + problema.IdProblema;
            linkDetalhes.NavigateUrl = ResolveUrl("~/Views/DetalheProblema.aspx") + "?codigo=" + problema.IdProblema;
            linkIniciar.CssClass = "btn btn-success";
            linkDetalhes.CssClass = "btn btn-primary";
            linkIniciar.Text = "Iniciar";
            linkDetalhes.Text = "Detalhes";
            cellInicio.Controls.Add(linkIniciar);
            cellToolbar.Controls.Add(linkDetalhes);

            cellProblema.Text = "<p style='font-size:110%;font-weight:bold;' >" + problema.TituloProblema + "</p>" + problema.DescricaoProblema;
            cellProblema.CssClass = "text-left";
            cellToolbar.CssClass = "text-center";

            row.Controls.Add(cellInicio);
            row.Controls.Add(cellProblema);
            row.Controls.Add(cellToolbar);

            table.Controls.Add(row);
        }
        panelProblemas.Controls.Add(table);
    }

}
