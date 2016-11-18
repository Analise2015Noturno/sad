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
                if (user.Cadastrar()) dvCadastroSucesso.Visible = true;
                else { dvCadastroAtencao.Visible = true; dvCadastroAtencao.InnerText += user.message; }

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

   
    protected void txtCpf_TextChanged(object sender, EventArgs e)
    {
        if ( sadLib.ValidaCpf(txtCpf.Text))
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