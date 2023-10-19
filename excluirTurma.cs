using Estudio;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace estudio
{
    public partial class excluirTurma : Form
    {
        public excluirTurma()
        {
            InitializeComponent();
            Modalidade modalidade1 = new Modalidade();
            MySqlDataReader x = modalidade1.ConsultarTodasModalidades();
            while (x.Read())
            {
                comboBox2.Items.Add(x["descricaoModalidade"].ToString());
            }
            DAO_Conexao.con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // int dia_semana = int.Parse(comboBox1.Text);
            // double hora = int.Parse(comboBox3.Text);
            string modalidade = comboBox2.Text; 

            try
            {
                Turma t = new Turma();
             
                if (t.consultarTurma(modalidade))
                {
                    if (t.excluirTurma(modalidade))
                    {
                        MessageBox.Show("Turma Excluida");
                    }
                }
                else
                {
                    MessageBox.Show("Turma inexistente");
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro ao excluir");
            }
        }

        private void excluirTurma_Load(object sender, EventArgs e)
        {

        }
    }
}
