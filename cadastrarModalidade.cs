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
using estudio;
using Estudio;

namespace estudio
{
    public partial class CadastrarModalidade : Form
    {
        public CadastrarModalidade()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

            String desc = this.txtdesc.Text;
            Double preco = double.Parse(txtPreco.Text);
            int alunos = int.Parse(txtAlunos.Text);
            int aulas = int.Parse(txtAulas.Text);


            Modalidade m1 = new Modalidade(desc, preco , alunos , aulas) ;
           
                if (m1.cadastrarModalidade())
                {
                    MessageBox.Show("Cadastro Realizado com sucesso!");
                }
                else
                {
                    MessageBox.Show("Erro no cadastro");
                }
            
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }
}
