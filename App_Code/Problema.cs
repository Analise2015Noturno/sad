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

    public int id_usuario_problema { get; set; }

    public bool Apagar()
    {
        string conexao = System.Configuration.ConfigurationManager.AppSettings["conexao"];
        SqlConnection conn = new SqlConnection(conexao);
        try
        {
            conn.Open();

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;

            //apaga da tabela problema 
            cmd.CommandText = "delete from tbl_problema where id_problema = " + this.IdProblema;
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
            cmd.CommandText = "select titulo_problema , descricao_problema , dt_criacao , dt_hr_atualizacao , id_usuario_problema from tbl_problema where id_problema = " + codigo;
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                this.IdProblema = codigo;
                this.TituloProblema = reader.GetString(0);
                this.DescricaoProblema = reader.GetString(1);
                this.DataCriacao = reader.GetDateTime(2);
                if (!reader.IsDBNull(3))
                    this.DataHoraAtualizacao = reader.GetDateTime(3);
                this.id_usuario_problema = reader.GetInt32(4);
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

    public static List<Problema> carregarProblemas()
    {
        List<Problema> problemas = new List<Problema>();
        try
        {
            string conexao = System.Configuration.ConfigurationManager.AppSettings["conexao"];
            SqlConnection conn = new SqlConnection(conexao);
            conn.Open();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = conn;
            cmd.CommandText = "select titulo_problema , descricao_problema , dt_criacao , dt_hr_atualizacao , id_usuario_problema, id_problema from tbl_problema order by dt_criacao desc ";
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read() )
            {
                Problema problema = new Problema();
                problema.IdProblema = reader.GetInt32(5);
                problema.TituloProblema = reader.GetString(0);
                problema.DescricaoProblema = reader.GetString(1);
                problema.DataCriacao = reader.GetDateTime(2);
                if (!reader.IsDBNull(3))
                    problema.DataHoraAtualizacao = reader.GetDateTime(3);
                problema.id_usuario_problema = reader.GetInt32(4);
                problemas.Add(problema);
            }
            reader.Close();
            cmd.Dispose();
            conn.Close();
        }
        catch 
        {
        }
        return problemas;
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

            cmd.CommandText = "insert into tbl_problema ( titulo_problema , descricao_problema , dt_criacao , id_usuario_problema ) values ( @titulo , @descricao , getDate() , @usuario ) ";
            cmd.Parameters.Add(new SqlParameter("@titulo",this.TituloProblema));
            cmd.Parameters.Add(new SqlParameter("@descricao",this.DescricaoProblema));
            cmd.Parameters.Add(new SqlParameter("@usuario",this.id_usuario_problema));

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
            if(conn.State.Equals(System.Data.ConnectionState.Open)) conn.Close();
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

            cmd.CommandText = "update tbl_problema set titulo_problema  = @titulo , descricao_problema = @descricao ,  dt_hr_atualizacao = getDate() , id_usuario_problema = @usuario where id_problema = " + this.IdProblema ;
            cmd.Parameters.Add(new SqlParameter("@titulo", this.TituloProblema));
            cmd.Parameters.Add(new SqlParameter("@descricao", this.DescricaoProblema));
            cmd.Parameters.Add(new SqlParameter("@usuario", this.id_usuario_problema));

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