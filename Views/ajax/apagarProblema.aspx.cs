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
        try
        {
            codigoProblema = int.Parse(Request["p"]);
            Problema problema = new Problema();
            problema.IdProblema = codigoProblema;
            if (!problema.Apagar())
            {
                Response.Write(problema.message);
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