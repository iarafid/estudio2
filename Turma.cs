using Estudio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace estudio
{
    class Turma
    {
        private double hora;
        private string professor, dia_semana, modalidade;
        private double id, idEstudio_Turma;
        private int qtdeMax = 0;
        public string Professor { get => professor; set => professor = value; }
        public string Dia_semana { get => dia_semana; set => dia_semana = value; }
        public double Hora { get => hora; set => hora = value; }
        public string Modalidade { get => modalidade; set => modalidade = value; }
        public double Id { get => id; set => id = value; }
        

        public void setQtdeMax(int qtdeMax)
        {
            this.qtdeMax = qtdeMax;
        }

        public int QtdeMax
        {
            get
            {
                return qtdeMax;
            }

        }


        public Turma(string modalidade, string professor, string dia_semana, double hora)
        {
            this.modalidade = modalidade;
            this.professor = professor;
            this.dia_semana = dia_semana;
            this.hora = hora;
        }

        public Turma(string modalidade)
        {
            this.modalidade = modalidade;
        }

        public Turma(double id)
        {
            this.id = id;
        }

        public Turma(string modalidade, string dia_semana)
        {
            this.modalidade = modalidade;
            this.dia_semana = dia_semana;
        }

        public Turma(double id, string dia_semana, double hora)
        {
            this.id = id;
            this.dia_semana = dia_semana;
            this.hora = hora;
        }

        public Turma(string modalidade, int qtdeMax)
        {
            this.modalidade = modalidade;
            this.qtdeMax = qtdeMax;
        }

        public Turma()
        {

        }

        public bool cadastrarTurma(string professor, string dia_semana, double hora, string modalidade)
        {
            bool cad = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand insere = new MySqlCommand("insert into Estudio_Turma(professorTurma, diaSemana, horaTurma, idModalidade) values ('" + professor + "','" + dia_semana + "','" + hora + "','" + modalidade + "')", DAO_Conexao.con);
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

        public bool excluirTurma(string modalidade)
        {
            bool exc = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand exclui = new MySqlCommand("update Estudio_Turma set ativo=1 where idModalidade = '" + modalidade + "'", DAO_Conexao.con);
                exclui.ExecuteNonQuery();
                exc = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                estudio.DAO_Conexao.con.Close();
            }
            return exc;

        }

        public bool consultarTurma(string modalidade)
        {
            bool existe = false;

            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand consultaBool = new MySqlCommand("SELECT * FROM Estudio_Turma WHERE ativo=0 and idModalidade = '" + modalidade + "'", DAO_Conexao.con);
                MySqlDataReader resultado = consultaBool.ExecuteReader();
                if (resultado.Read())
                {
                    existe = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }

            finally
            {
                DAO_Conexao.con.Close();
            }

            return existe;

        }

        public bool atualizaTurma()
        {
            bool updated = false;
            try
            {
                DAO_Conexao.con.Open();
                MySqlCommand update = new MySqlCommand("update Estudio_Turma set horaTurma='" + hora + "', diaSemana='" + dia_semana + "', idModalidade='" + modalidade + "', professorTurma='" + professor + "' where ativo='0' and idModalidade='" + modalidade + "'", DAO_Conexao.con);
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

        public MySqlDataReader ConsultarTodasTurmas()
        {
            MySqlCommand consultaTodos = null;
            MySqlDataReader resultadoTodos = null;

            try
            {
                DAO_Conexao.con.Open();
                consultaTodos = new MySqlCommand("SELECT * FROM Estudio_Turma where ativo='0' and idEstudio_Turma = '" + idEstudio_Turma + "'idModalidade='" + id + "'diadasemanaTurma='" + dia_semana + "'horaTurma='" + hora + "'", DAO_Conexao.con);
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



        public void QtdeMaxx(int modalidade, int qtdeMax)
        {
            try
            {
                Modalidade m = new Modalidade();
                qtdeMax = m.QtdeAlunosViaID(modalidade);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        public MySqlDataReader consultarTurmaIdDiaHora(int id, string dia_semana, string hora)
        {
            MySqlCommand consulta = null;
            MySqlDataReader resultado = null;

            try
            {
                DAO_Conexao.con.Open();
                consulta = new MySqlCommand("SELECT * FROM Estudio_Turma WHERE idModalidade='" + id + "' AND diaSemana='" + dia_semana + "' AND horaTurma='" + hora + "'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            finally
            {
            }
            return resultado;
        }

        public MySqlDataReader consultarTurmaId(string id)
        {
            MySqlCommand consulta = null;
            MySqlDataReader resultado = null;

            try
            {
                DAO_Conexao.con.Open();
                consulta = new MySqlCommand("SELECT * FROM Estudio_Turma WHERE idModalidade='" + id + "'", DAO_Conexao.con);
                resultado = consulta.ExecuteReader();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            finally
            {
            }
            return resultado;
        }
    }


}
