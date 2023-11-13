using Estudio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace estudio
{
    public partial class CadastrarMatricula : Form
    {

        private int index;
        private string nomeModalidade;
        private string nomeTurma;
        private String[] resultado;
        private string modalidadeSelected;
        private string horarioSelected;
        private int idModalidadeBusca;
        private string horaSelected;
        private int idTurma;

        public CadastrarMatricula()
        {
            InitializeComponent();
            try
            {
                Modalidade m = new Modalidade();
                MySqlDataReader r = m.ConsultarTodasModalidades();
                while (r.Read())
                {
                    comboBox1.Items.Add(r["descricaoModalidade"].ToString());
                }
                DAO_Conexao.con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var modalidade = comboBox1.Text;

            try
            {
                listBox1.Items.Clear();

                Turma t = new Turma();
                MySqlDataReader Lbx = t.consultarTurmaId(modalidade);
                while (Lbx.Read())
                {
                    nomeTurma = Lbx["idEstudio_Turma"].ToString();
                    listBox1.Items.Add(nomeTurma);
                }
                DAO_Conexao.con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }


        private int obterIdTurma()
            {
                try
                {
                    resultado = listBox1.SelectedItem.ToString().Split('-');
                    modalidadeSelected = resultado[0];
                    horarioSelected = resultado[1];
                    horaSelected = resultado[2];

                    Modalidade m = new Modalidade();
                    MySqlDataReader Mod = m.consultarModalidade(modalidadeSelected);
                    while (Mod.Read())
                    {
                        idModalidadeBusca = int.Parse(Mod["idEstudio_Modalidade"].ToString());
                    }
                    DAO_Conexao.con.Close();

                    Turma t = new Turma();
                    MySqlDataReader Dia = t.consultarTurmaIdDiaHora(idModalidadeBusca, horarioSelected, horaSelected);
                    while (Dia.Read())
                    {
                        idTurma = int.Parse(Dia["idEstudio_Turma"].ToString());
                    }
                    DAO_Conexao.con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
                return idTurma;
            }

        private void button1_Click(object sender, EventArgs e)
        {
            var idTurma = int.Parse(listBox1.Text);

            string cpf = maskedTextBox1.Text;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");
            Aluno alu = new Aluno(cpf);
            if (alu.consultarAluno() == true)
            {
                Matricula ma = new Matricula();
                Turma t = new Turma();
                t.setQtdeMax(10);
                if (ma.contarAlunosMatricula(idTurma) < t.QtdeMax)
                {
                    Aluno al = new Aluno(cpf);
                    if (al.consultarAluno() == true)
                    {
                        cpf = al.Cpf;

                        if (ma.cadastrarMatricula(idTurma, cpf))
                        {
                            MessageBox.Show("Cadastro realizado");
                        }
                        else
                        {
                            MessageBox.Show("Erro no cadastro");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Não é possível mais cadastrar alunos nesta turma");
                    }
                }
                else
                {
                    MessageBox.Show("Este CPF não existe no banco de dados");

                }

            }
        }


        private void CadastrarMatricula_Load(object sender, EventArgs e)
        {

        }
    }
    } 
