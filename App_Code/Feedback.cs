using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Feedback
/// </summary>
public class Feedback
{
    public int id_feedback { get; set; }
    public string detalhe_feedback { get; set; }
    public DateTime dt_feedback { get; set; }
    public int id_solucao { get; set; }
    public int id_usuario { get; set; }
    public string message { get; set; }
    public string nome_solucao { get; set; }
    public string nome_usuario { get; set; }

    public static List<Feedback> carregaFeedBacks(int codigo)
    {
        List<Feedback> feedbacks = new List<Feedback>();

        //busca questões do problema
        try
        {
            string conexao = System.Configuration.ConfigurationManager.AppSettings["conexao"];
            SqlConnection conn = new SqlConnection(conexao);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select f.id_feedback, f.detalhe_feedback, f.dt_feedback, s.nome, u.nome_usuario, f.id_solucao, f.id_usuario from tbl_feedback f inner join tbl_problema_solucao ps on f.id_solucao = ps.id_solucao inner join tbl_usuario u on u.id_usuario = f.id_usuario inner join tbl_solucao s on s.id_solucao = f.id_solucao where ps.id_problema = " + codigo + " order by f.dt_feedback desc " ;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Feedback feedback = new Feedback();
                feedback.id_feedback = reader.GetInt32(0);
                feedback.detalhe_feedback = reader.GetString(1);
                feedback.dt_feedback = reader.GetDateTime(2);
                feedback.nome_solucao = reader.GetString(3);
                feedback.nome_usuario = reader.GetString(4);
                feedback.id_solucao = reader.GetInt32(5);
                feedback.id_usuario = reader.GetInt32(6);
                feedbacks.Add(feedback);
            }
            reader.Close();
            conn.Close();

        }
        catch
        {

        }

        return feedbacks;
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
            cmd.CommandText = "insert into tbl_feedback ( detalhe_feedback , id_usuario, id_solucao , dt_feedback ) values ( @detalhe , @usuario , @solucao , getDate() ) ";
            cmd.Parameters.Add(new SqlParameter("@detalhe", this.detalhe_feedback));
            cmd.Parameters.Add(new SqlParameter("@usuario", this.id_usuario));
            cmd.Parameters.Add(new SqlParameter("@solucao", this.id_solucao));
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