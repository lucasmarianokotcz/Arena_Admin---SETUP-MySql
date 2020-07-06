using Intermediario;
using Model.Monstro;
using Model.Monstro.Regras.Classes;
using Model.Shared;
using Model.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Arena_Admin
{
    public partial class frmControleMonstros : Form
    {
        #region Atributos

        private readonly List<Monstro> lstMonstros;
        private EOperacoesCrud operacao = EOperacoesCrud.Retornar;
        private string nomeMonstroEditado = string.Empty;

        #endregion

        #region Event Methods

        public frmControleMonstros()
        {
            InitializeComponent();
            lstMonstros = new MonstroBLL().Select();
        }

        #region Funções que fazem a inverção das respectivas imagens nas tabPages.
        private void btnInverterPicBasicos_Click(object sender, EventArgs e)
        {
            try
            {
                if (picMonstro.Image is null)
                {
                    return;
                }

                picMonstro.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                picMonstro.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro!", ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnInverterPicHab1_Click(object sender, EventArgs e)
        {
            try
            {
                if (picHab1.Image is null)
                {
                    return;
                }

                picHab1.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                picHab1.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnInverterPicHab2_Click(object sender, EventArgs e)
        {
            try
            {
                if (picHab2.Image is null)
                {
                    return;
                }

                picHab2.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                picHab2.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnInverterPicHab3_Click(object sender, EventArgs e)
        {
            try
            {
                if (picHab3.Image is null)
                {
                    return;
                }

                picHab3.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                picHab3.Refresh();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnInverterPicHab4_Click(object sender, EventArgs e)
        {
            try
            {
                if (picHab4.Image is null)
                {
                    return;
                }

                picHab4.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                picHab4.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        #endregion

        #region Funções do ValueChanged de Turno
        private void nums_TurnoHab1_ValueChanged(object sender, EventArgs e)
        {
            string control = ((Control)sender).Name;

            if (control == "numHab1DanoPorTurno")
            {
                if (numHab1DanoPorTurno.Value != 0) { numHab1DanoPorTurno_Turnos.Enabled = true; }
                else { numHab1DanoPorTurno_Turnos.Enabled = false; numHab1DanoPorTurno_Turnos.Value = 2; }
            }
            else if (control == "numHab1DanoPerfurantePorTurno")
            {
                if (numHab1DanoPerfurantePorTurno.Value != 0) { numHab1DanoPerfurantePorTurno_Turnos.Enabled = true; }
                else { numHab1DanoPerfurantePorTurno_Turnos.Enabled = false; numHab1DanoPerfurantePorTurno_Turnos.Value = 2; }
            }
            else if (control == "numHab1DanoVerdadeiroPorTurno")
            {
                if (numHab1DanoVerdadeiroPorTurno.Value != 0) { numHab1DanoVerdadeiroPorTurno_Turnos.Enabled = true; }
                else { numHab1DanoVerdadeiroPorTurno_Turnos.Enabled = false; numHab1DanoVerdadeiroPorTurno_Turnos.Value = 2; }
            }
            else if (control == "numHab1CuraPorTurno")
            {
                if (numHab1CuraPorTurno.Value != 0) { numHab1CuraPorTurno_Turnos.Enabled = true; }
                else { numHab1CuraPorTurno_Turnos.Enabled = false; numHab1CuraPorTurno_Turnos.Value = 2; }
            }
            else if (control == "numHab1ArmaduraPorTurno")
            {
                if (numHab1ArmaduraPorTurno.Value != 0) { numHab1ArmaduraPorTurno_Turnos.Enabled = true; }
                else { numHab1ArmaduraPorTurno_Turnos.Enabled = false; numHab1ArmaduraPorTurno_Turnos.Value = 2; }
            }
        }
        private void nums_TurnoHab2_ValueChanged(object sender, EventArgs e)
        {
            string control = ((Control)sender).Name;

            if (control == "numHab2DanoPorTurno")
            {
                if (numHab2DanoPorTurno.Value != 0) { numHab2DanoPorTurno_Turnos.Enabled = true; }
                else { numHab2DanoPorTurno_Turnos.Enabled = false; numHab2DanoPorTurno_Turnos.Value = 2; }
            }
            else if (control == "numHab2DanoPerfurantePorTurno")
            {
                if (numHab2DanoPerfurantePorTurno.Value != 0) { numHab2DanoPerfurantePorTurno_Turnos.Enabled = true; }
                else { numHab2DanoPerfurantePorTurno_Turnos.Enabled = false; numHab2DanoPerfurantePorTurno_Turnos.Value = 2; }
            }
            else if (control == "numHab2DanoVerdadeiroPorTurno")
            {
                if (numHab2DanoVerdadeiroPorTurno.Value != 0) { numHab2DanoVerdadeiroPorTurno_Turnos.Enabled = true; }
                else { numHab2DanoVerdadeiroPorTurno_Turnos.Enabled = false; numHab2DanoVerdadeiroPorTurno_Turnos.Value = 2; }
            }
            else if (control == "numHab2CuraPorTurno")
            {
                if (numHab2CuraPorTurno.Value != 0) { numHab2CuraPorTurno_Turnos.Enabled = true; }
                else { numHab2CuraPorTurno_Turnos.Enabled = false; numHab2CuraPorTurno_Turnos.Value = 2; }
            }
            else if (control == "numHab2ArmaduraPorTurno")
            {
                if (numHab2ArmaduraPorTurno.Value != 0) { numHab2ArmaduraPorTurno_Turnos.Enabled = true; }
                else { numHab2ArmaduraPorTurno_Turnos.Enabled = false; numHab2ArmaduraPorTurno_Turnos.Value = 2; }
            }
        }
        private void nums_TurnoHab3_ValueChanged(object sender, EventArgs e)
        {
            string control = ((Control)sender).Name;

            if (control == "numHab3DanoPorTurno")
            {
                if (numHab3DanoPorTurno.Value != 0) { numHab3DanoPorTurno_Turnos.Enabled = true; }
                else { numHab3DanoPorTurno_Turnos.Enabled = false; numHab3DanoPorTurno_Turnos.Value = 2; }
            }
            else if (control == "numHab3DanoPerfurantePorTurno")
            {
                if (numHab3DanoPerfurantePorTurno.Value != 0) { numHab3DanoPerfurantePorTurno_Turnos.Enabled = true; }
                else { numHab3DanoPerfurantePorTurno_Turnos.Enabled = false; numHab3DanoPerfurantePorTurno_Turnos.Value = 2; }
            }
            else if (control == "numHab3DanoVerdadeiroPorTurno")
            {
                if (numHab3DanoVerdadeiroPorTurno.Value != 0) { numHab3DanoVerdadeiroPorTurno_Turnos.Enabled = true; }
                else { numHab3DanoVerdadeiroPorTurno_Turnos.Enabled = false; numHab3DanoVerdadeiroPorTurno_Turnos.Value = 2; }
            }
            else if (control == "numHab3CuraPorTurno")
            {
                if (numHab3CuraPorTurno.Value != 0) { numHab3CuraPorTurno_Turnos.Enabled = true; }
                else { numHab3CuraPorTurno_Turnos.Enabled = false; numHab3CuraPorTurno_Turnos.Value = 2; }
            }
            else if (control == "numHab3ArmaduraPorTurno")
            {
                if (numHab3ArmaduraPorTurno.Value != 0) { numHab3ArmaduraPorTurno_Turnos.Enabled = true; }
                else { numHab3ArmaduraPorTurno_Turnos.Enabled = false; numHab3ArmaduraPorTurno_Turnos.Value = 2; }
            }
        }
        private void nums_TurnoHab4_ValueChanged(object sender, EventArgs e)
        {
            string control = ((Control)sender).Name;

            if (control == "numHab4DanoPorTurno")
            {
                if (numHab4DanoPorTurno.Value != 0) { numHab4DanoPorTurno_Turnos.Enabled = true; }
                else { numHab4DanoPorTurno_Turnos.Enabled = false; numHab4DanoPorTurno_Turnos.Value = 2; }
            }
            else if (control == "numHab4DanoPerfurantePorTurno")
            {
                if (numHab4DanoPerfurantePorTurno.Value != 0) { numHab4DanoPerfurantePorTurno_Turnos.Enabled = true; }
                else { numHab4DanoPerfurantePorTurno_Turnos.Enabled = false; numHab4DanoPerfurantePorTurno_Turnos.Value = 2; }
            }
            else if (control == "numHab4DanoVerdadeiroPorTurno")
            {
                if (numHab4DanoVerdadeiroPorTurno.Value != 0) { numHab4DanoVerdadeiroPorTurno_Turnos.Enabled = true; }
                else { numHab4DanoVerdadeiroPorTurno_Turnos.Enabled = false; numHab4DanoVerdadeiroPorTurno_Turnos.Value = 2; }
            }
            else if (control == "numHab4CuraPorTurno")
            {
                if (numHab4CuraPorTurno.Value != 0) { numHab4CuraPorTurno_Turnos.Enabled = true; }
                else { numHab4CuraPorTurno_Turnos.Enabled = false; numHab4CuraPorTurno_Turnos.Value = 2; }
            }
            else if (control == "numHab4ArmaduraPorTurno")
            {
                if (numHab4ArmaduraPorTurno.Value != 0) { numHab4ArmaduraPorTurno_Turnos.Enabled = true; }
                else { numHab4ArmaduraPorTurno_Turnos.Enabled = false; numHab4ArmaduraPorTurno_Turnos.Value = 2; }
            }
        }
        #endregion

        private void SelecionaImagem(object sender, EventArgs e)
        {
            using (OpenFileDialog dlg = new OpenFileDialog())
            {
                dlg.Title = "Selecione uma imagem";
                dlg.Filter = "Arquivos de Imagem (*.BMP; *.JPG; *.GIF,*.PNG,*.TIFF)| *.BMP; *.JPG; *.GIF; *.PNG; *.TIFF";

                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    (sender as PictureBox).Image = Image.FromFile(dlg.FileName);
                }
            }
        }

        private void AvancarTabPage(object sender, EventArgs e)
        {
            if (tabControl1.SelectedTab == tabBasicos)
            {
                if (operacao != EOperacoesCrud.Excluir)
                {
                    tabControl1.SelectedTab = tabHab1;
                }
                else
                {
                    if (!string.IsNullOrWhiteSpace(comboNome.Text))
                    {
                        tabControl1.SelectedTab = tabRevisao;
                    }
                    else
                    {
                        MessageBox.Show("Selecione o Monstro que deseja excluir!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            else if (tabControl1.SelectedTab == tabHab1)
            {
                tabControl1.SelectedTab = tabHab2;
            }
            else if (tabControl1.SelectedTab == tabHab2)
            {
                tabControl1.SelectedTab = tabHab3;
            }
            else if (tabControl1.SelectedTab == tabHab3)
            {
                tabControl1.SelectedTab = tabHab4;
            }
            else if (tabControl1.SelectedTab == tabHab4)
            {
                try
                {
                    if (VerificaFormularios())
                    {
                        MessageBox.Show("Por favor, revise todos os formulários!", "Revise!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tabControl1.SelectedTab = tabRevisao;
                    }
                    else
                    {
                        MessageBox.Show("Você deve preencher o nome e a foto de todas as Habilidades e do Monstro!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void frmControleMonstros_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (operacao == EOperacoesCrud.Retornar)
            {
                frmMenu FormMenu = new frmMenu();
                FormMenu.Show();
            }
            else
            {
                if (MessageBox.Show("Você tem certeza que quer fechar?\nVocê perderá todos os dados!", "Confirmação", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    frmMenu FormMenu = new frmMenu();
                    FormMenu.Show();
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                if (tabControl1.SelectedTab == tabRevisao)
                {
                    if (VerificaFormularios())
                    {
                        foreach (Control ctl in tabRevisao.Controls) ctl.Visible = true;

                        PreencherRevisao();
                    }
                    else
                    {
                        MessageBox.Show("Você precisa preencher pelo menos o nome e foto de cada página!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tabControl1.SelectedTab = tabHab4;
                    }
                }
                else
                {
                    foreach (Control ctl in tabRevisao.Controls) ctl.Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                operacao = EOperacoesCrud.Excluir;

                btnExcluir.Visible = false;
                btnEditar.Visible = false;
                btnCriar.Visible = false;
                txtNome.Visible = false;
                comboNome.Visible = true;
                txtDescricao.Enabled = false;
                picMonstro.Enabled = false;
                btnInverterPicBasicos.Enabled = false;

                //Desativa o controle dos Controls para não edição.
                foreach (Control ctl in tabHab1.Controls) ctl.Enabled = false;
                foreach (Control ctl in tabHab2.Controls) ctl.Enabled = false;
                foreach (Control ctl in tabHab3.Controls) ctl.Enabled = false;
                foreach (Control ctl in tabHab4.Controls) ctl.Enabled = false;

                btnIrHab1.Text = "Revisar";

                LoadMonstros();

                //Deixa os controls visíveis, visto que estavam invisiveis e mostrando apenas os botões de operação.
                tabControl1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            try
            {
                operacao = EOperacoesCrud.Editar;

                btnExcluir.Visible = false;
                btnEditar.Visible = false;
                btnCriar.Visible = false;
                txtNome.Visible = false;
                comboNome.Visible = true;

                LoadMonstros();

                //Deixa os controls visíveis, visto que estavam invisiveis e mostrando apenas os botões de operação (Criar/Editar/Excluir).
                tabControl1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCriar_Click(object sender, EventArgs e)
        {
            try
            {
                operacao = EOperacoesCrud.Adicionar;

                btnExcluir.Visible = false;
                btnEditar.Visible = false;
                btnCriar.Visible = false;

                //Deixa os controls visíveis, visto que estavam invisiveis e mostrando apenas os botões de operação (Criar/Editar/Excluir).
                tabControl1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            switch (operacao)
            {
                case EOperacoesCrud.Adicionar:
                    Adicionar();
                    break;
                case EOperacoesCrud.Editar:
                    Editar();
                    break;
                case EOperacoesCrud.Excluir:
                    Excluir();
                    break;
                default:
                    MessageBox.Show("Operação não identificada.", "Ocorreu um erro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }

        private void comboNome_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                FillDataMonstro();
                btnEditarNomeMonstro.Visible = operacao == EOperacoesCrud.Editar;
                nomeMonstroEditado = comboNome.Text;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditarNomeMonstro_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboNome.Visible)      //Se é pra editar o nome
                {
                    txtNome.Text = comboNome.Text;
                    btnEditarNomeMonstro.Text = "Escolher outro monstro";
                    comboNome.Visible = false;
                    txtNome.Visible = true;
                }
                else                        //Se é pra escolher outro monstro
                {
                    btnEditarNomeMonstro.Text = "Editar nome";
                    txtNome.Visible = false;
                    comboNome.Visible = true;
                    comboNome.DroppedDown = true;   //Abre o comboBox
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Private Methods

        #region Cria o objeto monstro
        private Monstro CreateMonstro()
        {
            var obj = new Monstro();

            obj.Nome = txtNome.Text.Trim();
            obj.Descricao = txtDescricao.Text.Trim();
            obj.Foto = (byte[])new ImageConverter().ConvertTo(picMonstro.Image, typeof(byte[]));

            List<HabilidadeMonstro> lst = new List<HabilidadeMonstro>();
            lst.Add(CreateMonstroHab1());
            lst.Add(CreateMonstroHab2());
            lst.Add(CreateMonstroHab3());
            lst.Add(CreateMonstroHab4());

            obj.Habilidades = lst;

            return obj;
        }
        private Monstro AlteraMonstro()
        {
            Monstro obj = lstMonstros.Where(x => x.Id == Convert.ToInt32(txtID.Text)).First();

            obj.Nome = txtNome.Text.Trim();
            obj.Descricao = txtDescricao.Text.Trim();
            obj.Foto = (byte[])new ImageConverter().ConvertTo(picMonstro.Image, typeof(byte[]));

            List<HabilidadeMonstro> lst = new List<HabilidadeMonstro>();
            int i = 0;
            lst.Add(CreateMonstroHab1(obj.Habilidades[i++].Id));
            lst.Add(CreateMonstroHab2(obj.Habilidades[i++].Id));
            lst.Add(CreateMonstroHab3(obj.Habilidades[i++].Id));
            lst.Add(CreateMonstroHab4(obj.Habilidades[i++].Id));

            obj.Habilidades = lst;

            return obj;
        }
        private HabilidadeMonstro CreateMonstroHab1(int idHab = 0)
        {
            return new HabilidadeMonstro()
            {
                Id = idHab,
                Nome = txtHab1Nome.Text.Trim(),
                Descricao = txtHab1Descricao.Text.Trim(),
                Armadura = new Armadura() { ArmaduraHabilidade = (int)numHab1Armadura.Value },
                ArmaduraPorTurno = new ArmaduraPorTurno() { ArmaduraHabilidade = (int)numHab1ArmaduraPorTurno.Value, Turnos = (int)numHab1ArmaduraPorTurno_Turnos.Value },
                Cura = new Cura() { CuraHabilidade = (int)numHab1Cura.Value },
                CuraPorTurno = new CuraPorTurno() { CuraHabilidade = (int)numHab1CuraPorTurno.Value, Turnos = (int)numHab1CuraPorTurno_Turnos.Value },
                Dano = new Dano() { DanoHabilidade = (int)numHab1Dano.Value },
                DanoPorTurno = new DanoPorTurno() { DanoHabilidade = (int)numHab1DanoPorTurno.Value, Turnos = (int)numHab1DanoPorTurno_Turnos.Value },
                DanoPerfurante = new DanoPerfurante() { DanoHabilidade = (int)numHab1DanoPerfurante.Value },
                DanoPerfurantePorTurno = new DanoPerfurantePorTurno() { DanoHabilidade = (int)numHab1DanoPerfurantePorTurno.Value, Turnos = (int)numHab1DanoPerfurantePorTurno_Turnos.Value },
                DanoVerdadeiro = new DanoVerdadeiro() { DanoHabilidade = (int)numHab1DanoVerdadeiro.Value },
                DanoVerdadeiroPorTurno = new DanoVerdadeiroPorTurno() { DanoHabilidade = (int)numHab1DanoVerdadeiroPorTurno.Value, Turnos = (int)numHab1DanoVerdadeiroPorTurno_Turnos.Value },
                Disposicao = (int)numHab1Disposicao.Value,
                Foto = (byte[])new ImageConverter().ConvertTo(picHab1.Image, typeof(byte[])),
                Invulnerabilidade = (int)numHab1Invulnerabilidade.Value,
                Recarga = (int)numHab1Recarga.Value
            };
        }
        private HabilidadeMonstro CreateMonstroHab2(int idHab = 0)
        {
            return new HabilidadeMonstro()
            {
                Id = idHab,
                Nome = txtHab2Nome.Text.Trim(),
                Descricao = txtHab2Descricao.Text.Trim(),
                Armadura = new Armadura() { ArmaduraHabilidade = (int)numHab2Armadura.Value },
                ArmaduraPorTurno = new ArmaduraPorTurno() { ArmaduraHabilidade = (int)numHab2ArmaduraPorTurno.Value, Turnos = (int)numHab2ArmaduraPorTurno_Turnos.Value },
                Cura = new Cura() { CuraHabilidade = (int)numHab2Cura.Value },
                CuraPorTurno = new CuraPorTurno() { CuraHabilidade = (int)numHab2CuraPorTurno.Value, Turnos = (int)numHab2CuraPorTurno_Turnos.Value },
                Dano = new Dano() { DanoHabilidade = (int)numHab2Dano.Value },
                DanoPorTurno = new DanoPorTurno() { DanoHabilidade = (int)numHab2DanoPorTurno.Value, Turnos = (int)numHab2DanoPorTurno_Turnos.Value },
                DanoPerfurante = new DanoPerfurante() { DanoHabilidade = (int)numHab2DanoPerfurante.Value },
                DanoPerfurantePorTurno = new DanoPerfurantePorTurno() { DanoHabilidade = (int)numHab2DanoPerfurantePorTurno.Value, Turnos = (int)numHab2DanoPerfurantePorTurno_Turnos.Value },
                DanoVerdadeiro = new DanoVerdadeiro() { DanoHabilidade = (int)numHab2DanoVerdadeiro.Value },
                DanoVerdadeiroPorTurno = new DanoVerdadeiroPorTurno() { DanoHabilidade = (int)numHab2DanoVerdadeiroPorTurno.Value, Turnos = (int)numHab2DanoVerdadeiroPorTurno_Turnos.Value },
                Disposicao = (int)numHab2Disposicao.Value,
                Foto = (byte[])new ImageConverter().ConvertTo(picHab2.Image, typeof(byte[])),
                Invulnerabilidade = (int)numHab2Invulnerabilidade.Value,
                Recarga = (int)numHab2Recarga.Value
            };
        }
        private HabilidadeMonstro CreateMonstroHab3(int idHab = 0)
        {
            return new HabilidadeMonstro()
            {
                Id = idHab,
                Nome = txtHab3Nome.Text.Trim(),
                Descricao = txtHab3Descricao.Text.Trim(),
                Armadura = new Armadura() { ArmaduraHabilidade = (int)numHab3Armadura.Value },
                ArmaduraPorTurno = new ArmaduraPorTurno() { ArmaduraHabilidade = (int)numHab3ArmaduraPorTurno.Value, Turnos = (int)numHab3ArmaduraPorTurno_Turnos.Value },
                Cura = new Cura() { CuraHabilidade = (int)numHab3Cura.Value },
                CuraPorTurno = new CuraPorTurno() { CuraHabilidade = (int)numHab3CuraPorTurno.Value, Turnos = (int)numHab3CuraPorTurno_Turnos.Value },
                Dano = new Dano() { DanoHabilidade = (int)numHab3Dano.Value },
                DanoPorTurno = new DanoPorTurno() { DanoHabilidade = (int)numHab3DanoPorTurno.Value, Turnos = (int)numHab3DanoPorTurno_Turnos.Value },
                DanoPerfurante = new DanoPerfurante() { DanoHabilidade = (int)numHab3DanoPerfurante.Value },
                DanoPerfurantePorTurno = new DanoPerfurantePorTurno() { DanoHabilidade = (int)numHab3DanoPerfurantePorTurno.Value, Turnos = (int)numHab3DanoPerfurantePorTurno_Turnos.Value },
                DanoVerdadeiro = new DanoVerdadeiro() { DanoHabilidade = (int)numHab3DanoVerdadeiro.Value },
                DanoVerdadeiroPorTurno = new DanoVerdadeiroPorTurno() { DanoHabilidade = (int)numHab3DanoVerdadeiroPorTurno.Value, Turnos = (int)numHab3DanoVerdadeiroPorTurno_Turnos.Value },
                Disposicao = (int)numHab3Disposicao.Value,
                Foto = (byte[])new ImageConverter().ConvertTo(picHab3.Image, typeof(byte[])),
                Invulnerabilidade = (int)numHab3Invulnerabilidade.Value,
                Recarga = (int)numHab3Recarga.Value
            };
        }
        private HabilidadeMonstro CreateMonstroHab4(int idHab = 0)
        {
            return new HabilidadeMonstro()
            {
                Id = idHab,
                Nome = txtHab4Nome.Text.Trim(),
                Descricao = txtHab4Descricao.Text.Trim(),
                Armadura = new Armadura() { ArmaduraHabilidade = (int)numHab4Armadura.Value },
                ArmaduraPorTurno = new ArmaduraPorTurno() { ArmaduraHabilidade = (int)numHab4ArmaduraPorTurno.Value, Turnos = (int)numHab4ArmaduraPorTurno_Turnos.Value },
                Cura = new Cura() { CuraHabilidade = (int)numHab4Cura.Value },
                CuraPorTurno = new CuraPorTurno() { CuraHabilidade = (int)numHab4CuraPorTurno.Value, Turnos = (int)numHab4CuraPorTurno_Turnos.Value },
                Dano = new Dano() { DanoHabilidade = (int)numHab4Dano.Value },
                DanoPorTurno = new DanoPorTurno() { DanoHabilidade = (int)numHab4DanoPorTurno.Value, Turnos = (int)numHab4DanoPorTurno_Turnos.Value },
                DanoPerfurante = new DanoPerfurante() { DanoHabilidade = (int)numHab4DanoPerfurante.Value },
                DanoPerfurantePorTurno = new DanoPerfurantePorTurno() { DanoHabilidade = (int)numHab4DanoPerfurantePorTurno.Value, Turnos = (int)numHab4DanoPerfurantePorTurno_Turnos.Value },
                DanoVerdadeiro = new DanoVerdadeiro() { DanoHabilidade = (int)numHab4DanoVerdadeiro.Value },
                DanoVerdadeiroPorTurno = new DanoVerdadeiroPorTurno() { DanoHabilidade = (int)numHab4DanoVerdadeiroPorTurno.Value, Turnos = (int)numHab4DanoVerdadeiroPorTurno_Turnos.Value },
                Disposicao = (int)numHab4Disposicao.Value,
                Foto = (byte[])new ImageConverter().ConvertTo(picHab4.Image, typeof(byte[])),
                Invulnerabilidade = (int)numHab4Invulnerabilidade.Value,
                Recarga = (int)numHab4Recarga.Value
            };
        }
        #endregion

        #region Preenche dados do monstro
        private void FillDataMonstro()
        {
            Monstro monstro = lstMonstros.Where(x => x.Nome == comboNome.Text).First();

            txtID.Text = monstro.Id.ToString();
            txtNome.Text = monstro.Nome;
            picMonstro.Image = Image.FromStream(new MemoryStream(monstro.Foto));
            txtDescricao.Text = monstro.Descricao;

            // Isto servirá para referenciar qual habilidade está sendo preenchido os dados.
            int i = 0;

            FillDataHab1(monstro, i++);
            FillDataHab2(monstro, i++);
            FillDataHab3(monstro, i++);
            FillDataHab4(monstro, i++);
        }
        private void FillDataHab1(Monstro monstro, int i)
        {
            txtHab1Nome.Text = monstro.Habilidades[i].Nome;
            picHab1.Image = Image.FromStream(new MemoryStream(monstro.Habilidades[i].Foto));

            numHab1Dano.Value = monstro.Habilidades[i].Dano.DanoHabilidade;
            numHab1DanoPorTurno.Value = monstro.Habilidades[i].DanoPorTurno.DanoHabilidade;
            numHab1DanoPorTurno_Turnos.Value = monstro.Habilidades[i].DanoPorTurno.Turnos;

            numHab1DanoPerfurante.Value = monstro.Habilidades[i].DanoPerfurante.DanoHabilidade;
            numHab1DanoPerfurantePorTurno.Value = monstro.Habilidades[i].DanoPerfurantePorTurno.DanoHabilidade;
            numHab1DanoPerfurantePorTurno_Turnos.Value = monstro.Habilidades[i].DanoPerfurantePorTurno.Turnos;

            numHab1DanoVerdadeiro.Value = monstro.Habilidades[i].DanoVerdadeiro.DanoHabilidade;
            numHab1DanoVerdadeiroPorTurno.Value = monstro.Habilidades[i].DanoVerdadeiroPorTurno.DanoHabilidade;
            numHab1DanoVerdadeiroPorTurno_Turnos.Value = monstro.Habilidades[i].DanoVerdadeiroPorTurno.Turnos;

            numHab1Cura.Value = monstro.Habilidades[i].Cura.CuraHabilidade;
            numHab1CuraPorTurno.Value = monstro.Habilidades[i].CuraPorTurno.CuraHabilidade;
            numHab1CuraPorTurno_Turnos.Value = monstro.Habilidades[i].CuraPorTurno.Turnos;

            numHab1Armadura.Value = monstro.Habilidades[i].Armadura.ArmaduraHabilidade;
            numHab1ArmaduraPorTurno.Value = monstro.Habilidades[i].ArmaduraPorTurno.ArmaduraHabilidade;
            numHab1ArmaduraPorTurno_Turnos.Value = monstro.Habilidades[i].ArmaduraPorTurno.Turnos;

            txtHab1Descricao.Text = monstro.Habilidades[i].Descricao;
            numHab1Recarga.Value = monstro.Habilidades[i].Recarga;
            numHab1Disposicao.Value = monstro.Habilidades[i].Disposicao;
            numHab1Invulnerabilidade.Value = monstro.Habilidades[i].Invulnerabilidade;
        }
        private void FillDataHab2(Monstro monstro, int i)
        {
            txtHab2Nome.Text = monstro.Habilidades[i].Nome;
            picHab2.Image = Image.FromStream(new MemoryStream(monstro.Habilidades[i].Foto));

            numHab2Dano.Value = monstro.Habilidades[i].Dano.DanoHabilidade;
            numHab2DanoPorTurno.Value = monstro.Habilidades[i].DanoPorTurno.DanoHabilidade;
            numHab2DanoPorTurno_Turnos.Value = monstro.Habilidades[i].DanoPorTurno.Turnos;

            numHab2DanoPerfurante.Value = monstro.Habilidades[i].DanoPerfurante.DanoHabilidade;
            numHab2DanoPerfurantePorTurno.Value = monstro.Habilidades[i].DanoPerfurantePorTurno.DanoHabilidade;
            numHab2DanoPerfurantePorTurno_Turnos.Value = monstro.Habilidades[i].DanoPerfurantePorTurno.Turnos;

            numHab2DanoVerdadeiro.Value = monstro.Habilidades[i].DanoVerdadeiro.DanoHabilidade;
            numHab2DanoVerdadeiroPorTurno.Value = monstro.Habilidades[i].DanoVerdadeiroPorTurno.DanoHabilidade;
            numHab2DanoVerdadeiroPorTurno_Turnos.Value = monstro.Habilidades[i].DanoVerdadeiroPorTurno.Turnos;

            numHab2Cura.Value = monstro.Habilidades[i].Cura.CuraHabilidade;
            numHab2CuraPorTurno.Value = monstro.Habilidades[i].CuraPorTurno.CuraHabilidade;
            numHab2CuraPorTurno_Turnos.Value = monstro.Habilidades[i].CuraPorTurno.Turnos;

            numHab2Armadura.Value = monstro.Habilidades[i].Armadura.ArmaduraHabilidade;
            numHab2ArmaduraPorTurno.Value = monstro.Habilidades[i].ArmaduraPorTurno.ArmaduraHabilidade;
            numHab2ArmaduraPorTurno_Turnos.Value = monstro.Habilidades[i].ArmaduraPorTurno.Turnos;

            txtHab2Descricao.Text = monstro.Habilidades[i].Descricao;
            numHab2Recarga.Value = monstro.Habilidades[i].Recarga;
            numHab2Disposicao.Value = monstro.Habilidades[i].Disposicao;
            numHab2Invulnerabilidade.Value = monstro.Habilidades[i].Invulnerabilidade;
        }
        private void FillDataHab3(Monstro monstro, int i)
        {
            txtHab3Nome.Text = monstro.Habilidades[i].Nome;
            picHab3.Image = Image.FromStream(new MemoryStream(monstro.Habilidades[i].Foto));

            numHab3Dano.Value = monstro.Habilidades[i].Dano.DanoHabilidade;
            numHab3DanoPorTurno.Value = monstro.Habilidades[i].DanoPorTurno.DanoHabilidade;
            numHab3DanoPorTurno_Turnos.Value = monstro.Habilidades[i].DanoPorTurno.Turnos;

            numHab3DanoPerfurante.Value = monstro.Habilidades[i].DanoPerfurante.DanoHabilidade;
            numHab3DanoPerfurantePorTurno.Value = monstro.Habilidades[i].DanoPerfurantePorTurno.DanoHabilidade;
            numHab3DanoPerfurantePorTurno_Turnos.Value = monstro.Habilidades[i].DanoPerfurantePorTurno.Turnos;

            numHab3DanoVerdadeiro.Value = monstro.Habilidades[i].DanoVerdadeiro.DanoHabilidade;
            numHab3DanoVerdadeiroPorTurno.Value = monstro.Habilidades[i].DanoVerdadeiroPorTurno.DanoHabilidade;
            numHab3DanoVerdadeiroPorTurno_Turnos.Value = monstro.Habilidades[i].DanoVerdadeiroPorTurno.Turnos;

            numHab3Cura.Value = monstro.Habilidades[i].Cura.CuraHabilidade;
            numHab3CuraPorTurno.Value = monstro.Habilidades[i].CuraPorTurno.CuraHabilidade;
            numHab3CuraPorTurno_Turnos.Value = monstro.Habilidades[i].CuraPorTurno.Turnos;

            numHab3Armadura.Value = monstro.Habilidades[i].Armadura.ArmaduraHabilidade;
            numHab3ArmaduraPorTurno.Value = monstro.Habilidades[i].ArmaduraPorTurno.ArmaduraHabilidade;
            numHab3ArmaduraPorTurno_Turnos.Value = monstro.Habilidades[i].ArmaduraPorTurno.Turnos;

            txtHab3Descricao.Text = monstro.Habilidades[i].Descricao;
            numHab3Recarga.Value = monstro.Habilidades[i].Recarga;
            numHab3Disposicao.Value = monstro.Habilidades[i].Disposicao;
            numHab3Invulnerabilidade.Value = monstro.Habilidades[i].Invulnerabilidade;
        }
        private void FillDataHab4(Monstro monstro, int i)
        {
            txtHab4Nome.Text = monstro.Habilidades[i].Nome;
            picHab4.Image = Image.FromStream(new MemoryStream(monstro.Habilidades[i].Foto));

            numHab4Dano.Value = monstro.Habilidades[i].Dano.DanoHabilidade;
            numHab4DanoPorTurno.Value = monstro.Habilidades[i].DanoPorTurno.DanoHabilidade;
            numHab4DanoPorTurno_Turnos.Value = monstro.Habilidades[i].DanoPorTurno.Turnos;

            numHab4DanoPerfurante.Value = monstro.Habilidades[i].DanoPerfurante.DanoHabilidade;
            numHab4DanoPerfurantePorTurno.Value = monstro.Habilidades[i].DanoPerfurantePorTurno.DanoHabilidade;
            numHab4DanoPerfurantePorTurno_Turnos.Value = monstro.Habilidades[i].DanoPerfurantePorTurno.Turnos;

            numHab4DanoVerdadeiro.Value = monstro.Habilidades[i].DanoVerdadeiro.DanoHabilidade;
            numHab4DanoVerdadeiroPorTurno.Value = monstro.Habilidades[i].DanoVerdadeiroPorTurno.DanoHabilidade;
            numHab4DanoVerdadeiroPorTurno_Turnos.Value = monstro.Habilidades[i].DanoVerdadeiroPorTurno.Turnos;

            numHab4Cura.Value = monstro.Habilidades[i].Cura.CuraHabilidade;
            numHab4CuraPorTurno.Value = monstro.Habilidades[i].CuraPorTurno.CuraHabilidade;
            numHab4CuraPorTurno_Turnos.Value = monstro.Habilidades[i].CuraPorTurno.Turnos;

            numHab4Armadura.Value = monstro.Habilidades[i].Armadura.ArmaduraHabilidade;
            numHab4ArmaduraPorTurno.Value = monstro.Habilidades[i].ArmaduraPorTurno.ArmaduraHabilidade;
            numHab4ArmaduraPorTurno_Turnos.Value = monstro.Habilidades[i].ArmaduraPorTurno.Turnos;

            txtHab4Descricao.Text = monstro.Habilidades[i].Descricao;
            numHab4Recarga.Value = monstro.Habilidades[i].Recarga;
            numHab4Disposicao.Value = monstro.Habilidades[i].Disposicao;
            numHab4Invulnerabilidade.Value = monstro.Habilidades[i].Invulnerabilidade;
        }
        #endregion

        private void Adicionar()
        {
            try
            {
                if (!IsValidNomeMonstro())
                {
                    MessageBox.Show("Já existe um monstro com esse nome.", "Erro ao adicionar monstro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var obj = CreateMonstro();
                var validacao = new MonstroValidacao();
                validacao.ValidaMonstro(obj);

                if (validacao.Erros.Length > 0)
                {
                    MessageBox.Show(validacao.Erros, "Monstro inválido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool aux = new MonstroBLL().Insert(obj);
                if (aux)
                {
                    MessageBox.Show("Monstro criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    operacao = EOperacoesCrud.Retornar;
                    Close();
                }
                else
                    MessageBox.Show("Ocorreu um erro ao adicionar o monstro.", "Erro ao adicionar monstro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao adicionar monstro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Editar()
        {
            try
            {
                if (!IsValidNomeMonstro())
                {
                    MessageBox.Show("Já existe um monstro com esse nome.", "Erro ao editar monstro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                var obj = AlteraMonstro();
                var validacao = new MonstroValidacao();
                validacao.ValidaMonstro(obj);

                if (validacao.Erros.Length > 0)
                {
                    MessageBox.Show(validacao.Erros, "Monstro inválido.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                bool aux = new MonstroBLL().Update(obj);
                if (aux)
                {
                    MessageBox.Show("Monstro alterado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    operacao = EOperacoesCrud.Retornar;
                    Close();
                }

                else
                    MessageBox.Show("Ocorreu um erro ao alterar o monstro.", "Erro ao alterar monstro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao alterar monstro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Excluir()
        {
            try
            {
                bool aux = new MonstroBLL().Delete(Convert.ToInt32(txtID.Text));
                if (aux)
                {
                    MessageBox.Show("Monstro excluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    operacao = EOperacoesCrud.Retornar;
                    Close();
                }
                else
                    MessageBox.Show("Ocorreu um erro ao alterar o monstro", "Erro ao excluir monstro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro ao excluir monstro.", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadMonstros()
        {
            // Filtra a lista pegando somente o nome dos personagens.
            object[] lstNomes = lstMonstros.OrderBy(x => x.Nome).Select(x => x.Nome).ToArray();
            comboNome.Items.AddRange(lstNomes);
        }

        private bool IsValidNomeMonstro()
        {
            if (!string.IsNullOrWhiteSpace(nomeMonstroEditado) && nomeMonstroEditado.ToLower() == txtNome.Text.Trim().ToLower())
            {
                return true;
            }

            foreach (var item in lstMonstros)
            {
                if (item.Nome.ToLower() == txtNome.Text.Trim().ToLower())
                {
                    return false;
                }
            }
            return true;
        }

        private void PreencherRevisao()
        {
            #region PictureBoxes
            picConfirmaMonstro.Image = picMonstro.Image;
            picConfirmaHab1.Image = picHab1.Image;
            picConfirmaHab2.Image = picHab2.Image;
            picConfirmaHab3.Image = picHab3.Image;
            picConfirmaHab4.Image = picHab4.Image;
            #endregion

            #region Monstro
            StringBuilder strMonstro = new StringBuilder();
            strMonstro.Append("Nome: " + txtNome.Text.Trim());
            strMonstro.Append("\nDescrição: " + txtDescricao.Text.Trim());
            rtxtConfirmaMonstro.Text = strMonstro.ToString();
            #endregion

            #region Habilidade1
            StringBuilder strHab1 = new StringBuilder();
            strHab1.Append("Nome: " + txtHab1Nome.Text.Trim());
            strHab1.Append("\n\nDano: " + numHab1Dano.Value);
            strHab1.Append("\nDano Perfurante: " + numHab1DanoPerfurante.Value);
            strHab1.Append("\nDano Verdadeiro: " + numHab1DanoVerdadeiro.Value);
            strHab1.Append("\nCura: " + numHab1Cura.Value);
            strHab1.Append("\nArmadura: " + numHab1Armadura.Value);
            strHab1.Append("\n\nDano por Turno: " + numHab1DanoPorTurno.Value + "\nDuração: " + numHab1DanoPorTurno_Turnos.Value + "\n---------------");
            strHab1.Append("\nDano Perfurante por Turno: " + numHab1DanoPerfurantePorTurno.Value + "\nDuração: " + numHab1DanoPerfurantePorTurno_Turnos.Value + "\n---------------");
            strHab1.Append("\nDano Verdadeiro por Turno: " + numHab1DanoVerdadeiroPorTurno.Value + "\nDuração: " + numHab1DanoVerdadeiroPorTurno_Turnos.Value + "\n---------------");
            strHab1.Append("\nCura por Turno: " + numHab1CuraPorTurno.Value + "\nDuração: " + numHab1CuraPorTurno_Turnos.Value + "\n---------------");
            strHab1.Append("\nArmadura por Turno: " + numHab1ArmaduraPorTurno.Value + "\nDuração: " + numHab1ArmaduraPorTurno_Turnos.Value);
            strHab1.Append("\n\nDescrição: " + txtHab1Descricao.Text.Trim());
            strHab1.Append("\n\nTempo de Recarga: " + numHab1Recarga.Value + " turno(s)");
            strHab1.Append("\nTempo de Invulnerabilidade: " + numHab1Invulnerabilidade.Value);
            strHab1.Append("\nDisposição: " + numHab1Disposicao.Value);
            rtxtConfirmaHab1.Text = strHab1.ToString();
            #endregion

            #region Habilidade2
            StringBuilder strHab2 = new StringBuilder();
            strHab2.Append("Nome: " + txtHab2Nome.Text.Trim());
            strHab2.Append("\n\nDano: " + numHab2Dano.Value);
            strHab2.Append("\nDano Perfurante: " + numHab2DanoPerfurante.Value);
            strHab2.Append("\nDano Verdadeiro: " + numHab2DanoVerdadeiro.Value);
            strHab2.Append("\nCura: " + numHab2Cura.Value);
            strHab2.Append("\nArmadura: " + numHab2Armadura.Value);
            strHab2.Append("\n\nDano por Turno: " + numHab2DanoPorTurno.Value + "\nDuração: " + numHab2DanoPorTurno_Turnos.Value + "\n---------------");
            strHab2.Append("\nDano Perfurante por Turno: " + numHab2DanoPerfurantePorTurno.Value + "\nDuração: " + numHab2DanoPerfurantePorTurno_Turnos.Value + "\n---------------");
            strHab2.Append("\nDano Verdadeiro por Turno: " + numHab2DanoVerdadeiroPorTurno.Value + "\nDuração: " + numHab2DanoVerdadeiroPorTurno_Turnos.Value + "\n---------------");
            strHab2.Append("\nCura por Turno: " + numHab2CuraPorTurno.Value + "\nDuração: " + numHab2CuraPorTurno_Turnos.Value + "\n---------------");
            strHab2.Append("\nArmadura por Turno: " + numHab2ArmaduraPorTurno.Value + "\nDuração: " + numHab2ArmaduraPorTurno_Turnos.Value);
            strHab2.Append("\n\nDescrição: " + txtHab2Descricao.Text.Trim());
            strHab2.Append("\n\nTempo de Recarga: " + numHab2Recarga.Value + " turno(s)");
            strHab2.Append("\nTempo de Invulnerabilidade: " + numHab2Invulnerabilidade.Value);
            strHab2.Append("\nDisposição: " + numHab2Disposicao.Value);
            rtxtConfirmaHab2.Text = strHab2.ToString();
            #endregion

            #region Habilidade3
            StringBuilder strHab3 = new StringBuilder();
            strHab3.Append("Nome: " + txtHab3Nome.Text.Trim());
            strHab3.Append("\n\nDano: " + numHab3Dano.Value);
            strHab3.Append("\nDano Perfurante: " + numHab3DanoPerfurante.Value);
            strHab3.Append("\nDano Verdadeiro: " + numHab3DanoVerdadeiro.Value);
            strHab3.Append("\nCura: " + numHab3Cura.Value);
            strHab3.Append("\nArmadura: " + numHab3Armadura.Value);
            strHab3.Append("\n\nDano por Turno: " + numHab3DanoPorTurno.Value + "\nDuração: " + numHab3DanoPorTurno_Turnos.Value + "\n---------------");
            strHab3.Append("\nDano Perfurante por Turno: " + numHab3DanoPerfurantePorTurno.Value + "\nDuração: " + numHab3DanoPerfurantePorTurno_Turnos.Value + "\n---------------");
            strHab3.Append("\nDano Verdadeiro por Turno: " + numHab3DanoVerdadeiroPorTurno.Value + "\nDuração: " + numHab3DanoVerdadeiroPorTurno_Turnos.Value + "\n---------------");
            strHab3.Append("\nCura por Turno: " + numHab3CuraPorTurno.Value + "\nDuração: " + numHab3CuraPorTurno_Turnos.Value + "\n---------------");
            strHab3.Append("\nArmadura por Turno: " + numHab3ArmaduraPorTurno.Value + "\nDuração: " + numHab3ArmaduraPorTurno_Turnos.Value);
            strHab3.Append("\n\nDescrição: " + txtHab3Descricao.Text.Trim());
            strHab3.Append("\n\nTempo de Recarga: " + numHab3Recarga.Value + " turno(s)");
            strHab3.Append("\nTempo de Invulnerabilidade: " + numHab3Invulnerabilidade.Value);
            strHab3.Append("\nDisposição: " + numHab3Disposicao.Value);
            rtxtConfirmaHab3.Text = strHab3.ToString();
            #endregion

            #region Habilidade4
            StringBuilder strHab4 = new StringBuilder();
            strHab4.Append("Nome: " + txtHab4Nome.Text.Trim());
            strHab4.Append("\n\nDano: " + numHab4Dano.Value);
            strHab4.Append("\nDano Perfurante: " + numHab4DanoPerfurante.Value);
            strHab4.Append("\nDano Verdadeiro: " + numHab4DanoVerdadeiro.Value);
            strHab4.Append("\nCura: " + numHab4Cura.Value);
            strHab4.Append("\nArmadura: " + numHab4Armadura.Value);
            strHab4.Append("\n\nDano por Turno: " + numHab4DanoPorTurno.Value + "\nDuração: " + numHab4DanoPorTurno_Turnos.Value + "\n---------------");
            strHab4.Append("\nDano Perfurante por Turno: " + numHab4DanoPerfurantePorTurno.Value + "\nDuração: " + numHab4DanoPerfurantePorTurno_Turnos.Value + "\n---------------");
            strHab4.Append("\nDano Verdadeiro por Turno: " + numHab4DanoVerdadeiroPorTurno.Value + "\nDuração: " + numHab4DanoVerdadeiroPorTurno_Turnos.Value + "\n---------------");
            strHab4.Append("\nCura por Turno: " + numHab4CuraPorTurno.Value + "\nDuração: " + numHab4CuraPorTurno_Turnos.Value + "\n---------------");
            strHab4.Append("\nArmadura por Turno: " + numHab4ArmaduraPorTurno.Value + "\nDuração: " + numHab4ArmaduraPorTurno_Turnos.Value);
            strHab4.Append("\n\nDescrição: " + txtHab4Descricao.Text.Trim());
            strHab4.Append("\n\nTempo de Recarga: " + numHab4Recarga.Value + " turno(s)");
            strHab4.Append("\nTempo de Invulnerabilidade: " + numHab4Invulnerabilidade.Value);
            strHab4.Append("\nDisposição: " + numHab4Disposicao.Value);
            rtxtConfirmaHab4.Text = strHab4.ToString();
            #endregion
        }

        private bool VerificaFormularios() // Verifica se os nomes e imagens do monstro estão carregados.
        {
            return (!string.IsNullOrWhiteSpace(txtNome.Text) || !string.IsNullOrWhiteSpace(comboNome.Text)) &&
                    !string.IsNullOrWhiteSpace(txtHab1Nome.Text) &&
                    !string.IsNullOrWhiteSpace(txtHab2Nome.Text) &&
                    !string.IsNullOrWhiteSpace(txtHab3Nome.Text) &&
                    !string.IsNullOrWhiteSpace(txtHab4Nome.Text) &&
                    picMonstro.Image != null &&
                    picHab1.Image != null &&
                    picHab2.Image != null &&
                    picHab3.Image != null &&
                    picHab4.Image != null;
        }

        #endregion
    }
}
