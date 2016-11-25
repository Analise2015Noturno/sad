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
        Solucao solucao = new Solucao();
        try
        {
            codigoSolucao = int.Parse(Request["s"]);
            codigoProblema = int.Parse(Request["p"]);
            solucao.Id = codigoSolucao;
            solucao.IdProblema = codigoProblema;
            if (solucao.apagar())
            {
                solucao.message = "DEL-SOL-OK";
                //agora que apagou a solucao, tem que apagar os arquivos também
                string caminho = Server.MapPath("~/img/problemas/" + solucao.IdProblema + "/" + solucao.Id);
                if (System.IO.Directory.Exists(caminho))
                    foreach (string arquivoImagem in System.IO.Directory.GetFiles(caminho))
                        System.IO.File.Delete(arquivoImagem);
            }
        }
        catch (Exception ex)
        {
            solucao.message = ex.Message;
        }
        Response.Write(solucao.message);
    }
}