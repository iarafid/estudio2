using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace estudio
{

    class Matricula
    {

    }

    public bool cadastrarMatricula(int idTurma, string cpf)
    {  
        bool cad = false;
        try
        {
            DAO_Conexao.con.Open();

            MySqlCommand insere = new MySqlCommand("insert into Estudio_Matricula(id_Turma,cpf_Aluno) values (" + idTurma + ",'" + cpf + "')", DAO_Conexao.con);
            insere.ExecuteNonQuery();
            cad = true;
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }
        finally
        {
            DAO_Conexao.con.Close();
        }
        return cad;
    }

    public MySqlDataReader consultarAlunosMatricula(int idTurma)
    {
        MySqlCommand consultaTodos = null;
        MySqlDataReader resultadoTodos = null;

        try
        {
            DAO_Conexao.con.Open();
            consultaTodos = new MySqlCommand("SELECT * FROM Estudio_Matricula where id_Turma='" + idTurma + "'", DAO_Conexao.con);
            resultadoTodos = consultaTodos.ExecuteReader();

            DAO_Conexao.con.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        finally
        {
        }
        return resultadoTodos;
    }
    public MySqlDataReader consultarMatriculaInnerJoin(int idTurma)
    {
        MySqlCommand consultaTodos = null;
        MySqlDataReader resultadoTodos = null;

        try
        {
            DAO_Conexao.con.Open();
            consultaTodos = new MySqlCommand("select * from Estudio_Aluno inner join Estudio_Matricula on Estudio_Aluno.CPFAluno = Estudio_Matricula.cpf_Aluno where Estudio_Matricula.id_Turma='" + idTurma + "'", DAO_Conexao.con);
            resultadoTodos = consultaTodos.ExecuteReader();


        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        finally
        {
        }
        return resultadoTodos;
    }

    

    public int contarAlunosMatricula(int idTurma)

    {
        MySqlCommand consultaTodos = null;
        MySqlDataReader resultadoTodos = null;
        int qtd = 0;

        try
        {
            DAO_Conexao.con.Open();
            consultaTodos = new MySqlCommand("select count(cpf_Aluno) from Estudio_Matricula where id_Turma='" + idTurma + "'", DAO_Conexao.con);
            resultadoTodos = consultaTodos.ExecuteReader();
            while (resultadoTodos.Read())
            {
                qtd = int.Parse(resultadoTodos["count(cpf_Aluno)"].ToString());
            }
            DAO_Conexao.con.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.ToString());
        }

        finally
        {
        }
        return qtd;
    }
    public bool excluirAlunoMatricula(string cpf)
    {
        bool exc = false;
        try
        {
            DAO_Conexao.con.Open();
            MySqlCommand exclui = new MySqlCommand("delete from Estudio_Matricula where cpf_Aluno='" + cpf + "'", DAO_Conexao.con);
            exclui.ExecuteNonQuery();
            exc = true;
        }
        catch (Exception ex)
        {
            System.Windows.Forms.MessageBox.Show(ex.ToString());
        }
        finally
        {
            DAO_Conexao.con.Close();
        }
        return exc;
    }

}



