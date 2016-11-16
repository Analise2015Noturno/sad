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
    public int id_questao { get; set; }
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
            cmd.CommandText = "select b.questao, b.resposta from tbl_questionario a inner join tbl_questao b on b.id_questao = a.id_questao where a.id_problema = " + codigoProblema;
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                Questao questao = new global::Questao();
                questao.questao = reader.GetString(0);
                questao.resposta = reader.GetInt32(1);
                questoes.Add(questao);
            }
            reader.Close();
            conn.Close();

        } catch
        {

        }

        return questoes;

    }
    
     
}