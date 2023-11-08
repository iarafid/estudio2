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
    public partial class atualizarTurma : Form
    {
        public atualizarTurma()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string modalidade = textBox1.Text;
            string dia_semana = textBox2.Text;
            double hora = double.Parse(textBox3.Text);
            string professor = textBox4.Text;

                Turma turma = new Turma(modalidade, professor, dia_semana, hora);

                if (turma.atualizaTurma())
                {
                    MessageBox.Show("Atualizado com Sucesso");
                }
                else
                {
                    MessageBox.Show("Erro ao Atualizar");
                }
            

        }

        private void atualizarTurma_Load(object sender, EventArgs e)
        {

        }
    }
}
