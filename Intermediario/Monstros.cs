using System;
using System.Data;

namespace Intermediario
{
	public class Monstros
    {
        AcessoDados.Monstros MonstrosAcesso;    //Instanciação classe AcessoDados
		private DataTable dadosTabela;              //Declaração de dataTable

		//Variaveis que armazenam os dados do monstro
		#region Atributos do Monstro
		int MonstroID;
        string MonstroNome, MonstroDescricao;
        byte[] MonstroFoto;

        string Hab1Nome, Hab1Descricao;
        byte[] Hab1Foto;
		int Hab1Dano, Hab1DanoPorTurno, Hab1DanoPorTurno_Turnos, Hab1DanoPerfurante, Hab1DanoPerfurantePorTurno, Hab1DanoPerfurantePorTurno_Turnos, Hab1DanoVerdadeiro, Hab1DanoVerdadeiroPorTurno, Hab1DanoVerdadeiroPorTurno_Turnos, Hab1Cura, Hab1CuraPorTurno, Hab1CuraPorTurno_Turnos, Hab1Armadura, Hab1ArmaduraPorTurno, Hab1ArmaduraPorTurno_Turnos, Hab1Recarga,
		Hab1Invulnerabilidade, Hab1Disposicao;

        string Hab2Nome, Hab2Descricao;
        byte[] Hab2Foto;
		int Hab2Dano, Hab2DanoPorTurno, Hab2DanoPorTurno_Turnos, Hab2DanoPerfurante, Hab2DanoPerfurantePorTurno, Hab2DanoPerfurantePorTurno_Turnos, Hab2DanoVerdadeiro, Hab2DanoVerdadeiroPorTurno, Hab2DanoVerdadeiroPorTurno_Turnos, Hab2Cura, Hab2CuraPorTurno, Hab2CuraPorTurno_Turnos, Hab2Armadura, Hab2ArmaduraPorTurno, Hab2ArmaduraPorTurno_Turnos, Hab2Recarga,
		Hab2Invulnerabilidade, Hab2Disposicao;

		string Hab3Nome, Hab3Descricao;
        byte[] Hab3Foto;
		int Hab3Dano, Hab3DanoPorTurno, Hab3DanoPorTurno_Turnos, Hab3DanoPerfurante, Hab3DanoPerfurantePorTurno, Hab3DanoPerfurantePorTurno_Turnos, Hab3DanoVerdadeiro, Hab3DanoVerdadeiroPorTurno, Hab3DanoVerdadeiroPorTurno_Turnos, Hab3Cura, Hab3CuraPorTurno, Hab3CuraPorTurno_Turnos, Hab3Armadura, Hab3ArmaduraPorTurno, Hab3ArmaduraPorTurno_Turnos, Hab3Recarga,
		Hab3Invulnerabilidade, Hab3Disposicao;

		string Hab4Nome, Hab4Descricao;
        byte[] Hab4Foto;
		int Hab4Dano, Hab4DanoPorTurno, Hab4DanoPorTurno_Turnos, Hab4DanoPerfurante, Hab4DanoPerfurantePorTurno, Hab4DanoPerfurantePorTurno_Turnos, Hab4DanoVerdadeiro, Hab4DanoVerdadeiroPorTurno, Hab4DanoVerdadeiroPorTurno_Turnos, Hab4Cura, Hab4CuraPorTurno, Hab4CuraPorTurno_Turnos, Hab4Armadura, Hab4ArmaduraPorTurno, Hab4ArmaduraPorTurno_Turnos, Hab4Recarga,
		Hab4Invulnerabilidade, Hab4Disposicao;

		#endregion

		public DataTable Listar()  //Função intermediária que retorna a tabela Monstros do BD 
		{
            try
            {
                MonstrosAcesso = new AcessoDados.Monstros();
                dadosTabela = MonstrosAcesso.Listar();
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarSearch(string Nome) //Função intermediária que faz a pesquisa na tabela Monstros no BD 
		{
            try
            {
                MonstrosAcesso = new AcessoDados.Monstros();
                dadosTabela = MonstrosAcesso.ListarSearch(Nome);
                return dadosTabela;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

		//Funções que populam as variaveis do Monstro
		#region Por Informações

		public void PorInformacoesMonstro(int ID, string Nome, string Descricao, byte[] Foto)
        {
            MonstroID = ID;
            MonstroNome = Nome;
            MonstroFoto = Foto;
            MonstroDescricao = Descricao;
        }

        public void PorInformacoesHabilidade1(string Habilidade1Nome, string Habilidade1Descricao, byte[] Habilidade1Foto, int Habilidade1Dano, int Habilidade1DanoPorTurnos, int Habilidade1DanoPorTurnos_Turnos, int Habilidade1DanoPerfurante, int Habilidade1DanoPerfurantePorTurno, int Habilidade1DanoPerfurantePorTurno_Turnos, int Habilidade1DanoVerdadeiro, int Habilidade1DanoVerdadeiroPorTurno, int Habilidade1DanoVerdadeiroPorTurno_Turnos, int Habilidade1Cura, int Habilidade1CuraPorTurno, int Habilidade1CuraPorTurno_Turnos, int Habilidade1Armadura, int Habilidade1ArmaduraPorTurno, int Habilidade1ArmaduraPorTurno_Turnos, int Habilidade1Recarga, int Habilidade1Invulnerabilidade, int Habilidade1Disposicao)
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

			Hab1Invulnerabilidade = Habilidade1Invulnerabilidade;
            Hab1Disposicao = Habilidade1Disposicao;
            
        }

        public void PorInformacoesHabilidade2(string Habilidade2Nome, string Habilidade2Descricao, byte[] Habilidade2Foto, int Habilidade2Dano, int Habilidade2DanoPorTurnos, int Habilidade2DanoPorTurnos_Turnos, int Habilidade2DanoPerfurante, int Habilidade2DanoPerfurantePorTurno, int Habilidade2DanoPerfurantePorTurno_Turnos, int Habilidade2DanoVerdadeiro, int Habilidade2DanoVerdadeiroPorTurno, int Habilidade2DanoVerdadeiroPorTurno_Turnos, int Habilidade2Cura, int Habilidade2CuraPorTurno, int Habilidade2CuraPorTurno_Turnos, int Habilidade2Armadura, int Habilidade2ArmaduraPorTurno, int Habilidade2ArmaduraPorTurno_Turnos, int Habilidade2Recarga, int Habilidade2Invulnerabilidade, int Habilidade2Disposicao)
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

			Hab2Invulnerabilidade = Habilidade2Invulnerabilidade;
			Hab2Disposicao = Habilidade2Disposicao;
		}

        public void PorInformacoesHabilidade3(string Habilidade3Nome, string Habilidade3Descricao, byte[] Habilidade3Foto, int Habilidade3Dano, int Habilidade3DanoPorTurnos, int Habilidade3DanoPorTurnos_Turnos, int Habilidade3DanoPerfurante, int Habilidade3DanoPerfurantePorTurno, int Habilidade3DanoPerfurantePorTurno_Turnos, int Habilidade3DanoVerdadeiro, int Habilidade3DanoVerdadeiroPorTurno, int Habilidade3DanoVerdadeiroPorTurno_Turnos, int Habilidade3Cura, int Habilidade3CuraPorTurno, int Habilidade3CuraPorTurno_Turnos, int Habilidade3Armadura, int Habilidade3ArmaduraPorTurno, int Habilidade3ArmaduraPorTurno_Turnos, int Habilidade3Recarga, int Habilidade3Invulnerabilidade, int Habilidade3Disposicao)
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

			Hab3Invulnerabilidade = Habilidade3Invulnerabilidade;
			Hab3Disposicao = Habilidade3Disposicao;
		}

        public void PorInformacoesHabilidade4(string Habilidade4Nome, string Habilidade4Descricao, byte[] Habilidade4Foto, int Habilidade4Dano, int Habilidade4DanoPorTurnos, int Habilidade4DanoPorTurnos_Turnos, int Habilidade4DanoPerfurante, int Habilidade4DanoPerfurantePorTurno, int Habilidade4DanoPerfurantePorTurno_Turnos, int Habilidade4DanoVerdadeiro, int Habilidade4DanoVerdadeiroPorTurno, int Habilidade4DanoVerdadeiroPorTurno_Turnos, int Habilidade4Cura, int Habilidade4CuraPorTurno, int Habilidade4CuraPorTurno_Turnos, int Habilidade4Armadura, int Habilidade4ArmaduraPorTurno, int Habilidade4ArmaduraPorTurno_Turnos, int Habilidade4Recarga, int Habilidade4Invulnerabilidade, int Habilidade4Disposicao)
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

			Hab4Invulnerabilidade = Habilidade4Invulnerabilidade;
			Hab4Disposicao = Habilidade4Disposicao;
		}
        #endregion

        public void InserirMonstro()        //Função intermediária de criação de Monstro	
		{
            try
            {
                MonstrosAcesso = new AcessoDados.Monstros();
				MonstrosAcesso.Adicionar(MonstroNome, MonstroDescricao, MonstroFoto,
					Hab1Nome, Hab1Descricao, Hab1Foto, Hab1Dano, Hab1DanoPorTurno, Hab1DanoPorTurno_Turnos, Hab1DanoPerfurante, Hab1DanoPerfurantePorTurno, Hab1DanoPerfurantePorTurno_Turnos, Hab1DanoVerdadeiro, Hab1DanoVerdadeiroPorTurno, Hab1DanoVerdadeiroPorTurno_Turnos, Hab1Cura, Hab1CuraPorTurno, Hab1CuraPorTurno_Turnos, Hab1Armadura, Hab1ArmaduraPorTurno, Hab1ArmaduraPorTurno_Turnos, Hab1Recarga, Hab1Invulnerabilidade, Hab1Disposicao,
					Hab2Nome, Hab2Descricao, Hab2Foto, Hab2Dano, Hab2DanoPorTurno, Hab2DanoPorTurno_Turnos, Hab2DanoPerfurante, Hab2DanoPerfurantePorTurno, Hab2DanoPerfurantePorTurno_Turnos, Hab2DanoVerdadeiro, Hab2DanoVerdadeiroPorTurno, Hab2DanoVerdadeiroPorTurno_Turnos, Hab2Cura, Hab2CuraPorTurno, Hab2CuraPorTurno_Turnos, Hab2Armadura, Hab2ArmaduraPorTurno, Hab2ArmaduraPorTurno_Turnos, Hab2Recarga, Hab2Invulnerabilidade, Hab2Disposicao,
					Hab3Nome, Hab3Descricao, Hab3Foto, Hab3Dano, Hab3DanoPorTurno, Hab3DanoPorTurno_Turnos, Hab3DanoPerfurante, Hab3DanoPerfurantePorTurno, Hab3DanoPerfurantePorTurno_Turnos, Hab3DanoVerdadeiro, Hab3DanoVerdadeiroPorTurno, Hab3DanoVerdadeiroPorTurno_Turnos, Hab3Cura, Hab3CuraPorTurno, Hab3CuraPorTurno_Turnos, Hab3Armadura, Hab3ArmaduraPorTurno, Hab3ArmaduraPorTurno_Turnos, Hab3Recarga, Hab3Invulnerabilidade, Hab3Disposicao,
					Hab4Nome, Hab4Descricao, Hab4Foto, Hab4Dano, Hab4DanoPorTurno, Hab4DanoPorTurno_Turnos, Hab4DanoPerfurante, Hab4DanoPerfurantePorTurno, Hab4DanoPerfurantePorTurno_Turnos, Hab4DanoVerdadeiro, Hab4DanoVerdadeiroPorTurno, Hab4DanoVerdadeiroPorTurno_Turnos, Hab4Cura, Hab4CuraPorTurno, Hab4CuraPorTurno_Turnos, Hab4Armadura, Hab4ArmaduraPorTurno, Hab4ArmaduraPorTurno_Turnos, Hab4Recarga, Hab4Invulnerabilidade, Hab4Disposicao);

			}
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void AtualizarMonstro()      //Função intermediária de edição de Monstro		
		{
            try
            {
                MonstrosAcesso = new AcessoDados.Monstros();
                MonstrosAcesso.Atualizar(MonstroID, MonstroNome, MonstroDescricao, MonstroFoto,
					Hab1Nome, Hab1Descricao, Hab1Foto, Hab1Dano, Hab1DanoPorTurno, Hab1DanoPorTurno_Turnos, Hab1DanoPerfurante, Hab1DanoPerfurantePorTurno, Hab1DanoPerfurantePorTurno_Turnos, Hab1DanoVerdadeiro, Hab1DanoVerdadeiroPorTurno, Hab1DanoVerdadeiroPorTurno_Turnos, Hab1Cura, Hab1CuraPorTurno, Hab1CuraPorTurno_Turnos, Hab1Armadura, Hab1ArmaduraPorTurno, Hab1ArmaduraPorTurno_Turnos, Hab1Recarga, Hab1Invulnerabilidade, Hab1Disposicao,
					Hab2Nome, Hab2Descricao, Hab2Foto, Hab2Dano, Hab2DanoPorTurno, Hab2DanoPorTurno_Turnos, Hab2DanoPerfurante, Hab2DanoPerfurantePorTurno, Hab2DanoPerfurantePorTurno_Turnos, Hab2DanoVerdadeiro, Hab2DanoVerdadeiroPorTurno, Hab2DanoVerdadeiroPorTurno_Turnos, Hab2Cura, Hab2CuraPorTurno, Hab2CuraPorTurno_Turnos, Hab2Armadura, Hab2ArmaduraPorTurno, Hab2ArmaduraPorTurno_Turnos, Hab2Recarga, Hab2Invulnerabilidade, Hab2Disposicao,
					Hab3Nome, Hab3Descricao, Hab3Foto, Hab3Dano, Hab3DanoPorTurno, Hab3DanoPorTurno_Turnos, Hab3DanoPerfurante, Hab3DanoPerfurantePorTurno, Hab3DanoPerfurantePorTurno_Turnos, Hab3DanoVerdadeiro, Hab3DanoVerdadeiroPorTurno, Hab3DanoVerdadeiroPorTurno_Turnos, Hab3Cura, Hab3CuraPorTurno, Hab3CuraPorTurno_Turnos, Hab3Armadura, Hab3ArmaduraPorTurno, Hab3ArmaduraPorTurno_Turnos, Hab3Recarga, Hab3Invulnerabilidade, Hab3Disposicao,
					Hab4Nome, Hab4Descricao, Hab4Foto, Hab4Dano, Hab4DanoPorTurno, Hab4DanoPorTurno_Turnos, Hab4DanoPerfurante, Hab4DanoPerfurantePorTurno, Hab4DanoPerfurantePorTurno_Turnos, Hab4DanoVerdadeiro, Hab4DanoVerdadeiroPorTurno, Hab4DanoVerdadeiroPorTurno_Turnos, Hab4Cura, Hab4CuraPorTurno, Hab4CuraPorTurno_Turnos, Hab4Armadura, Hab4ArmaduraPorTurno, Hab4ArmaduraPorTurno_Turnos, Hab4Recarga, Hab4Invulnerabilidade, Hab4Disposicao);
			}
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public void ExcluirMonstro(int ID)  //Função intermediária de exclusão de Monstro	
		{
            MonstrosAcesso = new AcessoDados.Monstros();
            MonstrosAcesso.Excluir(ID);
        }
    }
}
