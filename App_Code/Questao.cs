using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Questao
/// </summary>
public class Questao
{
    public int IdProblema { get; set; }
    public int id_questao { get; set; }
    public string message { get; set; }
    public string questao { get; set; }
    public int resposta { get; set; }

    public static List<Questao> carregaQuestoes(int codigoProblema)
    {
        List<Questao> questoes = new List<Questao>();

        //busca questões do problema
        try
        {
            string conexao = System.Configuration.ConfigurationManager.AppSettings["conexao"];
            SqlConnection conn = new SqlConnection(conexao);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select b.questao, b.resposta, b.id_questao, a.id_problema from tbl_questionario a inner join tbl_questao b on b.id_questao = a.id_questão where a.id_problema = " + codigoProblema;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Questao questao = new global::Questao();
                questao.questao = reader.GetString(0);
                questao.resposta = reader.GetInt32(1);
                questao.id_questao = reader.GetInt32(2);
                questao.IdProblema = reader.GetInt32(3);
                questoes.Add(questao);
            }
            reader.Close();
            conn.Close();

        }
        catch
        {

        }

        return questoes;

    }

    public bool apagar()
    {
        string conexao = System.Configuration.ConfigurationManager.AppSettings["conexao"];
        SqlConnection conn = new SqlConnection(conexao);
        try
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            //apaga da tabela problema_ questao
            cmd.CommandText = "delete from tbl_questionario where id_questão = " + this.id_questao + " and id_problema = " + this.IdProblema;
            cmd.ExecuteNonQuery();

            //apaga da tabela questao
            cmd.CommandText = "delete from tbl_questao where id_questao = " + this.id_questao;
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

    public bool Inserir()
    {

        string conexao = System.Configuration.ConfigurationManager.AppSettings["conexao"];
        SqlConnection conn = new SqlConnection(conexao);
        try
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            //insere questao
            cmd.CommandText = "insert into tbl_questao ( questao , resposta ) values ( @questao , @resposta ) ";
            cmd.Parameters.Add(new SqlParameter("@questao", this.questao));
            cmd.Parameters.Add(new SqlParameter("@resposta", this.resposta));
            cmd.ExecuteNonQuery();

            //insere questionario
            cmd.Parameters.Clear();
            cmd.CommandText = " insert into tbl_questionario ( id_problema, id_questão ) select @problema, max(id_questao) from tbl_questao  ";
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

    public bool Alterar()
    {
        string conexao = System.Configuration.ConfigurationManager.AppSettings["conexao"];
        SqlConnection conn = new SqlConnection(conexao);
        try
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            //insere questao
            cmd.CommandText = "update tbl_questao set questao = @questao , resposta = @resposta where id_questao = " + this.id_questao;            
            cmd.Parameters.Add(new SqlParameter("@questao", this.questao));
            cmd.Parameters.Add(new SqlParameter("@resposta", this.resposta));
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