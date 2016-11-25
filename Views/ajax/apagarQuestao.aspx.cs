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
        Questao questao = new Questao();
        try
        {
            codigoQuestao = int.Parse(Request["q"]);
            codigoProblema = int.Parse(Request["p"]);
            questao.id_questao = codigoQuestao;
            questao.IdProblema = codigoProblema;
            if (questao.apagar()) questao.message = "DEL-QUS-OK";
        }
        catch (Exception ex)
        {
            questao.message = ex.Message;
        }
        Response.Write(questao.message);
    }
}