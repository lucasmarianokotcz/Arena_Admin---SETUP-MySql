using System;
using System.Data;

namespace Intermediario
{
	public class Personagens
    {
        AcessoDados.Personagens PersonagensAcesso;	//Instanciação classe AcessoDados
        private DataTable dadosTabela;				//Declaração de dataTable

		//Variaveis que armazenam os dados do personagem
        #region Atributos do Personagem
        int PersonagemID;
        string PersonagemNome, PersonagemDescricao;
        byte[] PersonagemFoto;

        string Hab1Nome, Hab1Descricao;
        byte[] Hab1Foto;
        int Hab1Dano, Hab1DanoPorTurno, Hab1DanoPorTurno_Turnos, Hab1DanoPerfurante, Hab1DanoPerfurantePorTurno, Hab1DanoPerfurantePorTurno_Turnos, Hab1DanoVerdadeiro, Hab1DanoVerdadeiroPorTurno, Hab1DanoVerdadeiroPorTurno_Turnos, Hab1Cura, Hab1CuraPorTurno, Hab1CuraPorTurno_Turnos, Hab1Armadura, Hab1ArmaduraPorTurno, Hab1ArmaduraPorTurno_Turnos, Hab1Recarga,
        Hab1Verdes, Hab1Azuls, Hab1Vermelhos, Hab1Pretos,
        Hab1Invulnerabilidade,
        Hab1VerdesGanhos, Hab1AzulsGanhos, Hab1VermelhosGanhos, Hab1PretosGanhos;

        string Hab2Nome, Hab2Descricao;
        byte[] Hab2Foto;
		int Hab2Dano, Hab2DanoPorTurno, Hab2DanoPorTurno_Turnos, Hab2DanoPerfurante, Hab2DanoPerfurantePorTurno, Hab2DanoPerfurantePorTurno_Turnos, Hab2DanoVerdadeiro, Hab2DanoVerdadeiroPorTurno, Hab2DanoVerdadeiroPorTurno_Turnos, Hab2Cura, Hab2CuraPorTurno, Hab2CuraPorTurno_Turnos, Hab2Armadura, Hab2ArmaduraPorTurno, Hab2ArmaduraPorTurno_Turnos, Hab2Recarga,
		Hab2Verdes, Hab2Azuls, Hab2Vermelhos, Hab2Pretos,
        Hab2Invulnerabilidade,
        Hab2VerdesGanhos, Hab2AzulsGanhos, Hab2VermelhosGanhos, Hab2PretosGanhos;

        string Hab3Nome, Hab3Descricao;
        byte[] Hab3Foto;
		int Hab3Dano, Hab3DanoPorTurno, Hab3DanoPorTurno_Turnos, Hab3DanoPerfurante, Hab3DanoPerfurantePorTurno, Hab3DanoPerfurantePorTurno_Turnos, Hab3DanoVerdadeiro, Hab3DanoVerdadeiroPorTurno, Hab3DanoVerdadeiroPorTurno_Turnos, Hab3Cura, Hab3CuraPorTurno, Hab3CuraPorTurno_Turnos, Hab3Armadura, Hab3ArmaduraPorTurno, Hab3ArmaduraPorTurno_Turnos, Hab3Recarga,
		Hab3Verdes, Hab3Azuls, Hab3Vermelhos, Hab3Pretos,
        Hab3Invulnerabilidade,
        Hab3VerdesGanhos, Hab3AzulsGanhos, Hab3VermelhosGanhos, Hab3PretosGanhos;

        string Hab4Nome, Hab4Descricao;
        byte[] Hab4Foto;
		int Hab4Dano, Hab4DanoPorTurno, Hab4DanoPorTurno_Turnos, Hab4DanoPerfurante, Hab4DanoPerfurantePorTurno, Hab4DanoPerfurantePorTurno_Turnos, Hab4DanoVerdadeiro, Hab4DanoVerdadeiroPorTurno, Hab4DanoVerdadeiroPorTurno_Turnos, Hab4Cura, Hab4CuraPorTurno, Hab4CuraPorTurno_Turnos, Hab4Armadura, Hab4ArmaduraPorTurno, Hab4ArmaduraPorTurno_Turnos, Hab4Recarga,
		Hab4Verdes, Hab4Azuls, Hab4Vermelhos, Hab4Pretos,
        Hab4Invulnerabilidade,
        Hab4VerdesGanhos, Hab4AzulsGanhos, Hab4VermelhosGanhos, Hab4PretosGanhos;

#endregion

        public DataTable Listar() //Função intermediária que retorna a tabela Personagens do BD 
		{
            try
            {
                PersonagensAcesso = new AcessoDados.Personagens();
                dadosTabela = PersonagensAcesso.Listar();
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarSearch(string Nome) //Função intermediária que faz a pesquisa na tabela Personagens no BD 
		{
            try
            {
                PersonagensAcesso = new AcessoDados.Personagens();                
                return PersonagensAcesso.ListarSearch(Nome);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		//Funções que populam as variaveis do Personagem
        #region Por Informações

        public void PorInformacoesPersonagem(int ID, string Nome, string Descricao, byte[] Foto)
        {
            PersonagemID = ID;
            PersonagemNome = Nome;
            PersonagemFoto = Foto;
            PersonagemDescricao = Descricao;
        }

        public void PorInformacoesHabilidade1(string Habilidade1Nome, string Habilidade1Descricao, byte[] Habilidade1Foto, int Habilidade1Dano, int Habilidade1DanoPorTurnos, int Habilidade1DanoPorTurnos_Turnos, int Habilidade1DanoPerfurante, int Habilidade1DanoPerfurantePorTurno, int Habilidade1DanoPerfurantePorTurno_Turnos, int Habilidade1DanoVerdadeiro, int Habilidade1DanoVerdadeiroPorTurno, int Habilidade1DanoVerdadeiroPorTurno_Turnos, int Habilidade1Cura, int Habilidade1CuraPorTurno, int Habilidade1CuraPorTurno_Turnos, int Habilidade1Armadura, int Habilidade1ArmaduraPorTurno, int Habilidade1ArmaduraPorTurno_Turnos, int Habilidade1Recarga, int Habilidade1Verdes, int Habilidade1Azuls, int Habilidade1Vermelhos, int Habilidade1Pretos, int Habilidade1Invulnerabilidade, int Habilidade1VerdesGanhos, int Habilidade1AzulsGanhos, int Habilidade1VermelhosGanhos, int Habilidade1PretosGanhos)
        {
            Hab1Nome = Habilidade1Nome;
            Hab1Foto = Habilidade1Foto;
            Hab1Descricao = Habilidade1Descricao;

            Hab1Dano = Habilidade1Dano;
			Hab1DanoPorTurno = Habilidade1DanoPorTurnos;
			Hab1DanoPorTurno_Turnos = Habilidade1DanoPorTurnos_Turnos;

			Hab1DanoPerfurante = Habilidade1DanoPerfurante;
			Hab1DanoPerfurantePorTurno = Habilidade1DanoPerfurantePorTurno;
			Hab1DanoPerfurantePorTurno_Turnos = Habilidade1DanoPerfurantePorTurno_Turnos;

			Hab1DanoVerdadeiro = Habilidade1DanoVerdadeiro;
			Hab1DanoVerdadeiroPorTurno = Habilidade1DanoVerdadeiroPorTurno;
			Hab1DanoVerdadeiroPorTurno_Turnos = Habilidade1DanoVerdadeiroPorTurno_Turnos;

            Hab1Cura = Habilidade1Cura;
			Hab1CuraPorTurno = Habilidade1CuraPorTurno;
			Hab1CuraPorTurno_Turnos = Habilidade1CuraPorTurno_Turnos;

            Hab1Armadura = Habilidade1Armadura;
			Hab1ArmaduraPorTurno = Habilidade1ArmaduraPorTurno;
			Hab1ArmaduraPorTurno_Turnos = Habilidade1ArmaduraPorTurno_Turnos;

			Hab1Recarga = Habilidade1Recarga;

            Hab1Verdes = Habilidade1Verdes;
            Hab1Azuls = Habilidade1Azuls;
            Hab1Vermelhos = Habilidade1Vermelhos;
            Hab1Pretos = Habilidade1Pretos;

            Hab1Invulnerabilidade = Habilidade1Invulnerabilidade;

            Hab1VerdesGanhos = Habilidade1VerdesGanhos;
            Hab1AzulsGanhos = Habilidade1AzulsGanhos;
            Hab1VermelhosGanhos = Habilidade1VermelhosGanhos;
            Hab1PretosGanhos = Habilidade1PretosGanhos;
        }

		public void PorInformacoesHabilidade2(string Habilidade2Nome, string Habilidade2Descricao, byte[] Habilidade2Foto, int Habilidade2Dano, int Habilidade2DanoPorTurnos, int Habilidade2DanoPorTurnos_Turnos, int Habilidade2DanoPerfurante, int Habilidade2DanoPerfurantePorTurno, int Habilidade2DanoPerfurantePorTurno_Turnos, int Habilidade2DanoVerdadeiro, int Habilidade2DanoVerdadeiroPorTurno, int Habilidade2DanoVerdadeiroPorTurno_Turnos, int Habilidade2Cura, int Habilidade2CuraPorTurno, int Habilidade2CuraPorTurno_Turnos, int Habilidade2Armadura, int Habilidade2ArmaduraPorTurno, int Habilidade2ArmaduraPorTurno_Turnos, int Habilidade2Recarga, int Habilidade2Verdes, int Habilidade2Azuls, int Habilidade2Vermelhos, int Habilidade2Pretos, int Habilidade2Invulnerabilidade, int Habilidade2VerdesGanhos, int Habilidade2AzulsGanhos, int Habilidade2VermelhosGanhos, int Habilidade2PretosGanhos)
		{
			Hab2Nome = Habilidade2Nome;
			Hab2Foto = Habilidade2Foto;
			Hab2Descricao = Habilidade2Descricao;

			Hab2Dano = Habilidade2Dano;
			Hab2DanoPorTurno = Habilidade2DanoPorTurnos;
			Hab2DanoPorTurno_Turnos = Habilidade2DanoPorTurnos_Turnos;

			Hab2DanoPerfurante = Habilidade2DanoPerfurante;
			Hab2DanoPerfurantePorTurno = Habilidade2DanoPerfurantePorTurno;
			Hab2DanoPerfurantePorTurno_Turnos = Habilidade2DanoPerfurantePorTurno_Turnos;

			Hab2DanoVerdadeiro = Habilidade2DanoVerdadeiro;
			Hab2DanoVerdadeiroPorTurno = Habilidade2DanoVerdadeiroPorTurno;
			Hab2DanoVerdadeiroPorTurno_Turnos = Habilidade2DanoVerdadeiroPorTurno_Turnos;

			Hab2Cura = Habilidade2Cura;
			Hab2CuraPorTurno = Habilidade2CuraPorTurno;
			Hab2CuraPorTurno_Turnos = Habilidade2CuraPorTurno_Turnos;

			Hab2Armadura = Habilidade2Armadura;
			Hab2ArmaduraPorTurno = Habilidade2ArmaduraPorTurno;
			Hab2ArmaduraPorTurno_Turnos = Habilidade2ArmaduraPorTurno_Turnos;

			Hab2Recarga = Habilidade2Recarga;

			Hab2Verdes = Habilidade2Verdes;
			Hab2Azuls = Habilidade2Azuls;
			Hab2Vermelhos = Habilidade2Vermelhos;
			Hab2Pretos = Habilidade2Pretos;

			Hab2Invulnerabilidade = Habilidade2Invulnerabilidade;

			Hab2VerdesGanhos = Habilidade2VerdesGanhos;
			Hab2AzulsGanhos = Habilidade2AzulsGanhos;
			Hab2VermelhosGanhos = Habilidade2VermelhosGanhos;
			Hab2PretosGanhos = Habilidade2PretosGanhos;
		}

		public void PorInformacoesHabilidade3(string Habilidade3Nome, string Habilidade3Descricao, byte[] Habilidade3Foto, int Habilidade3Dano, int Habilidade3DanoPorTurnos, int Habilidade3DanoPorTurnos_Turnos, int Habilidade3DanoPerfurante, int Habilidade3DanoPerfurantePorTurno, int Habilidade3DanoPerfurantePorTurno_Turnos, int Habilidade3DanoVerdadeiro, int Habilidade3DanoVerdadeiroPorTurno, int Habilidade3DanoVerdadeiroPorTurno_Turnos, int Habilidade3Cura, int Habilidade3CuraPorTurno, int Habilidade3CuraPorTurno_Turnos, int Habilidade3Armadura, int Habilidade3ArmaduraPorTurno, int Habilidade3ArmaduraPorTurno_Turnos, int Habilidade3Recarga, int Habilidade3Verdes, int Habilidade3Azuls, int Habilidade3Vermelhos, int Habilidade3Pretos, int Habilidade3Invulnerabilidade, int Habilidade3VerdesGanhos, int Habilidade3AzulsGanhos, int Habilidade3VermelhosGanhos, int Habilidade3PretosGanhos)
		{
			Hab3Nome = Habilidade3Nome;
			Hab3Foto = Habilidade3Foto;
			Hab3Descricao = Habilidade3Descricao;

			Hab3Dano = Habilidade3Dano;
			Hab3DanoPorTurno = Habilidade3DanoPorTurnos;
			Hab3DanoPorTurno_Turnos = Habilidade3DanoPorTurnos_Turnos;

			Hab3DanoPerfurante = Habilidade3DanoPerfurante;
			Hab3DanoPerfurantePorTurno = Habilidade3DanoPerfurantePorTurno;
			Hab3DanoPerfurantePorTurno_Turnos = Habilidade3DanoPerfurantePorTurno_Turnos;

			Hab3DanoVerdadeiro = Habilidade3DanoVerdadeiro;
			Hab3DanoVerdadeiroPorTurno = Habilidade3DanoVerdadeiroPorTurno;
			Hab3DanoVerdadeiroPorTurno_Turnos = Habilidade3DanoVerdadeiroPorTurno_Turnos;

			Hab3Cura = Habilidade3Cura;
			Hab3CuraPorTurno = Habilidade3CuraPorTurno;
			Hab3CuraPorTurno_Turnos = Habilidade3CuraPorTurno_Turnos;

			Hab3Armadura = Habilidade3Armadura;
			Hab3ArmaduraPorTurno = Habilidade3ArmaduraPorTurno;
			Hab3ArmaduraPorTurno_Turnos = Habilidade3ArmaduraPorTurno_Turnos;

			Hab3Recarga = Habilidade3Recarga;

			Hab3Verdes = Habilidade3Verdes;
			Hab3Azuls = Habilidade3Azuls;
			Hab3Vermelhos = Habilidade3Vermelhos;
			Hab3Pretos = Habilidade3Pretos;

			Hab3Invulnerabilidade = Habilidade3Invulnerabilidade;

			Hab3VerdesGanhos = Habilidade3VerdesGanhos;
			Hab3AzulsGanhos = Habilidade3AzulsGanhos;
			Hab3VermelhosGanhos = Habilidade3VermelhosGanhos;
			Hab3PretosGanhos = Habilidade3PretosGanhos;
		}

		public void PorInformacoesHabilidade4(string Habilidade4Nome, string Habilidade4Descricao, byte[] Habilidade4Foto, int Habilidade4Dano, int Habilidade4DanoPorTurnos, int Habilidade4DanoPorTurnos_Turnos, int Habilidade4DanoPerfurante, int Habilidade4DanoPerfurantePorTurno, int Habilidade4DanoPerfurantePorTurno_Turnos, int Habilidade4DanoVerdadeiro, int Habilidade4DanoVerdadeiroPorTurno, int Habilidade4DanoVerdadeiroPorTurno_Turnos, int Habilidade4Cura, int Habilidade4CuraPorTurno, int Habilidade4CuraPorTurno_Turnos, int Habilidade4Armadura, int Habilidade4ArmaduraPorTurno, int Habilidade4ArmaduraPorTurno_Turnos, int Habilidade4Recarga, int Habilidade4Verdes, int Habilidade4Azuls, int Habilidade4Vermelhos, int Habilidade4Pretos, int Habilidade4Invulnerabilidade, int Habilidade4VerdesGanhos, int Habilidade4AzulsGanhos, int Habilidade4VermelhosGanhos, int Habilidade4PretosGanhos)
		{
			Hab4Nome = Habilidade4Nome;
			Hab4Foto = Habilidade4Foto;
			Hab4Descricao = Habilidade4Descricao;

			Hab4Dano = Habilidade4Dano;
			Hab4DanoPorTurno = Habilidade4DanoPorTurnos;
			Hab4DanoPorTurno_Turnos = Habilidade4DanoPorTurnos_Turnos;

			Hab4DanoPerfurante = Habilidade4DanoPerfurante;
			Hab4DanoPerfurantePorTurno = Habilidade4DanoPerfurantePorTurno;
			Hab4DanoPerfurantePorTurno_Turnos = Habilidade4DanoPerfurantePorTurno_Turnos;

			Hab4DanoVerdadeiro = Habilidade4DanoVerdadeiro;
			Hab4DanoVerdadeiroPorTurno = Habilidade4DanoVerdadeiroPorTurno;
			Hab4DanoVerdadeiroPorTurno_Turnos = Habilidade4DanoVerdadeiroPorTurno_Turnos;

			Hab4Cura = Habilidade4Cura;
			Hab4CuraPorTurno = Habilidade4CuraPorTurno;
			Hab4CuraPorTurno_Turnos = Habilidade4CuraPorTurno_Turnos;

			Hab4Armadura = Habilidade4Armadura;
			Hab4ArmaduraPorTurno = Habilidade4ArmaduraPorTurno;
			Hab4ArmaduraPorTurno_Turnos = Habilidade4ArmaduraPorTurno_Turnos;

			Hab4Recarga = Habilidade4Recarga;

			Hab4Verdes = Habilidade4Verdes;
			Hab4Azuls = Habilidade4Azuls;
			Hab4Vermelhos = Habilidade4Vermelhos;
			Hab4Pretos = Habilidade4Pretos;

			Hab4Invulnerabilidade = Habilidade4Invulnerabilidade;

			Hab4VerdesGanhos = Habilidade4VerdesGanhos;
			Hab4AzulsGanhos = Habilidade4AzulsGanhos;
			Hab4VermelhosGanhos = Habilidade4VermelhosGanhos;
			Hab4PretosGanhos = Habilidade4PretosGanhos;
		}

		#endregion

		public void InserirPersonagem()         //Função intermediária de criação de Personagem	 
		{
            try
            {
                PersonagensAcesso = new AcessoDados.Personagens();
                PersonagensAcesso.Adicionar(PersonagemNome, PersonagemDescricao, PersonagemFoto,
            Hab1Nome, Hab1Descricao, Hab1Foto, Hab1Dano, Hab1DanoPorTurno, Hab1DanoPorTurno_Turnos, Hab1DanoPerfurante, Hab1DanoPerfurantePorTurno, Hab1DanoPerfurantePorTurno_Turnos, Hab1DanoVerdadeiro, Hab1DanoVerdadeiroPorTurno, Hab1DanoVerdadeiroPorTurno_Turnos, Hab1Cura, Hab1CuraPorTurno, Hab1CuraPorTurno_Turnos, Hab1Armadura, Hab1ArmaduraPorTurno, Hab1ArmaduraPorTurno_Turnos, Hab1Recarga, Hab1Verdes, Hab1Azuls, Hab1Vermelhos, Hab1Pretos, Hab1Invulnerabilidade, Hab1VerdesGanhos, Hab1AzulsGanhos, Hab1VermelhosGanhos, Hab1PretosGanhos,
			Hab2Nome, Hab2Descricao, Hab2Foto, Hab2Dano, Hab2DanoPorTurno, Hab2DanoPorTurno_Turnos, Hab2DanoPerfurante, Hab2DanoPerfurantePorTurno, Hab2DanoPerfurantePorTurno_Turnos, Hab2DanoVerdadeiro, Hab2DanoVerdadeiroPorTurno, Hab2DanoVerdadeiroPorTurno_Turnos, Hab2Cura, Hab2CuraPorTurno, Hab2CuraPorTurno_Turnos, Hab2Armadura, Hab2ArmaduraPorTurno, Hab2ArmaduraPorTurno_Turnos, Hab2Recarga, Hab2Verdes, Hab2Azuls, Hab2Vermelhos, Hab2Pretos, Hab2Invulnerabilidade, Hab2VerdesGanhos, Hab2AzulsGanhos, Hab2VermelhosGanhos, Hab2PretosGanhos,
			Hab3Nome, Hab3Descricao, Hab3Foto, Hab3Dano, Hab3DanoPorTurno, Hab3DanoPorTurno_Turnos, Hab3DanoPerfurante, Hab3DanoPerfurantePorTurno, Hab3DanoPerfurantePorTurno_Turnos, Hab3DanoVerdadeiro, Hab3DanoVerdadeiroPorTurno, Hab3DanoVerdadeiroPorTurno_Turnos, Hab3Cura, Hab3CuraPorTurno, Hab3CuraPorTurno_Turnos, Hab3Armadura, Hab3ArmaduraPorTurno, Hab3ArmaduraPorTurno_Turnos, Hab3Recarga, Hab3Verdes, Hab3Azuls, Hab3Vermelhos, Hab3Pretos, Hab3Invulnerabilidade, Hab3VerdesGanhos, Hab3AzulsGanhos, Hab3VermelhosGanhos, Hab3PretosGanhos,
			Hab4Nome, Hab4Descricao, Hab4Foto, Hab4Dano, Hab4DanoPorTurno, Hab4DanoPorTurno_Turnos, Hab4DanoPerfurante, Hab4DanoPerfurantePorTurno, Hab4DanoPerfurantePorTurno_Turnos, Hab4DanoVerdadeiro, Hab4DanoVerdadeiroPorTurno, Hab4DanoVerdadeiroPorTurno_Turnos, Hab4Cura, Hab4CuraPorTurno, Hab4CuraPorTurno_Turnos, Hab4Armadura, Hab4ArmaduraPorTurno, Hab4ArmaduraPorTurno_Turnos, Hab4Recarga, Hab4Verdes, Hab4Azuls, Hab4Vermelhos, Hab4Pretos, Hab4Invulnerabilidade, Hab4VerdesGanhos, Hab4AzulsGanhos, Hab4VermelhosGanhos, Hab4PretosGanhos);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void AtualizarPersonagem()       //Função intermediária de edição de Personagem	 
		{
            try
            {
                PersonagensAcesso = new AcessoDados.Personagens();
                PersonagensAcesso.Atualizar(PersonagemID, PersonagemNome, PersonagemDescricao, PersonagemFoto,
			Hab1Nome, Hab1Descricao, Hab1Foto, Hab1Dano, Hab1DanoPorTurno, Hab1DanoPorTurno_Turnos, Hab1DanoPerfurante, Hab1DanoPerfurantePorTurno, Hab1DanoPerfurantePorTurno_Turnos, Hab1DanoVerdadeiro, Hab1DanoVerdadeiroPorTurno, Hab1DanoVerdadeiroPorTurno_Turnos, Hab1Cura, Hab1CuraPorTurno, Hab1CuraPorTurno_Turnos, Hab1Armadura, Hab1ArmaduraPorTurno, Hab1ArmaduraPorTurno_Turnos, Hab1Recarga, Hab1Verdes, Hab1Azuls, Hab1Vermelhos, Hab1Pretos, Hab1Invulnerabilidade, Hab1VerdesGanhos, Hab1AzulsGanhos, Hab1VermelhosGanhos, Hab1PretosGanhos,
			Hab2Nome, Hab2Descricao, Hab2Foto, Hab2Dano, Hab2DanoPorTurno, Hab2DanoPorTurno_Turnos, Hab2DanoPerfurante, Hab2DanoPerfurantePorTurno, Hab2DanoPerfurantePorTurno_Turnos, Hab2DanoVerdadeiro, Hab2DanoVerdadeiroPorTurno, Hab2DanoVerdadeiroPorTurno_Turnos, Hab2Cura, Hab2CuraPorTurno, Hab2CuraPorTurno_Turnos, Hab2Armadura, Hab2ArmaduraPorTurno, Hab2ArmaduraPorTurno_Turnos, Hab2Recarga, Hab2Verdes, Hab2Azuls, Hab2Vermelhos, Hab2Pretos, Hab2Invulnerabilidade, Hab2VerdesGanhos, Hab2AzulsGanhos, Hab2VermelhosGanhos, Hab2PretosGanhos,
			Hab3Nome, Hab3Descricao, Hab3Foto, Hab3Dano, Hab3DanoPorTurno, Hab3DanoPorTurno_Turnos, Hab3DanoPerfurante, Hab3DanoPerfurantePorTurno, Hab3DanoPerfurantePorTurno_Turnos, Hab3DanoVerdadeiro, Hab3DanoVerdadeiroPorTurno, Hab3DanoVerdadeiroPorTurno_Turnos, Hab3Cura, Hab3CuraPorTurno, Hab3CuraPorTurno_Turnos, Hab3Armadura, Hab3ArmaduraPorTurno, Hab3ArmaduraPorTurno_Turnos, Hab3Recarga, Hab3Verdes, Hab3Azuls, Hab3Vermelhos, Hab3Pretos, Hab3Invulnerabilidade, Hab3VerdesGanhos, Hab3AzulsGanhos, Hab3VermelhosGanhos, Hab3PretosGanhos,
			Hab4Nome, Hab4Descricao, Hab4Foto, Hab4Dano, Hab4DanoPorTurno, Hab4DanoPorTurno_Turnos, Hab4DanoPerfurante, Hab4DanoPerfurantePorTurno, Hab4DanoPerfurantePorTurno_Turnos, Hab4DanoVerdadeiro, Hab4DanoVerdadeiroPorTurno, Hab4DanoVerdadeiroPorTurno_Turnos, Hab4Cura, Hab4CuraPorTurno, Hab4CuraPorTurno_Turnos, Hab4Armadura, Hab4ArmaduraPorTurno, Hab4ArmaduraPorTurno_Turnos, Hab4Recarga, Hab4Verdes, Hab4Azuls, Hab4Vermelhos, Hab4Pretos, Hab4Invulnerabilidade, Hab4VerdesGanhos, Hab4AzulsGanhos, Hab4VermelhosGanhos, Hab4PretosGanhos);
			}
			catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public void ExcluirPersonagem(int ID)   //Função intermediária de exclusão de Personagem 
		{
            PersonagensAcesso = new AcessoDados.Personagens();
            PersonagensAcesso.Excluir(ID);
        }
    }
}
