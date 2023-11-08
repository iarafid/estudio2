using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using estudio;
using Estudio;


namespace Estudio
{
    class Modalidade
    {
        private string descricao;
        private double preco;
        private int del;
        private int qtdeAluno, qtdeAula, idModalidade;

        public Modalidade(int qtdeAluno, int idModalidade)
        {
            this.qtdeAluno = qtdeAluno;
            this.idModalidade = idModalidade;
        }

        public Modalidade(string descricao)
        {
            this.descricao = descricao;

        }

      
        public Modalidade()
        {

        }



        public Modalidade(string descricao, double preco, int qtdeAluno, int qtdeAula)
        {
            this.descricao = descricao;
            this.preco = preco;
            this.qtdeAluno = qtdeAluno;
            this.qtdeAula = qtdeAula;
        }

        public string Descricao { get => descricao; set => descricao = value; }
        public int IdModalidade { get => idModalidade; set => idModalidade = value; }
        public double Preco { get => preco; set => preco = value; }

        public bool cadastrarModalidade()
        {
            bool cad = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_Modalidade(descricaoModalidade, precoModalidade, qtdeAlunos, qtdeAulas) values ('" + descricao + "'," + preco + "," + qtdeAluno + "," + qtdeAula + ")", DAO_Conexao.con);
                insere.ExecuteNonQuery();
                cad = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return cad;
        }

        public MySqlDataReader consultarModalidade(String descEscolhida)
        {
            MySqlCommand consulta = null;
            MySqlDataReader resultado = null;

            try
            {
                DAO_Conexao.con.Open();
                consulta = new MySqlCommand("SELECT * FROM Estudio_Modalidade WHERE descricaoModalidade='" + descEscolhida + "'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }

            finally
            {


            }
            return resultado;
        }
        public bool consultarBoolean()
        {
            bool existe = false;

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consultaBool = new MySqlCommand("SELECT * FROM Estudio_Modalidade WHERE descricaoModalidade = '" + descricao + "'", DAO_Conexao.con);
                MySqlDataReader resultado = consultaBool.ExecuteReader();
                if (resultado.Read())
                {
                    existe = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            finally
            {
                DAO_Conexao.con.Close();
            }

            return existe;
        }
        public MySqlDataReader ConsultarTodasModalidades()
        {
            MySqlCommand consultaTodos = null;
            MySqlDataReader resultadoTodos = null;

            try
            {
                DAO_Conexao.con.Open();
                consultaTodos = new MySqlCommand("SELECT * FROM Estudio_Modalidade where ativo='0'", DAO_Conexao.con);
                resultadoTodos = consultaTodos.ExecuteReader();


            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
                Console.WriteLine(ex.ToString());
            }

            finally
            {


            }
            return resultadoTodos;
        }

        public bool atualizaModalidade()
        {
            bool updated = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand update = new MySqlCommand("update Estudio_Modalidade set descricaoModalidade='" + descricao + "', precoModalidade=" + preco + ", qtdeAlunos=" + qtdeAluno + ", qtdeAulas=" + qtdeAula + " where descricaoModalidade='" + descricao + "'", DAO_Conexao.con);
                update.ExecuteNonQuery();
                updated = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                Console.WriteLine(ex.ToString());
            }
            finally
            {
                DAO_Conexao.con.Close();
            }
            return updated;
        }

        public bool excluirModalidade()
        {
            bool exc = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand exclui = new MySqlCommand("update Estudio_Modalidade set ativo=1 where descricaoModalidade = '" + Descricao + "'", DAO_Conexao.con);
                exclui.ExecuteNonQuery();
                exc = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                estudio.DAO_Conexao.con.Close();
            }
            return exc;
        }



        public int QtdeAlunosViaID(int idModalidade)
        {
            int quantidade = 0;
            MySqlCommand consulta = null;
            MySqlDataReader resultado = null;

            try
            {
                DAO_Conexao.con.Open();
                consulta = new MySqlCommand("SELECT qtdeAlunos FROM Estudio_Modalidade WHERE idEstudio_Modalidade='" + idModalidade + "'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
                while (resultado.Read())
                {
                    quantidade = int.Parse(resultado["qtdeAluno"].ToString());
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
            return quantidade;
        }
    }
}