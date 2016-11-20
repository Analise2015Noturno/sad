using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_ajax_apagarSolucao : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        int codigoSolucao;
        int codigoProblema;
        try
        {
            codigoSolucao = int.Parse(Request["s"]);
            codigoProblema = int.Parse(Request["p"]);
            Solucao solucao = new Solucao();
            solucao.Id = codigoSolucao;
            solucao.IdProblema = codigoProblema;
            if (!solucao.apagar())
            {
                Response.Write(solucao.message);
                Response.StatusCode = 500;
            }
        }
        catch (Exception ex)
        {
            Response.Write(ex.Message);
            Response.StatusCode = 500;
        }
    }
}