using System;
using System.Windows.Forms;
using System.Threading;

namespace Arena_Admin
{
    public partial class frmMenu : Form
    {
        Intermediario.Personagens Personagens;          //Instanciação da classe Personagens
        Intermediario.Monstros Monstros;                //Instanciação da classe Monstros

        public frmMenu()                //Método Construtor 
        {
            InitializeComponent();      //Função Padrão
        }

        private void frmMenu_Load(object sender, EventArgs e)       //Evento Load 
        {
            try
            {
                Personagens = new Intermediario.Personagens();      //Instanciação da classe Personagens
                dtgPersonagens.DataSource = Personagens.Listar();       //Setando o DataSource do DataGridView dos Personagens
                Monstros = new Intermediario.Monstros();        //Instanciação da classe Monstros
                dtgMonstros.DataSource = Monstros.Listar();     //Setando o DataSource do DataGridView dos Monstros
            }
            catch (Exception ex)        //Tratamento de erros genérico
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);       //Avisa o usuario do erro
            }
        }

        Random rnd = new Random();

        private void btnPersonagem_Click(object sender, EventArgs e)        //Evento click do botão Personagem 
        {
            frmControlePersonagens FormPersonagens = new frmControlePersonagens();      //Instanciação do Form ControlePersonagens
            FormPersonagens.Show();     //Mostra o Form ControlePersonagens
            this.Hide();        //Esconde o Form Menu
        }
        private void btnMonstros_Click(object sender, EventArgs e)        //Evento click do botão Monstro 
        {
            frmControleMonstros FormMonstros = new frmControleMonstros();      //Instanciação do Form ControleMonstros
            FormMonstros.Show();     //Mostra o Form ControleMonstros
            this.Hide();        //Esconde o Form Menu
        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)       //Encerra o Aplicativo quando o FormMenu é fechado 
        {
            Application.Exit();
        }

        private void txtPesquisarPersonagem_TextChanged(object sender, EventArgs e)     //Evento para pesquisa de Personagens 
        {
            Personagens = new Intermediario.Personagens();      //Instanciação classe Personagens

            if (txtPesquisarPersonagem.Text.Trim() != "")       //Verifica se não está vazio
            {                                                   //Se não está, realiza a pesquisa com o banco de Dados
                dtgPersonagens.DataSource = Personagens.ListarSearch(txtPesquisarPersonagem.Text.Trim());
            }
            else
            {                                                   //Se está, mostra a lista original com o banco de Dados
                dtgPersonagens.DataSource = Personagens.Listar();
            }
        }

        private void txtPesquisarMonstro_TextChanged(object sender, EventArgs e)     //Evento para pesquisa de Monstros 
        {
            Monstros = new Intermediario.Monstros();      //Instanciação classe Personagens

            if (txtPesquisarMonstro.Text.Trim() != "")      //Verifica se não está vazio
            {                                               //Se não está, realiza a pesquisa com o banco de Dados
                dtgMonstros.DataSource = Monstros.ListarSearch(txtPesquisarMonstro.Text.Trim());
            }
            else
            {                                               //Se está, mostra a lista original com o banco de Dados
                dtgMonstros.DataSource = Monstros.Listar();
            }
        }
    }
}
