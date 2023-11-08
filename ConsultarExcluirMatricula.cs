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
    public partial class ConsultarExcluirMatricula : Form
    {
        private int index;
        private string nomeModalidade;
        private string nomeTurma;
        private String[] resultado;
        private string nomeLista;
        private string modalidadeSelected;
        private string horarioSelected;
        private int idModalidadeBusca;
        private string horaSelected;
        private int idTurma;
        private String nomeAluno;
        private string CPFAluno;
        private int contador = 1;
        public ConsultarExcluirMatricula(int id)
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
                button1.Visible = false;
                textBox1.Enabled = false;
                if (id == 1)
                {
                    button1.Visible = true;
                    this.Text = "Excluir";
                    textBox1.Visible = false;
                    label2.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                listBox2.Items.Clear();
                listBox1.Items.Clear();
                Modalidade ma = new Modalidade();
                MySqlDataReader Idx = ma.consultarModalidade(comboBox1.SelectedItem.ToString());
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
                    listBox2.Items.Add(nomeTurma);
                }
                DAO_Conexao.con.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void listBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                Matricula ma = new Matricula();
                Turma t = new Turma();
                t.setQtdeMax(index);

                Aluno a = new Aluno();

                MySqlDataReader reader = ma.consultarMatriculaInnerJoin(obterIdTurma());

                while (reader.Read())
                {
                    nomeLista = reader["nomeAluno"].ToString() + "-" + reader["CPFAluno"].ToString();
                    listBox1.Items.Add(nomeLista);
                }
                DAO_Conexao.con.Close();
                textBox1.Text = ma.contarAlunos(obterIdTurma()).ToString();
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
                resultado = (listBox2.SelectedItem.ToString()).Split('-');
                modalidadeSelected = resultado[0];
                horarioSelected = resultado[1];
                horaSelected = resultado[2];

                Modalidade mod = new Modalidade();
                MySqlDataReader Mod = mod.consultarModalidade(modalidadeSelected);
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

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                Matricula ma = new Matricula();
                if (ma.excluirAlunoMatricula(obterCPFAluno()))
                {
                    MessageBox.Show("Excluido Com Sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro ao Excluir");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }

        private string obterCPFAluno()
        {
            try
            {
                resultado = (listBox1.SelectedItem.ToString()).Split('-');
                nomeAluno = resultado[0];
                CPFAluno = resultado[1];
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return CPFAluno;
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void ConsultarExcluirMatricula_Load(object sender, EventArgs e)
        {

        }
    }


}
