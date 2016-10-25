using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

public class Usuario
{
    public int IdUsuario { get; set; }

    public string Nome { get; set; }

    public string Cpf { get; set; }

    public string Cep { get; set; }

    public int nEndereco { get; set; }

    public string Endereco { get; set; }

    public string Bairro { get; set; }

    public string Cidade { get; set; }

    public string Uf { get; set; }

    public string Complemento { get; set; }

    public string Email { get; set; }

    public string Senha { get; set; }

    public int Tipo_Usuario { get; set; }

    int italo = 10;

    public bool ValidarLogin()
    {
        DataTable dt = new DataTable();

        // Acesso ao banco de dados

        try
        {
            string conexao = System.Configuration.ConfigurationManager.AppSettings["conexao"];
            SqlConnection conn = new SqlConnection(conexao);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from tbl_usuario where senha='"+ this.Senha +"' and (email = '"+ this.Email +"' or cpf = '"+ this.Cpf +"')";

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
        }
        catch
        {
            return false;
        }


        // Com o DataTable já carregado, vamos repassar as informações para nosso objeto "cliente"

        if (dt.Rows.Count > 0)
        {
            this.IdUsuario = (int)dt.Rows[0]["id_usuario"];
            this.Nome = dt.Rows[0]["nome_usuario"].ToString();
            this.Cpf = dt.Rows[0]["cpf"].ToString();
            this.nEndereco = int.Parse(dt.Rows[0]["n_endereco"].ToString());
            this.Email = dt.Rows[0]["email"].ToString();
            this.Senha = dt.Rows[0]["senha"].ToString();
            this.Tipo_Usuario = int.Parse(dt.Rows[0]["id_tipo_usuario"].ToString());

            return true;
        }
        else
        {
            return false;
        }
    }


    public bool ValidarCadastrar()
    {
        DataTable dt = new DataTable();

        try
        {
            string conexao = System.Configuration.ConfigurationManager.AppSettings["conexao"];
            SqlConnection conn = new SqlConnection(conexao);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select * from tbl_usuario where cpf = '"+ this.Cpf +"' or email ='"+ this.Email +"'";

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
        }
        catch
        {
            return false;
        }

        if (dt.Rows.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
    public bool Cadastrar()
    {
        try
        {
            string conexao = System.Configuration.ConfigurationManager.AppSettings["conexao"];
            SqlConnection conn = new SqlConnection(conexao);
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into tbl_usuario values ('"+ this.Nome +"','"+ this.Cpf +"','"+ this.Cep +"','"+this.Endereco+"',"+ this.nEndereco +",'"+ this.Bairro +"','"+ this.Cidade +"', '"+ this.Uf +"', '"+ this.Email +"', '"+ this.Senha +"', 2)";
            cmd.ExecuteNonQuery();

            return true;
        }
        catch
        {
            return false;
        }
    }
}