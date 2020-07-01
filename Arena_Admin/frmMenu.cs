using Intermediario;
using Model.Monstro;
using Model.Personagem;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Arena_Admin
{
    public partial class frmMenu : Form
    {
        private List<Personagem> lstPersonagens;
        private List<Monstro> lstMonstros;

        public frmMenu()
        {
            InitializeComponent();
        }

        private void frmMenu_Load(object sender, EventArgs e)
        {
            try
            {
                dtgPersonagens.DataSource = lstPersonagens = new PersonagemBLL().Select();
                dtgMonstros.DataSource = lstMonstros = new MonstroBLL().Select();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnPersonagem_Click(object sender, EventArgs e)
        {
            frmControlePersonagens FormPersonagens = new frmControlePersonagens();
            FormPersonagens.Show();
            this.Hide();
        }

        private void btnMonstros_Click(object sender, EventArgs e)
        {
            frmControleMonstros FormMonstros = new frmControleMonstros();
            FormMonstros.Show();
            this.Hide();
        }

        private void frmMenu_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void txtPesquisarPersonagem_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPesquisarPersonagem.Text))
            {
                dtgPersonagens.DataSource = lstPersonagens.Where(x => x.Nome.ToLower().StartsWith(txtPesquisarPersonagem.Text.Trim().ToLower())).ToList();
            }
            else
            {
                dtgPersonagens.DataSource = lstPersonagens;
            }
        }

        private void txtPesquisarMonstro_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtPesquisarMonstro.Text))
            {
                dtgMonstros.DataSource = lstMonstros.Where(x => x.Nome.ToLower().StartsWith(txtPesquisarMonstro.Text.Trim().ToLower())).ToList();
            }
            else
            {
                dtgMonstros.DataSource = lstMonstros;
            }
        }
    }
}
