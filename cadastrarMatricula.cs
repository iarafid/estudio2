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
    public partial class cadastrarMatricula : Form
    {
        public cadastrarMatricula()
        {
            InitializeComponent();
            WindowState = FormWindowState.Maximized;
            Modalidade con_mod = new Modalidade();
            MySqlDataReader r = con_mod.CadastrarMatricula();
            while (r.Read())
            {
                int id = int.Parse(r["idEstudio_Turma"].ToString());
                string mod = r["descricaoModalidade"].ToString();
                string ds = r["diadasemanaModalidade"].ToString();
                string hr = r["horaModalidade"].ToString();
                dataGridView1.Rows.Add(id, mod, ds, hr);
            }
            DAO_Conexao.con.Close();
        }



        private void cadastrarMatricula_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String cpf = this.textBox1.Text;


            Modalidade m1 = new Modalidade(cpf);

            if (m1.CadastrarMatricula())
            {
                MessageBox.Show("Cadastro Realizado com sucesso!");
            }
            else
            {
                MessageBox.Show("Erro no cadastro");
            }
        }
    }
}
