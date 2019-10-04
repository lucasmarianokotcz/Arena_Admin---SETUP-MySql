using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Arena_Admin
{
    public partial class frmControlePersonagens : Form
    {
        public frmControlePersonagens()     //Método Construtor e Inicialização do Form
        {
            InitializeComponent();
        }
                //Instanciação da classe Personagens
        Intermediario.Personagens PersonagensIntermediario;

		DataTable dt = new DataTable();

        bool Terminou = false;       //Variável que controla o fechamento do Form
        string Operacao = "";       //Variável para identificar a operação (Novo Personagem, Editar, Excluir)

        private void SelecionaImagem(object sender, EventArgs e) //Função do OpenFileDialog 
        {
            using (OpenFileDialog dlg = new OpenFileDialog())   //Instanciação da ferramenta
            {
                dlg.Title = "Selecione uma imagem";             //Seta o título do Form
                dlg.Filter = "Arquivos de Imagem (*.BMP; *.JPG; *.GIF,*.PNG,*.TIFF)| *.BMP; *.JPG; *.GIF; *.PNG; *.TIFF"; //Filtra apenas imagens

                if (dlg.ShowDialog() == DialogResult.OK)        //Se escolheu uma imagem,
                {
                    (sender as PictureBox).Image = Image.FromFile(dlg.FileName); //Seta a imagem no pictureBox alvo
                }
            }
        }

        private void AvançarTabPage(object sender, EventArgs e) //Evento click nos botões próximo 
        {
            if (tabControl1.SelectedTab == tabBasicos)  //Se a tabPage atual é a do Básico
            {
                if (Operacao != "Excluir")              //Se a operação é diferente de excluir
                {
                    tabControl1.SelectedTab = tabHab1;  //Avançar um tabPage
                }
                else                                    //Se a operação é pra excluir
                {
                    if (comboNome.Text != "")           //Se foi escolhido um personagem pra excluir
                    {
                        tabControl1.SelectedTab = tabRevisão;   //Avança para a tabPage Revisão.
                    }
                    else                                //Se não foi escolhido um personagem para excluir     
                    {
                        MessageBox.Show("Selecione o Personagem que deseja excluir!", "Aviso!", MessageBoxButtons.OK, MessageBoxIcon.Warning); //Avisa o usuário para escolher um monstro
                    }
                }
            }
            else if (tabControl1.SelectedTab == tabHab1)  //Se a tabPage atual é a da Hab1
            {
                tabControl1.SelectedTab = tabHab2;        //Avança para a tabPage da Hab2
            }
            else if (tabControl1.SelectedTab == tabHab2)  //Se a tabPage atual é a da Hab2
            {
                tabControl1.SelectedTab = tabHab3;        //Avança para a tabPage da Hab3
            }
            else if (tabControl1.SelectedTab == tabHab3)  //Se a tabPage atual é a da Hab3
            {
                tabControl1.SelectedTab = tabHab4;        //Avança para a tabPage da Hab4
            }
            else if (tabControl1.SelectedTab == tabHab4)  //Se a tabPage atual é a da Hab3
            {
                try
                {
                    if (VerificaFormularios())                  //Se todos os formulários estiverem preenchidos,
                    {                                           //Avisa para o usuário revisar a tabPage Revisão
                        MessageBox.Show("Por favor, revise todos os formulários!", "Revise!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        tabControl1.SelectedTab = tabRevisão;   //Avança para a tabPage Revisão
                    }
                    else                                        //Se existir formulários não preenchidos, Avisa o usuário para preenche-los.
                    {
                        MessageBox.Show("Você deve preencher o nome e a foto de todas as Habilidades e do Personagem!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
                catch (Exception ex)                            //Tratamento de erro genérico.
                {
                    MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PreencherRevisao() //Função para preencher a tabPage Revisão 
        {   //Preenchimento dos picturebox da tabPage Revisão
            #region PictureBoxes
            picConfirmaPersonagem.Image = picPersonagem.Image;
            picConfirmaHab1.Image = picHab1.Image;
            picConfirmaHab2.Image = picHab2.Image;
            picConfirmaHab3.Image = picHab3.Image;
            picConfirmaHab4.Image = picHab4.Image;
            #endregion
            //Criação do texto e Preenchimento das informações do Personagem
            #region Personagem
            StringBuilder strPersonagem = new StringBuilder();                  //Variavel que armazena o texto
            strPersonagem.Append("Nome: " + txtNome.Text.Trim());               //Concatenação da string
            strPersonagem.Append("\nDescrição: " + txtDescricao.Text.Trim());
            rtfConfirmaPersonagem.Text = strPersonagem.ToString();             //Preenchendo o control
			#endregion
			//Criação do texto e Preenchimento das informações da Hab1
			#region Habilidade1
			StringBuilder strHab1 = new StringBuilder();                 //Variavel que armazena o texto
			strHab1.Append("Nome: " + txtHab1Nome.Text.Trim());          //Concatenação da string
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
			strHab1.Append("\n\nEnergias:");
			strHab1.Append("\nVerde(s): " + numHab1Verdes.Value);
			strHab1.Append("\nAzul(s): " + numHab1Azuls.Value);
			strHab1.Append("\nVermelho(s): " + numHab1Vermelhos.Value);
			strHab1.Append("\nPreto(s): " + numHab1Pretos.Value);
			strHab1.Append("\n\nTempo de Invulnerabilidade: " + numHab1Invulnerabilidade.Value + " turno(s)");
			strHab1.Append("\n\nEnergias ganhas:");
			strHab1.Append("\nVerde(s) Ganhos: " + numHab1VerdesGanhos.Value);
			strHab1.Append("\nAzul(s) Ganhos: " + numHab1AzulsGanhos.Value);
			strHab1.Append("\nVermelho(s) Ganhos: " + numHab1VermelhosGanhos.Value);
			strHab1.Append("\nPreto(s) Ganhos: " + numHab1PretosGanhos.Value);
			rtfConfirmaHab1.Text = strHab1.ToString();                  //Preenchendo o control
			#endregion
			//Criação do texto e Preenchimento das informações da Hab2
			#region Habilidade2
			StringBuilder strHab2 = new StringBuilder();                 //Variavel que armazena o texto
			strHab2.Append("Nome: " + txtHab2Nome.Text.Trim());          //Concatenação da string
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
			strHab2.Append("\n\nEnergias:");
			strHab2.Append("\nVerde(s): " + numHab2Verdes.Value);
			strHab2.Append("\nAzul(s): " + numHab2Azuls.Value);
			strHab2.Append("\nVermelho(s): " + numHab2Vermelhos.Value);
			strHab2.Append("\nPreto(s): " + numHab2Pretos.Value);
			strHab2.Append("\n\nTempo de Invulnerabilidade: " + numHab2Invulnerabilidade.Value + " turno(s)");
			strHab2.Append("\n\nEnergias ganhas:");
			strHab2.Append("\nVerde(s) Ganhos: " + numHab2VerdesGanhos.Value);
			strHab2.Append("\nAzul(s) Ganhos: " + numHab2AzulsGanhos.Value);
			strHab2.Append("\nVermelho(s) Ganhos: " + numHab2VermelhosGanhos.Value);
			strHab2.Append("\nPreto(s) Ganhos: " + numHab2PretosGanhos.Value);
			rtfConfirmaHab2.Text = strHab2.ToString();                  //Preenchendo o control
			#endregion
			//Criação do texto e Preenchimento das informações da Hab3
			#region Habilidade3
			StringBuilder strHab3 = new StringBuilder();                 //Variavel que armazena o texto
			strHab3.Append("Nome: " + txtHab3Nome.Text.Trim());          //Concatenação da string
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
			strHab3.Append("\n\nEnergias:");
			strHab3.Append("\nVerde(s): " + numHab3Verdes.Value);
			strHab3.Append("\nAzul(s): " + numHab3Azuls.Value);
			strHab3.Append("\nVermelho(s): " + numHab3Vermelhos.Value);
			strHab3.Append("\nPreto(s): " + numHab3Pretos.Value);
			strHab3.Append("\n\nTempo de Invulnerabilidade: " + numHab3Invulnerabilidade.Value + " turno(s)");
			strHab3.Append("\n\nEnergias ganhas:");
			strHab3.Append("\nVerde(s) Ganhos: " + numHab3VerdesGanhos.Value);
			strHab3.Append("\nAzul(s) Ganhos: " + numHab3AzulsGanhos.Value);
			strHab3.Append("\nVermelho(s) Ganhos: " + numHab3VermelhosGanhos.Value);
			strHab3.Append("\nPreto(s) Ganhos: " + numHab3PretosGanhos.Value);
			rtfConfirmaHab3.Text = strHab3.ToString();                  //Preenchendo o control
			#endregion
			//Criação do texto e Preenchimento das informações da Hab4
			#region Habilidade4
			StringBuilder strHab4 = new StringBuilder();                 //Variavel que armazena o texto
            strHab4.Append("Nome: " + txtHab4Nome.Text.Trim());          //Concatenação da string
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
            strHab4.Append("\n\nEnergias:");
            strHab4.Append("\nVerde(s): " + numHab4Verdes.Value);
            strHab4.Append("\nAzul(s): " + numHab4Azuls.Value);
            strHab4.Append("\nVermelho(s): " + numHab4Vermelhos.Value);
            strHab4.Append("\nPreto(s): " + numHab4Pretos.Value);
            strHab4.Append("\n\nTempo de Invulnerabilidade: " + numHab4Invulnerabilidade.Value + " turno(s)");
            strHab4.Append("\n\nEnergias ganhas:");
            strHab4.Append("\nVerde(s) Ganhos: " + numHab4VerdesGanhos.Value);
            strHab4.Append("\nAzul(s) Ganhos: " + numHab4AzulsGanhos.Value);
            strHab4.Append("\nVermelho(s) Ganhos: " + numHab4VermelhosGanhos.Value);
            strHab4.Append("\nPreto(s) Ganhos: " + numHab4PretosGanhos.Value);
            rtfConfirmaHab4.Text = strHab4.ToString();                  //Preenchendo o control
            #endregion
        }

        private void PoeInformaçõesNosForms() //Evento que popula os Controls de acordo com o Personagem que você quer editar/excluir 
        {
            //Instanciação e populamento do dtgPersonagens
            PersonagensIntermediario = new Intermediario.Personagens();
            dtgPersonagens.DataSource = PersonagensIntermediario.ListarSearch(comboNome.Text.Trim());

            //Convertendo os dados do DataGridView para Controls do form

            //Conversão de byte em MemoryStream das imagens
            byte[] ByteFoto = (byte[])dtgPersonagens[dtgPersonagens.Columns["Foto_Personagem"].Index, 0].Value;
            MemoryStream FotoPersongem = new MemoryStream(ByteFoto);

            ByteFoto = (byte[])dtgPersonagens[dtgPersonagens.Columns["Hab1_Foto"].Index, 0].Value;
            MemoryStream FotoHab1 = new MemoryStream(ByteFoto);
            ByteFoto = (byte[])dtgPersonagens[dtgPersonagens.Columns["Hab2_Foto"].Index, 0].Value;
            MemoryStream FotoHab2 = new MemoryStream(ByteFoto);
            ByteFoto = (byte[])dtgPersonagens[dtgPersonagens.Columns["Hab3_Foto"].Index, 0].Value;
            MemoryStream FotoHab3 = new MemoryStream(ByteFoto);
            ByteFoto = (byte[])dtgPersonagens[dtgPersonagens.Columns["Hab4_Foto"].Index, 0].Value;
            MemoryStream FotoHab4 = new MemoryStream(ByteFoto);

            txtID.Text = dtgPersonagens[dtgPersonagens.Columns["ID_Personagem"].Index, 0].Value.ToString();
			txtNome.Text = comboNome.Text;
            picPersonagem.Image = Image.FromStream(FotoPersongem);
            txtDescricao.Text = dtgPersonagens[dtgPersonagens.Columns["Descricao_Personagem"].Index, 0].Value.ToString();

            #region Hab1
            txtHab1Nome.Text = dtgPersonagens[dtgPersonagens.Columns["Hab1_Nome"].Index, 0].Value.ToString();
            picHab1.Image = Image.FromStream(FotoHab1);
			numHab1Dano.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_Dano"].Index, 0].Value);
			numHab1DanoPorTurno.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_DanoPorTurno"].Index, 0].Value);
			numHab1DanoPorTurno_Turnos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_DanoPorTurno_Turnos"].Index, 0].Value);
			numHab1DanoPerfurante.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_DanoPerfurante"].Index, 0].Value);
			numHab1DanoPerfurantePorTurno.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_DanoPerfurantePorTurno"].Index, 0].Value);
			numHab1DanoPerfurantePorTurno_Turnos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_DanoPerfurantePorTurno_Turnos"].Index, 0].Value);
			numHab1DanoVerdadeiro.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_DanoVerdadeiro"].Index, 0].Value);
			numHab1DanoVerdadeiroPorTurno.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_DanoVerdadeiroPorTurno"].Index, 0].Value);
			numHab1DanoVerdadeiroPorTurno_Turnos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_DanoVerdadeiroPorTurno_Turnos"].Index, 0].Value);
			numHab1Cura.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_Cura"].Index, 0].Value);
			numHab1CuraPorTurno.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_CuraPorTurno"].Index, 0].Value);
			numHab1CuraPorTurno_Turnos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_CuraPorTurno_Turnos"].Index, 0].Value);
			numHab1Armadura.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_Armadura"].Index, 0].Value);
			numHab1ArmaduraPorTurno.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_ArmaduraPorTurno"].Index, 0].Value);
			numHab1ArmaduraPorTurno_Turnos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_ArmaduraPorTurno_Turnos"].Index, 0].Value);
			txtHab1Descricao.Text = dtgPersonagens[dtgPersonagens.Columns["Hab1_Descricao"].Index, 0].Value.ToString();
            numHab1Recarga.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_Recarga"].Index, 0].Value);
            numHab1Verdes.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_Verde"].Index, 0].Value);
            numHab1Azuls.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_Azul"].Index, 0].Value);
            numHab1Vermelhos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_Vermelho"].Index, 0].Value);
            numHab1Pretos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_Preto"].Index, 0].Value);
            numHab1Invulnerabilidade.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_Invulnerabilidade"].Index, 0].Value);
            numHab1VerdesGanhos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_GanhoVerde"].Index, 0].Value);
            numHab1AzulsGanhos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_GanhoAzul"].Index, 0].Value);
            numHab1VermelhosGanhos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_GanhoVermelho"].Index, 0].Value);
            numHab1PretosGanhos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab1_GanhoPreto"].Index, 0].Value);
			#endregion

			#region Hab2
			txtHab2Nome.Text = dtgPersonagens[dtgPersonagens.Columns["Hab2_Nome"].Index, 0].Value.ToString();
			picHab2.Image = Image.FromStream(FotoHab2);
			numHab2Dano.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_Dano"].Index, 0].Value);
			numHab2DanoPorTurno.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_DanoPorTurno"].Index, 0].Value);
			numHab2DanoPorTurno_Turnos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_DanoPorTurno_Turnos"].Index, 0].Value);
			numHab2DanoPerfurante.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_DanoPerfurante"].Index, 0].Value);
			numHab2DanoPerfurantePorTurno.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_DanoPerfurantePorTurno"].Index, 0].Value);
			numHab1DanoPerfurantePorTurno_Turnos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_DanoPerfurantePorTurno_Turnos"].Index, 0].Value);
			numHab2DanoVerdadeiro.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_DanoVerdadeiro"].Index, 0].Value);
			numHab2DanoVerdadeiroPorTurno.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_DanoVerdadeiroPorTurno"].Index, 0].Value);
			numHab2DanoVerdadeiroPorTurno_Turnos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_DanoVerdadeiroPorTurno_Turnos"].Index, 0].Value);
			numHab2Cura.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_Cura"].Index, 0].Value);
			numHab2CuraPorTurno.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_CuraPorTurno"].Index, 0].Value);
			numHab1CuraPorTurno_Turnos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_CuraPorTurno_Turnos"].Index, 0].Value);
			numHab2Armadura.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_Armadura"].Index, 0].Value);
			numHab2ArmaduraPorTurno.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_ArmaduraPorTurno"].Index, 0].Value);
			numHab2ArmaduraPorTurno_Turnos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_ArmaduraPorTurno_Turnos"].Index, 0].Value);
			txtHab2Descricao.Text = dtgPersonagens[dtgPersonagens.Columns["Hab2_Descricao"].Index, 0].Value.ToString();
			numHab2Recarga.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_Recarga"].Index, 0].Value);
			numHab2Verdes.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_Verde"].Index, 0].Value);
			numHab2Azuls.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_Azul"].Index, 0].Value);
			numHab2Vermelhos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_Vermelho"].Index, 0].Value);
			numHab2Pretos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_Preto"].Index, 0].Value);
			numHab2Invulnerabilidade.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_Invulnerabilidade"].Index, 0].Value);
			numHab2VerdesGanhos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_GanhoVerde"].Index, 0].Value);
			numHab2AzulsGanhos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_GanhoAzul"].Index, 0].Value);
			numHab2VermelhosGanhos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_GanhoVermelho"].Index, 0].Value);
			numHab2PretosGanhos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab2_GanhoPreto"].Index, 0].Value);
			#endregion

			#region Hab3
			txtHab3Nome.Text = dtgPersonagens[dtgPersonagens.Columns["Hab3_Nome"].Index, 0].Value.ToString();
			picHab3.Image = Image.FromStream(FotoHab3);
			numHab3Dano.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_Dano"].Index, 0].Value);
			numHab3DanoPorTurno.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_DanoPorTurno"].Index, 0].Value);
			numHab3DanoPorTurno_Turnos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_DanoPorTurno_Turnos"].Index, 0].Value);
			numHab3DanoPerfurante.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_DanoPerfurante"].Index, 0].Value);
			numHab3DanoPerfurantePorTurno.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_DanoPerfurantePorTurno"].Index, 0].Value);
			numHab3DanoPerfurantePorTurno_Turnos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_DanoPerfurantePorTurno_Turnos"].Index, 0].Value);
			numHab3DanoVerdadeiro.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_DanoVerdadeiro"].Index, 0].Value);
			numHab3DanoVerdadeiroPorTurno.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_DanoVerdadeiroPorTurno"].Index, 0].Value);
			numHab3DanoVerdadeiroPorTurno_Turnos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_DanoVerdadeiroPorTurno_Turnos"].Index, 0].Value);
			numHab3Cura.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_Cura"].Index, 0].Value);
			numHab3CuraPorTurno.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_CuraPorTurno"].Index, 0].Value);
			numHab3CuraPorTurno_Turnos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_CuraPorTurno_Turnos"].Index, 0].Value);
			numHab3Armadura.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_Armadura"].Index, 0].Value);
			numHab3ArmaduraPorTurno.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_ArmaduraPorTurno"].Index, 0].Value);
			numHab3ArmaduraPorTurno_Turnos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_ArmaduraPorTurno_Turnos"].Index, 0].Value);
			txtHab3Descricao.Text = dtgPersonagens[dtgPersonagens.Columns["Hab3_Descricao"].Index, 0].Value.ToString();
			numHab3Recarga.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_Recarga"].Index, 0].Value);
			numHab3Verdes.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_Verde"].Index, 0].Value);
			numHab3Azuls.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_Azul"].Index, 0].Value);
			numHab3Vermelhos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_Vermelho"].Index, 0].Value);
			numHab3Pretos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_Preto"].Index, 0].Value);
			numHab3Invulnerabilidade.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_Invulnerabilidade"].Index, 0].Value);
			numHab3VerdesGanhos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_GanhoVerde"].Index, 0].Value);
			numHab3AzulsGanhos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_GanhoAzul"].Index, 0].Value);
			numHab3VermelhosGanhos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_GanhoVermelho"].Index, 0].Value);
			numHab3PretosGanhos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab3_GanhoPreto"].Index, 0].Value);
			#endregion

			#region Hab4
			txtHab4Nome.Text = dtgPersonagens[dtgPersonagens.Columns["Hab4_Nome"].Index, 0].Value.ToString();
			picHab4.Image = Image.FromStream(FotoHab4);
			numHab4Dano.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_Dano"].Index, 0].Value);
			numHab4DanoPorTurno.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_DanoPorTurno"].Index, 0].Value);
			numHab4DanoPorTurno_Turnos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_DanoPorTurno_Turnos"].Index, 0].Value);
			numHab4DanoPerfurante.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_DanoPerfurante"].Index, 0].Value);
			numHab4DanoPerfurantePorTurno.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_DanoPerfurantePorTurno"].Index, 0].Value);
			numHab4DanoPerfurantePorTurno_Turnos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_DanoPerfurantePorTurno_Turnos"].Index, 0].Value);
			numHab4DanoVerdadeiro.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_DanoVerdadeiro"].Index, 0].Value);
			numHab4DanoVerdadeiroPorTurno.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_DanoVerdadeiroPorTurno"].Index, 0].Value);
			numHab4DanoVerdadeiroPorTurno_Turnos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_DanoVerdadeiroPorTurno_Turnos"].Index, 0].Value);
			numHab4Cura.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_Cura"].Index, 0].Value);
			numHab4CuraPorTurno.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_CuraPorTurno"].Index, 0].Value);
			numHab4CuraPorTurno_Turnos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_CuraPorTurno_Turnos"].Index, 0].Value);
			numHab4Armadura.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_Armadura"].Index, 0].Value);
			numHab4ArmaduraPorTurno.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_ArmaduraPorTurno"].Index, 0].Value);
			numHab4ArmaduraPorTurno_Turnos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_ArmaduraPorTurno_Turnos"].Index, 0].Value);
			txtHab4Descricao.Text = dtgPersonagens[dtgPersonagens.Columns["Hab4_Descricao"].Index, 0].Value.ToString();
			numHab4Recarga.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_Recarga"].Index, 0].Value);
			numHab4Verdes.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_Verde"].Index, 0].Value);
			numHab4Azuls.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_Azul"].Index, 0].Value);
			numHab4Vermelhos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_Vermelho"].Index, 0].Value);
			numHab4Pretos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_Preto"].Index, 0].Value);
			numHab4Invulnerabilidade.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_Invulnerabilidade"].Index, 0].Value);
			numHab4VerdesGanhos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_GanhoVerde"].Index, 0].Value);
			numHab4AzulsGanhos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_GanhoAzul"].Index, 0].Value);
			numHab4VermelhosGanhos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_GanhoVermelho"].Index, 0].Value);
			numHab4PretosGanhos.Value = Convert.ToInt32(dtgPersonagens[dtgPersonagens.Columns["Hab4_GanhoPreto"].Index, 0].Value);
			#endregion

		}

		private bool VerificaFormularios() //Evento que verifica se os nomes e imagens do personagem estão carregados 
        {
            if ((txtNome.Text != "" || comboNome.Text != "") && txtHab1Nome.Text != "" && txtHab2Nome.Text != "" && txtHab3Nome.Text != "" && txtHab4Nome.Text != ""
                && picPersonagem.Image != null && picHab1.Image != null && picHab2.Image != null && picHab3.Image != null && picHab4.Image != null)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        private void frmControlePersonagens_FormClosing(object sender, FormClosingEventArgs e) //Evento que controla o fechamento do form (confirmação de saída) 
        {
            //Verifica se é seguro fechar o form. Se não for, pede uma confirmação ao usuário.
            if (Terminou)
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

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) //Evento que controla impede a visualização incompleta da tabPageRevisão 
        {
            try
            {       //Verifica se o tabSelecionado é a revisão
                if (tabControl1.SelectedTab == tabRevisão)
                {   //Se todos os Controls estão preenchidos, continua, senão, avisa o usuario.
                    if (VerificaFormularios())
                    {
                        foreach (Control ctl in tabRevisão.Controls) ctl.Visible = true; //Deixa cada Control da tabPage Revisão visível.

                        PreencherRevisao();         //Preenche a revisão conforme a função.
                    }
                    else
                    {
                        MessageBox.Show("Você precisa preencher pelo menos o nome e foto de cada página!", "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        tabControl1.SelectedTab = tabHab4;      //Volta para o tabPaga Hab4.
                    }
                }
                else
                {
                    foreach (Control ctl in tabRevisão.Controls) ctl.Visible = false; //Deixa cada Control da tabPage Revisão invisível.
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnExcluir_Click(object sender, EventArgs e) //Evento click do btnExcluir 
        {
            try
            {
                Operacao = "Excluir";       //Carrega na variável a operação que será feita.
                //Deixa os botões invisíveis e o comboNome visível para selecionar o Personagem a ser excluido.
                btnExcluir.Visible = false;
                btnEditar.Visible = false;
                btnCriar.Visible = false;
                txtNome.Visible = false;
                comboNome.Visible = true;
                //Instanciação
                PersonagensIntermediario = new Intermediario.Personagens();
                dtgPersonagens.DataSource = PersonagensIntermediario.Listar();

                //Popula o ComboBox com os dados do dataGridView
                for (int i = 0; i < dtgPersonagens.RowCount; i++)
                {
                    comboNome.Items.Add(dtgPersonagens[dtgPersonagens.Columns["Nome_Personagem"].Index, i].Value.ToString());
                }

                //Desativa o controle dos Controls para não edição.
                foreach (Control ctl in tabHab1.Controls) ctl.Enabled = false;
                foreach (Control ctl in tabHab2.Controls) ctl.Enabled = false;
                foreach (Control ctl in tabHab3.Controls) ctl.Enabled = false;
                foreach (Control ctl in tabHab4.Controls) ctl.Enabled = false;
                txtDescricao.Enabled = false;
                picPersonagem.Enabled = false;
                btnIrHab1.Text = "Revisar"; //Deixa o texto do btnIrHab1 para "Revisar"

                //Deixa os controls visíveis, visto que estavam invisiveis e mostrando apenas os botões de operação.
                tabControl1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void btnEditar_Click(object sender, EventArgs e) //Evento click do btnEditar   
        {
            try
            {
                Operacao = "Editar";       //Carrega na variável a operação que será feita.
                //Deixa os botões invisíveis e o comboNome visível para selecionar o Personagem a ser editado.
                btnExcluir.Visible = false;
                btnEditar.Visible = false;
                btnCriar.Visible = false;
                txtNome.Visible = false;
                comboNome.Visible = true;

                //Instanciação
                PersonagensIntermediario = new Intermediario.Personagens();
                dtgPersonagens.DataSource = PersonagensIntermediario.Listar();
				dt = PersonagensIntermediario.Listar();

                //Popula o ComboBox com os dados do dataGridView
                for (int i = 0; i < dtgPersonagens.RowCount; i++)
                {
                    comboNome.Items.Add(dtgPersonagens[dtgPersonagens.Columns["Nome_Personagem"].Index, i].Value.ToString());
                }

                //Deixa os controls visíveis, visto que estavam invisiveis e mostrando apenas os botões de operação.
                tabControl1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
        private void btnCriar_Click(object sender, EventArgs e) //Evento click do btnCriar     
        {
            try
            {
                Operacao = "Adicionar";       //Carrega na variável a operação que será feita.
                //Deixa os botões invisíveis e o comboNome visível para selecionar o Personagem a ser editado.
                btnExcluir.Visible = false;
                btnEditar.Visible = false;
                btnCriar.Visible = false;

                //Deixa os controls visíveis, visto que estavam invisiveis e mostrando apenas os botões de operação.
                tabControl1.Visible = true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnConfirmar_Click(object sender, EventArgs e) //Evento click do btnConfirmar 
        {
			try
			{
				if (Operacao != "Excluir") //Verifica se a operação é diferente de excluir
				{
					PersonagensIntermediario = new Intermediario.Personagens(); //Instanciação
					//Instanciação das variáveis de imagem.
					ImageConverter converter;
					Image img;

					//Carrega as variáveis do personagem para ir para a classe
                    #region Personagem
                    img = picPersonagem.Image; //Carrega a imagem
					byte[] PersonagemFoto;      //Cria a variável PersonagemFoto
					converter = new ImageConverter(); //Instanciação da variável
					PersonagemFoto = (byte[])converter.ConvertTo(img, typeof(byte[])); //A imagem do personagem é armazenada em bytes

					//Armazena as informações na Classe Personagem do Intermediario
					PersonagensIntermediario.PorInformacoesPersonagem(Convert.ToInt32(txtID.Text), txtNome.Text, txtDescricao.Text, PersonagemFoto);
					#endregion
					//Carrega as variáveis da Hab1 para ir para a classe
					#region Hab1
					img = picHab1.Image;
                    byte[] Hab1Foto;
                    converter = new ImageConverter();
                    Hab1Foto = (byte[])converter.ConvertTo(img, typeof(byte[]));

					PersonagensIntermediario.PorInformacoesHabilidade1(txtHab1Nome.Text.Trim(), txtHab1Descricao.Text.Trim(), Hab1Foto,
						(int)numHab1Dano.Value, (int)numHab1DanoPorTurno.Value, (int)numHab1DanoPorTurno_Turnos.Value,
						(int)numHab1DanoPerfurante.Value, (int)numHab1DanoPerfurantePorTurno.Value, (int)numHab1DanoPerfurantePorTurno_Turnos.Value,
						(int)numHab1DanoVerdadeiro.Value, (int)numHab1DanoVerdadeiroPorTurno.Value, (int)numHab1DanoVerdadeiroPorTurno_Turnos.Value,
						(int)numHab1Cura.Value, (int)numHab1CuraPorTurno.Value, (int)numHab1CuraPorTurno_Turnos.Value,
						(int)numHab1Armadura.Value, (int)numHab1ArmaduraPorTurno.Value, (int)numHab1ArmaduraPorTurno_Turnos.Value,
						(int)numHab1Recarga.Value,
						(int)numHab1Verdes.Value, (int)numHab1Azuls.Value, (int)numHab1Vermelhos.Value, (int)numHab1Pretos.Value,
						(int)numHab1Invulnerabilidade.Value,
						(int)numHab1VerdesGanhos.Value, (int)numHab1AzulsGanhos.Value, (int)numHab1VermelhosGanhos.Value, (int)numHab1PretosGanhos.Value);
					#endregion
					//Carrega as variáveis da Hab2 para ir para a classe
					#region Hab2
					img = picHab2.Image;
					byte[] Hab2Foto;
					converter = new ImageConverter();
					Hab2Foto = (byte[])converter.ConvertTo(img, typeof(byte[]));

					PersonagensIntermediario.PorInformacoesHabilidade2(txtHab2Nome.Text.Trim(), txtHab2Descricao.Text.Trim(), Hab2Foto,
						(int)numHab2Dano.Value, (int)numHab2DanoPorTurno.Value, (int)numHab2DanoPorTurno_Turnos.Value,
						(int)numHab2DanoPerfurante.Value, (int)numHab2DanoPerfurantePorTurno.Value, (int)numHab1DanoPerfurantePorTurno_Turnos.Value,
						(int)numHab2DanoVerdadeiro.Value, (int)numHab2DanoVerdadeiroPorTurno.Value, (int)numHab2DanoVerdadeiroPorTurno_Turnos.Value,
						(int)numHab2Cura.Value, (int)numHab2CuraPorTurno.Value, (int)numHab1CuraPorTurno_Turnos.Value,
						(int)numHab2Armadura.Value, (int)numHab2ArmaduraPorTurno.Value, (int)numHab2ArmaduraPorTurno_Turnos.Value,
						(int)numHab2Recarga.Value,
						(int)numHab2Verdes.Value, (int)numHab2Azuls.Value, (int)numHab2Vermelhos.Value, (int)numHab2Pretos.Value,
						(int)numHab2Invulnerabilidade.Value,
						(int)numHab2VerdesGanhos.Value, (int)numHab2AzulsGanhos.Value, (int)numHab2VermelhosGanhos.Value, (int)numHab2PretosGanhos.Value);
					#endregion
					//Carrega as variáveis da Hab3 para ir para a classe
					#region Hab3
					img = picHab3.Image;
					byte[] Hab3Foto;
					converter = new ImageConverter();
					Hab3Foto = (byte[])converter.ConvertTo(img, typeof(byte[]));

					PersonagensIntermediario.PorInformacoesHabilidade3(txtHab3Nome.Text.Trim(), txtHab3Descricao.Text.Trim(), Hab3Foto,
						(int)numHab3Dano.Value, (int)numHab3DanoPorTurno.Value, (int)numHab3DanoPorTurno_Turnos.Value,
						(int)numHab3DanoPerfurante.Value, (int)numHab3DanoPerfurantePorTurno.Value, (int)numHab3DanoPerfurantePorTurno_Turnos.Value,
						(int)numHab3DanoVerdadeiro.Value, (int)numHab3DanoVerdadeiroPorTurno.Value, (int)numHab3DanoVerdadeiroPorTurno_Turnos.Value,
						(int)numHab3Cura.Value, (int)numHab3CuraPorTurno.Value, (int)numHab3CuraPorTurno_Turnos.Value,
						(int)numHab3Armadura.Value, (int)numHab3ArmaduraPorTurno.Value, (int)numHab3ArmaduraPorTurno_Turnos.Value,
						(int)numHab3Recarga.Value,
						(int)numHab3Verdes.Value, (int)numHab3Azuls.Value, (int)numHab3Vermelhos.Value, (int)numHab3Pretos.Value,
						(int)numHab3Invulnerabilidade.Value,
						(int)numHab3VerdesGanhos.Value, (int)numHab3AzulsGanhos.Value, (int)numHab3VermelhosGanhos.Value, (int)numHab3PretosGanhos.Value);
					#endregion
					//Carrega as variáveis da Hab4 para ir para a classe
					#region Hab4
					img = picHab4.Image;
					byte[] Hab4Foto;
					converter = new ImageConverter();
					Hab4Foto = (byte[])converter.ConvertTo(img, typeof(byte[]));

					PersonagensIntermediario.PorInformacoesHabilidade4(txtHab4Nome.Text.Trim(), txtHab4Descricao.Text.Trim(), Hab4Foto,
						(int)numHab4Dano.Value, (int)numHab4DanoPorTurno.Value, (int)numHab4DanoPorTurno_Turnos.Value,
						(int)numHab4DanoPerfurante.Value, (int)numHab4DanoPerfurantePorTurno.Value, (int)numHab4DanoPerfurantePorTurno_Turnos.Value,
						(int)numHab4DanoVerdadeiro.Value, (int)numHab4DanoVerdadeiroPorTurno.Value, (int)numHab4DanoVerdadeiroPorTurno_Turnos.Value,
						(int)numHab4Cura.Value, (int)numHab4CuraPorTurno.Value, (int)numHab4CuraPorTurno_Turnos.Value,
						(int)numHab4Armadura.Value, (int)numHab4ArmaduraPorTurno.Value, (int)numHab4ArmaduraPorTurno_Turnos.Value,
						(int)numHab4Recarga.Value,
						(int)numHab4Verdes.Value, (int)numHab4Azuls.Value, (int)numHab4Vermelhos.Value, (int)numHab4Pretos.Value,
						(int)numHab4Invulnerabilidade.Value,
						(int)numHab4VerdesGanhos.Value, (int)numHab4AzulsGanhos.Value, (int)numHab4VermelhosGanhos.Value, (int)numHab4PretosGanhos.Value);
					#endregion

					if (Operacao == "Adicionar")//Verifica se a operação é para CRIAR um personagem. Após criar o personagem, avisa o usuario o sucesso.
					{
                        PersonagensIntermediario.InserirPersonagem();
                        MessageBox.Show("Personagem criado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (Operacao == "Editar") //Verifica se a operação é para EDITAR um personagem. Após editar o personagem, avisa o usuario o sucesso.
					{
                        PersonagensIntermediario.AtualizarPersonagem();
                        MessageBox.Show("Personagem editado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
					Terminou = true; //Avisa o programa que é seguro fechar o Form
					Close(); //Fecha o form, voltando ao menu principal
				}
                else
                {
                    PersonagensIntermediario = new Intermediario.Personagens(); //Instanciação
					PersonagensIntermediario.ExcluirPersonagem(Convert.ToInt32(txtID.Text));    //Exclui o personagem
					MessageBox.Show("Personagem excluido com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information); //Avisa o usuario do sucesso
					Terminou = true; //Avisa o programa que é seguro fechar o Form
					Close(); //Fecha o form, voltando ao menu principal

				}
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error); //Avisa o usuario do erro
			}
        }

        private void comboNome_SelectedIndexChanged(object sender, EventArgs e) //Evento para popular os Controls de acordo com o Personagem escolhido para editar ou excluir 
        {
            try
            {
                PoeInformaçõesNosForms(); //Popula os Controls.
				btnEditarNomeMonstro.Visible = true; //Deixa o botão visível para ser possível editar o nome do Monstro
			}
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        //Funções que fazem a inverção das respectivas imagens nas tabPages.
        private void btnInverterPicBasicos_Click(object sender, EventArgs e)
        {
            try
            {
                picPersonagem.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                picPersonagem.Refresh();

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
                picHab4.Image.RotateFlip(RotateFlipType.RotateNoneFlipX);
                picHab4.Refresh();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Erro!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

		private void btnEditarNomeMonstro_Click(object sender, EventArgs e) //Evento click do botão Editar Nome Monstro 
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

		private void button1_Click(object sender, EventArgs e)
		{
			int numlinhas = dt.Rows.Count,
				numcolunas = dt.Columns.Count;

			object[,] mano = new object[dt.Rows.Count, dt.Columns.Count];

			int linha = 0;
			foreach (DataRow dr in dt.Rows)
			{
				int coluna = 0;
				foreach (DataColumn dc in dt.Columns)
				{
					mano[linha, coluna] = dr[dc];
					coluna++;
				}
				linha++;
			}
		}

		private void nums_TurnoHab1_ValueChanged(object sender, EventArgs e)
		{
			string control = ((Control)sender).Name;

			if (control == "numHab1DanoPorTurno")
			{
				if (numHab1DanoPorTurno.Value != 0)	{ numHab1DanoPorTurno_Turnos.Enabled = true;	}
				else { numHab1DanoPorTurno_Turnos.Enabled = false; numHab1DanoPorTurno_Turnos.Value = 2; }
			}
			else if (control == "numHab1DanoPerfurantePorTurno")
			{
				if (numHab1DanoPerfurantePorTurno.Value != 0) { numHab1DanoPerfurantePorTurno_Turnos.Enabled = true;	}
				else { numHab1DanoPerfurantePorTurno_Turnos.Enabled = false; numHab1DanoPerfurantePorTurno_Turnos.Value = 2; }
			}
			else if (control == "numHab1DanoVerdadeiroPorTurno")
			{
				if (numHab1DanoVerdadeiroPorTurno.Value != 0) { numHab1DanoVerdadeiroPorTurno_Turnos.Enabled = true;	}
				else { numHab1DanoVerdadeiroPorTurno_Turnos.Enabled = false; numHab1DanoVerdadeiroPorTurno_Turnos.Value = 2; }
			}
			else if (control == "numHab1CuraPorTurno")
			{
				if (numHab1CuraPorTurno.Value != 0)	{	numHab1CuraPorTurno_Turnos.Enabled = true;	}
				else {	numHab1CuraPorTurno_Turnos.Enabled = false;	numHab1CuraPorTurno_Turnos.Value = 2;	}
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
	}
}
