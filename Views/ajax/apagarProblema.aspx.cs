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
        int codigoProblema;
        Problema problema = new Problema();
        try
        {
            codigoProblema = int.Parse(Request["p"]);
            problema.IdProblema = codigoProblema;
            if (problema.Apagar()) problema.message = "DEL-PROB-OK";
        }
        catch (Exception ex)
        {
            problema.message = ex.Message;
        }
        Response.Write(problema.message);
    }
}