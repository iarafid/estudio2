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

        private void button1_Click(object sender, EventArgs e)
        {
            string cpf = maskedTextBox1.Text;
            cpf = cpf.Trim();
            cpf = cpf.Replace(".", "");
            cpf = cpf.Replace("-", "");
            Aluno alu = new Aluno(cpf);
            if (alu.consultarAluno() == true)
            {
                int id = obterIdTurma();
                Matricula ma = new Matricula();
                Turma t = new Turma();
                t.setQtdeMax(index);
                if (ma.contarAlunosMatricula(obterIdTurma()) < t.QtdeMax)
                {
                    Aluno al = new Aluno(cpf);
                    if (al.consultarAluno() == true)
                    {
                        int id = obterIdTurma();
                        Matricula m = new Matricula();
                        Turma tu = new Turma();
                        tu.setQtdeMax(index);
                        if (m.contarAlunosMatricula(obterIdTurma()) < tu.QtdeMax)
                        {
                            Aluno a = new Aluno(cpf);

                            if (a.verificaCPF())
                            {
                                cpf = a.getCPF();

                                if (m.cadastrar(id, cpf))
                                {
                                    MessageBox.Show("Cadastro realizado");
                                }
                                else
                                {
                                    MessageBox.Show("Erro no cadastro");
                                }
                            }
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

            private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
            {
                try
                {
                    listBox1.Items.Clear();
                    Modalidade m = new Modalidade();
                    MySqlDataReader Idx = m.consultarModalidade(comboBox1.SelectedItem.ToString());
                    while (Idx.Read())
                    {
                        index = int.Parse(Idx["idEstudio_Modalidade"].ToString());
                        nomeModalidade = (Idx["descricaoModalidade"].ToString());
                    }
                    DAO_Conexao.con.Close();

                    Turma t = new Turma();
                    MySqlDataReader Lbx = t.consultarTurmaId(index);
                    while (Lbx.Read())
                    {
                        nomeTurma = nomeModalidade + "-" + Lbx["diaSemanaTurma"].ToString() + "-" + Lbx["horaTurma"].ToString();
                        listBox1.Items.Add(nomeTurma);
                    }
                    DAO_Conexao.con.Close();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);

                }
            }

            

        }
    } }
