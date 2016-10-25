using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;

public partial class Cadastrar : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        dvCadastroSucesso.Visible = false;
        dvCadastroAtencao.Visible = false;
        dvCadastroSenha.Visible = false;
    }

    protected void Cancelar_Click(object sender, EventArgs e)
    {
        Response.Redirect("~/");
    }

    protected void Cadastrar_Click(object sender, EventArgs e)
    {
        if (txtSenha.Text == txtConfirsenha.Text)
        {
            Usuario user = new Usuario();
            user.Email = txtEmail.Text;
            user.Senha = txtSenha.Text;
            user.Cpf = txtCpf.Text;
            if (!user.ValidarCadastrar())
            {
                user.Nome = txtNome.Text;
                user.Cep = txtCep.Text;
                user.Endereco = txtEndereco.Text;
                user.nEndereco = int.Parse(txtNumero.Text);
                user.Bairro = txtBairro.Text;
                user.Cidade = txtCidade.Text;
                user.Uf = txtUf.Text;
                user.Cadastrar();
                dvCadastroSucesso.Visible = true;

            }
            else
            {
                dvCadastroAtencao.Visible = true;
            }
        }
        else
        {
            dvCadastroSenha.Visible = true;
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
        if (ValidarCaractCEP(txtCep.Text))
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