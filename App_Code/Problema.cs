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

    public Problema()
    {
        //
        // TODO: Add constructor logic here
        //
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
            cmd.CommandText = "PesquisarProblema "+this.TituloProblema;

            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            sda.Fill(dt);
        }
        catch
        {

        }

        return dt;
    }
}