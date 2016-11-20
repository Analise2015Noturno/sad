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
        int codigoQuestao;
        int codigoProblema;
        try
        {
            codigoQuestao = int.Parse(Request["q"]);
            codigoProblema = int.Parse(Request["p"]);
            Questao questao = new Questao();
            questao.id_questao = codigoQuestao;
            questao.IdProblema = codigoProblema;
            if (!questao.apagar())
            {
                Response.Write(questao.message);
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