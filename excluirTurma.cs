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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace estudio
{
    public partial class excluirTurma : Form
    {
        public excluirTurma()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int dia_semana = int.Parse(comboBox1.Text);
            double hora = int.Parse(comboBox3.Text);
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


                t.excluirTurma(modalidade);
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
