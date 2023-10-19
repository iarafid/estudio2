using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using estudio;

namespace estudio
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            menuStrip1.Enabled = true;

            if (DAO_Conexao.getConexao("143.106.241.3", "cl202237", "cl202237", "cl*26022007"))
            {
                Console.WriteLine("Conectado");
            }
            else
            {
                Console.WriteLine("Erro de conexâo");
            }
                

        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void cadastrarLoginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //cadLogin cad_login = new cadLogin();
            //cad_login.MdiParent = this;
            //cad_login.Show();
            Form2 form2 = new Form2();
            form2.MdiParent = this;
            form2.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String usuario = textBox1.Text;
            String senha = textBox2.Text;

            int tipo = DAO_Conexao.VerificaLogin(usuario, senha);
            if(tipo == 0)
            {
                MessageBox.Show("Usuário ou senha inválidos");
            }
            else if(tipo == 1)
            {
                MessageBox.Show("Conta administrativa", "Aviso", MessageBoxButtons.OK);
                groupBox1.Visible = false;
                menuStrip1.Enabled = true;
            }
            else if(tipo == 2)
            {
                groupBox1.Visible = false;
                menuStrip1.Enabled = true;
                cadastrarAlunoToolStripMenuItem.Enabled = false;
            }
        }

        private void cadastrarAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.MdiParent = this;
            form3.Show();
        }

        private void excluirAlunoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form4 form4 = new Form4();
            form4.MdiParent = this;
            form4.Show();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
                
        }

        private void cadastrarModalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CadastrarModalidade cadModalidade = new CadastrarModalidade();
            cadModalidade.MdiParent = this;
            cadModalidade.Show();
        }

        private void excluirModalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcluirModalidade excluirModalidade = new ExcluirModalidade();
            excluirModalidade.MdiParent = this;
            excluirModalidade.Show();

        }

        private void consultarModalidadeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ConsultarModalidade consultarModalidade = new ConsultarModalidade();
            consultarModalidade.MdiParent = this;
            consultarModalidade.Show();
        }

       

       
        
        private void sairToolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void cadastrarTurmaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            cadastrarTurma cadTurma = new cadastrarTurma();
            cadTurma.MdiParent = this;
            cadTurma.Show();

        }

        private void excluirTurmaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            excluirTurma excluirTurma = new excluirTurma();
            excluirTurma.MdiParent = this;
            excluirTurma.Show();
        }

        private void atualizarTurmaToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            atualizarTurma consultarTurma = new atualizarTurma();
            consultarTurma.MdiParent = this;
            consultarTurma.Show();
        }

        private void arquivoToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
