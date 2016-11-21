using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

public partial class Views_CadastrarSolucoes : System.Web.UI.Page
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

        if (selProblema.SelectedIndex > -1) carregarSolucoes(int.Parse(selProblema.SelectedValue));

    }

    protected void btnGravarSolucao_Click(object sender, EventArgs e)
    {
        bool podeGravar = true;

        if (txtTitulo.Value.Equals(""))
        {
            formTitulo.Attributes["class"] = "form-group has-error";
            helpBlockTitulo.InnerText = "Título é preenchimento obrigatório";
            podeGravar = false;
        }
        if (txtDescricao.Value.Equals(""))
        {
            formDescricao.Attributes["class"] = "form-group has-error";
            helpBlockDescricao.InnerText = "Descrição é preenchimento obrigatório";
            podeGravar = false;
        }

        if (podeGravar)
        {
            Solucao solucao = new Solucao();
            solucao.Nome = txtTitulo.Value;
            solucao.Descricao = txtDescricao.Value;
            solucao.Link = txtUrl.Value;
            solucao.IdProblema = int.Parse(selProblema.SelectedValue);

            //decide se vai criar nova solucao ou aletar antiga
            bool processaImagem = false;
            if (txtCodigoSolucao.Value.Equals(""))
            {
                if (solucao.Inserir())
                {
                    alerta.Attributes["class"] = "alert alert-success bottom20";
                    alerta.InnerText = "Solução Cadastrada com Sucesso.";
                    txtTitulo.Value = ""; txtDescricao.Value = "";
                    txtUrl.Value = "";
                    txtCodigoSolucao.Value = "";
                    carregarSolucoes(solucao.IdProblema);
                    processaImagem = true;
                }
                else
                {
                    alerta.Attributes["class"] = "alert alert-danger bottom20";
                    alerta.InnerText = solucao.message;
                }

            }
            else
            {
                solucao.Id = int.Parse(txtCodigoSolucao.Value);
                if (solucao.Alterar())
                {
                    alerta.Attributes["class"] = "alert alert-success bottom20";
                    alerta.InnerText = "Solução Alterada com Sucesso.";
                    txtTitulo.Value = "";
                    txtDescricao.Value = "";
                    txtUrl.Value = "";
                    txtCodigoSolucao.Value = "";
                    carregarSolucoes(solucao.IdProblema);
                    formTitulo.Attributes["class"] = "form-group";
                    formDescricao.Attributes["class"] = "form-group";
                    processaImagem = true;
                }
                else
                {
                    alerta.Attributes["class"] = "alert alert-danger bottom20";
                    alerta.InnerText = solucao.message;
                }
            }

            //se deu tudo certo, então verifica se tem imagem
            if (processaImagem)
                if (imagemSolucao.HasFile)
                {
                    try
                    {
                        string caminho = Server.MapPath("~/img/problemas/" + solucao.IdProblema + "/" + solucao.Id + "/");

                        //se ainda não existe o diretório, cria
                        if (!System.IO.Directory.Exists(caminho))
                        {
                            System.IO.Directory.CreateDirectory(caminho);
                        }

                        //se tem algo no diretório, apaga
                        foreach (string arquivo in System.IO.Directory.GetFiles(caminho))
                        {
                            System.IO.File.Delete(arquivo);
                        }

                        //finalmente, grava o arquivo
                        imagemSolucao.SaveAs(caminho + imagemSolucao.FileName);

                        //já que mecheu com imagens, carrega soluções outra vez
                        if (selProblema.SelectedIndex > -1) carregarSolucoes(int.Parse(selProblema.SelectedValue));
                    }
                    catch( Exception ex)
                    {
                        alerta.Attributes["class"] = "alert alert-danger bottom20";
                        alerta.InnerText = ex.Message;
                    }

                }

        }

    }

    protected void selProblema_SelectedIndexChanged(object sender, EventArgs e)
    {
        txtCodigoSolucao.Value = "";
        txtTitulo.Value = "";
        txtDescricao.Value = "";
        txtUrl.Value = "";
        alerta.Attributes["class"] = "invisible";
        carregarSolucoes(int.Parse(selProblema.SelectedValue));
    }

    private void carregarSolucoes(int codigoProblema)
    {
        sectionSolucoes.Controls.Clear();
        List<Solucao> solucoes = Solucao.carregarSolucoes(codigoProblema);
        Panel row = new Panel();
        row.CssClass = "row";
        int iRowController = 0;
        foreach (Solucao solucao in solucoes)
        {

            Panel panel = new Panel();
            Panel coluna = new Panel();
            Image image = new Image();
            HtmlGenericControl header = new HtmlGenericControl("h3");
            HtmlGenericControl texto = new HtmlGenericControl("p");
            HyperLink link = new HyperLink();

            //para texto da solucao
            header.InnerText = solucao.Nome;
            header.ID = "header" + solucao.Id;
            texto.InnerText = solucao.Descricao;
            texto.ID = "texto" + solucao.Id;
            link.NavigateUrl = solucao.Link;
            link.Text = solucao.Link;
            link.ID = "link" + solucao.Id;

            //verifica se tem imagem e adiciona
            string caminho = Server.MapPath("~/img/problemas/" + solucao.IdProblema + "/" + solucao.Id );
            if (System.IO.Directory.Exists(caminho))
                foreach (string arquivoImagem in System.IO.Directory.GetFiles(caminho))
                {
                    var urlPath = new Uri(@arquivoImagem);
                    var urlRoot = new Uri(Server.MapPath("~") + "/");
                    string relative = urlRoot.MakeRelativeUri(urlPath).ToString();
                    image.ImageUrl = ResolveUrl(relative);
                }


            //prepara toolbar
            HtmlGenericControl toolbar = new HtmlGenericControl("div");
            HyperLink linkApagar = new HyperLink();
            HyperLink linkEditar = new HyperLink();
            HtmlGenericControl editar = new HtmlGenericControl("span");
            HtmlGenericControl apagar = new HtmlGenericControl("span");
            linkApagar.NavigateUrl = "javascript:apagarSolucao(" + solucao.Id + " , " + solucao.IdProblema + ");";
            linkEditar.NavigateUrl = "javascript:editarSolucao(" + solucao.Id + ");";
            editar.Attributes["class"] = "glyphicon glyphicon-pencil ";
            apagar.Attributes["class"] = "glyphicon glyphicon-trash";
            toolbar.Attributes["class"] = "toolbar";
            linkApagar.Controls.Add(apagar);
            linkEditar.Controls.Add(editar);
            toolbar.Controls.Add(linkEditar);
            toolbar.Controls.Add(linkApagar);

            //prepara formatação das colunas
            panel.CssClass = "col-md-4 text-center bottom20";
            coluna.CssClass = "caixaFancy";
            texto.Attributes["class"] = "lead";
            image.CssClass = "img-responsive center-block imagemSolucao";

            //adiciona todos os controles na ordem certa
            coluna.Controls.Add(toolbar);
            if(!image.ImageUrl.Equals("")) coluna.Controls.Add(image);
            coluna.Controls.Add(header);
            coluna.Controls.Add(texto);
            coluna.Controls.Add(link);
            panel.Controls.Add(coluna);
            row.Controls.Add(panel);

            //controlador de linhas
            iRowController++;
            if (iRowController > 0 && (iRowController % 3) == 0)
            {
                sectionSolucoes.Controls.Add(row);
                row = new Panel();
                row.CssClass = "row";
            }
        }
        sectionSolucoes.Controls.Add(row);


    }
}