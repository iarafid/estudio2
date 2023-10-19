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
    public partial class ConsultarModalidade : Form
    {
     
        public ConsultarModalidade()
        {
            InitializeComponent();
            Modalidade exc = new Modalidade();
            MySqlDataReader r = exc.ConsultarTodasModalidades();
            while (r.Read())
            {
                comboBox1.Items.Add(r["descricaoModalidade"].ToString());
            }
            DAO_Conexao.con.Close();

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

     private void button1_Click(object sender, EventArgs e)
        {
            String desc = this.comboBox1.Text;
            Double preco = double.Parse(textBox1.Text);
            int alunos = int.Parse(textBox2.Text);
            int aulas = int.Parse(textBox3.Text);

            Modalidade modalidade = new Modalidade(desc, preco, alunos, aulas);
            if (modalidade.atualizaModalidade())
            {
                MessageBox.Show("Atualizado com Sucesso");
            }
            else
            {
                MessageBox.Show("Erro ao Atualizar");
            }

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void ConsultarModalidade_Load(object sender, EventArgs e)
        {
               
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
