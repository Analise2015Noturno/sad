using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Solucao
/// </summary>
public class Solucao
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public string Link { get; set; }
    public string Descricao { get; set; }
    public string message { get; set; }
    public int IdProblema { get; set; }

    public static List<Solucao> carregarSolucoes(int codigoProblema)
    {
        List<Solucao> solucoes = new List<Solucao>();
        try
        {
            string conexao = System.Configuration.ConfigurationManager.AppSettings["conexao"];
            SqlConnection conn = new SqlConnection(conexao);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select s.id_solucao , s.nome, s.link_acesso, s.descricao_solucao from tbl_problema_solucao ps inner join tbl_solucao s on s.id_solucao = ps.id_solucao where ps.id_problema = " + codigoProblema + " order by s.id_solucao ";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Solucao solucao = new Solucao();
                solucao.Id = reader.GetInt32(0);
                solucao.Nome = reader.GetString(1);
                solucao.Link = reader.GetString(2);
                solucao.Descricao = reader.GetString(3);
                solucoes.Add(solucao);
            }
            reader.Close();
            cmd.Dispose();
            conn.Close();
        }
        catch
        {
        }
        return solucoes;
    }

    public bool Inserir()
    {

        string conexao = System.Configuration.ConfigurationManager.AppSettings["conexao"];
        SqlConnection conn = new SqlConnection(conexao);
        try
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            //insere solucao
            cmd.CommandText = "insert into tbl_solucao ( nome, link_acesso, descricao_solucao ) values ( @nome , @link , @descricao ) ";
            cmd.Parameters.Add(new SqlParameter("@nome", this.Nome));
            cmd.Parameters.Add(new SqlParameter("@link", this.Link));
            cmd.Parameters.Add(new SqlParameter("@descricao", this.Descricao));
            cmd.ExecuteNonQuery();

            //insere solucao_problema
            cmd.Parameters.Clear();
            cmd.CommandText = " insert into tbl_problema_solucao ( id_problema, id_solucao ) select @problema, max(id_solucao) from tbl_solucao  ";
            cmd.Parameters.Add(new SqlParameter("@problema", this.IdProblema));
            cmd.ExecuteNonQuery();

            conn.Close();
            return true;

        }
        catch (Exception ex)
        {
            this.message = ex.Message;
            return false;
        }
        finally
        {
            if (conn.State.Equals(System.Data.ConnectionState.Open)) conn.Close();
        }
    }
}
