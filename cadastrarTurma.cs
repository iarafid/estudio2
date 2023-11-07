using Estudio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace estudio
{
    public partial class cadastrarTurma : Form
    {
        public cadastrarTurma()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            Modalidade con_mod = new Modalidade();
            MySqlDataReader r = con_mod.ConsultarTodasModalidades();
            while (r.Read())
                dataGridView1.Rows.Add(r["descricaoModalidade"].ToString());
            DAO_Conexao.con.Close();

        }

        private void cadastrarTurma_Load(object sender, EventArgs e)

        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            String professor = this.textBox2.Text;
            String dia_semana = this.textBox3.Text;
            double hora = int.Parse(textBox4.Text);
            String modalidade = this.textBox1.Text;


            Turma t1 = new Turma(modalidade, professor, dia_semana, hora);

            if (t1.cadastrarTurma(professor, dia_semana, hora, modalidade))
            {
                MessageBox.Show("Cadastro Realizado com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro no cadastro");
            }

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}