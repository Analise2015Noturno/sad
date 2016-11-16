using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Problema
{
    public int IdProblema { get; set; }

    public string TituloProblema { get; set; }

    public string DescricaoProblema { get; set; }

    public DateTime DataCriacao { get; set; }

    public DateTime DataHoraAtualizacao { get; set; }

    public int UsuarioSolucao { get; set; }

    public string message { get; set; }


    public Problema()
    {
        //
        // TODO: Add constructor logic here
        //
    }

    public bool Carregar(int codigo)
    {
        bool retorno = false;
        try
        {
            string conexao = System.Configuration.ConfigurationManager.AppSettings["conexao"];
            SqlConnection conn = new SqlConnection(conexao);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select titulo_problema , descricao_problema , dt_criacao , dt_hr_atualizacao , usuario_solucao from tbl_problema where id_problema = " + codigo;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                this.IdProblema = codigo;
                this.TituloProblema = reader.GetString(0);
                this.DescricaoProblema = reader.GetString(1);
                this.DataCriacao = reader.GetDateTime(2);
                this.DataHoraAtualizacao = reader.GetDateTime(3);
                this.UsuarioSolucao = reader.GetInt32(4);
                retorno = true;
            }
            else
                this.message = "Problema não encontrado.";

            reader.Close();
            cmd.Dispose();
            conn.Close();
        }
        catch (Exception ex)
        {
            this.message = ex.Message;
        }
        return retorno;
    }

    public DataTable Localiza()
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
            cmd.CommandText = "PesquisarProblema " + this.TituloProblema;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
        }
        catch
        {

        }

        return dt;
    }
}