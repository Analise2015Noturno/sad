using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Views_Config : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

        if (!Page.IsPostBack)
        {

            if (Session["UsuarioOnline"] == null)
            {
                Response.Redirect("~/Views/Login.aspx");
            }
            else
            {
                Usuario user = (Usuario)Session["UsuarioOnline"];
                txtNome.Text = user.Nome;
                txtCpf.Text = user.Cpf;
                txtEmail.Text = user.Email;
                txtCep.Text = user.Cep;
                txtNumero.Text = user.nEndereco.ToString();
                carregaCep(user.Cep);
            }

        }

        dvCadastroSucesso.Visible = false;
        dvCadastroAtencao.Visible = false;
        dvCadastroSenha.Visible = false;
        dvSenhaIncorreta.Visible = false;


    }

    protected void Cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/");
    }

    protected void Cadastrar_Click(object sender, EventArgs e)
    {
        Usuario user = (Usuario)Session["UsuarioOnline"];
        Boolean bPodeGravar = true;

        //primeiro de tudo verifica se a senha do cara está correta, a senha atual.
        //vai que ele esqueceu a tela aberta em algum lugar, daí alguém quer alterar o nome 
        //dele para viadinho só de sacanagem
        if (!txtSenhaAtual.Text.Equals(user.Senha))
        {
            bPodeGravar = false;
            dvSenhaIncorreta.Visible = true;
        }

        //verifica se o usuario quer alterar a senha
        if (bPodeGravar && (!txtSenhaNova.Text.Equals("") || !txtConfirmaSenhaNova.Text.Equals("")))
        {
            //se ele quer alterar senha mas as senhas nova e confirmanova são diferentes não dá.
            if (!txtSenhaNova.Text.Equals(txtConfirmaSenhaNova.Text))
            {
                bPodeGravar = false;
                dvCadastroSenha.Visible = true;
            }
            else
            {
                user.Senha = txtSenhaNova.Text;
            }
        }

        if (bPodeGravar)
        {

            user.Email = txtEmail.Text;
            user.Cpf = txtCpf.Text;
            user.Nome = txtNome.Text;
            user.Cep = txtCep.Text;
            user.Endereco = txtEndereco.Text;
            user.nEndereco = int.Parse(txtNumero.Text);
            user.Bairro = txtBairro.Text;
            user.Cidade = txtCidade.Text;
            user.Uf = txtUf.Text;
            if (user.Atualizar())
            {
                Session["UsuarioOnline"] = (Usuario)user;
                dvCadastroSucesso.Visible = true;
            }

        }


    }
    protected bool ValidarCaractCEP(string cep)
    {
        if (cep.Length == 8)
        {
            return true;
        }
        return false;
    }

    protected void txtCep_TextChanged(object sender, EventArgs e)
    {
        carregaCep(txtCep.Text);
    }

    protected void carregaCep(String cep)
    {
        if (ValidarCaractCEP(cep))
        {
            DataSet ds = new DataSet();

            ds.ReadXml("https://viacep.com.br/ws/" + txtCep.Text + "/xml/");
            if (ds != null && ds.Tables[0].Columns.Count > 5)
            {
                txtEndereco.Text = ds.Tables[0].Rows[0]["logradouro"].ToString().Trim();
                txtBairro.Text = ds.Tables[0].Rows[0]["bairro"].ToString().Trim();
                txtCidade.Text = ds.Tables[0].Rows[0]["localidade"].ToString().Trim();
                txtUf.Text = ds.Tables[0].Rows[0]["uf"].ToString().Trim();
            }
            else
            {
                txtEndereco.Text = "";
                txtBairro.Text = "";
                txtCidade.Text = "";
                txtUf.Text = "";
            }
        }
        else
        {
            txtCep.Text = "";
            txtEndereco.Text = "";
            txtBairro.Text = "";
            txtCidade.Text = "";
            txtUf.Text = "";
        }
    }

    public bool ValidaCpf(string cpf)
    {
        int[] multiplicador1 = new int[9] { 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        int[] multiplicador2 = new int[10] { 11, 10, 9, 8, 7, 6, 5, 4, 3, 2 };
        string tempCpf;
        string digito;
        int soma;
        int resto;

        cpf = cpf.Trim();
        cpf = cpf.Replace(".", "").Replace("-", "");

        if (cpf.Length != 11)
            return false;

        tempCpf = cpf.Substring(0, 9);
        soma = 0;
        for (int i = 0; i < 9; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador1[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = resto.ToString();

        tempCpf = tempCpf + digito;

        soma = 0;
        for (int i = 0; i < 10; i++)
            soma += int.Parse(tempCpf[i].ToString()) * multiplicador2[i];

        resto = soma % 11;
        if (resto < 2)
            resto = 0;
        else
            resto = 11 - resto;

        digito = digito + resto.ToString();

        return cpf.EndsWith(digito);
    }


    protected void txtCpf_TextChanged(object sender, EventArgs e)
    {
        if (ValidaCpf(txtCpf.Text))
        {
            txtCpf.BorderColor = System.Drawing.Color.Green;
        }
        else
        {
            txtCpf.Text = "";
            txtCpf.BorderColor = System.Drawing.Color.Red;
        }
    }
}