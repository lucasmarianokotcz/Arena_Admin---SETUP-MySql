using System;
using System.Text;
using System.Data;
using MySql.Data.MySqlClient;

namespace AcessoDados
{
	public class Monstros
    {
		//Declaração das variaveis para interações SQL
		MySqlCommand comandoSql;
        StringBuilder sql;
        DataTable dadosTabela;

		public DataTable Listar()	//Método que retorna a tabela Monstros do DB 
		{
            try
            {
				//Inicialização das variaveis
                comandoSql = new MySqlCommand();
                sql = new StringBuilder();
                dadosTabela = new DataTable();
				//Cria uma conexao com o DB, usando a stringConexao
                using (MySqlConnection conexao = new MySqlConnection(Conexao.StringConexaoMySql))
                {
                    conexao.Open(); //Abre a conexao com o DB
					//Código SQL para listar tudo da tabela monstros
                    
                    sql.Append("SELECT * FROM Monstros");
					//Especifica quais serão os comandos e qual a conexao para o SQL
                    comandoSql.CommandText = sql.ToString();
                    comandoSql.Connection = conexao;
                    dadosTabela.Load(comandoSql.ExecuteReader()); //Carrega a DataTable com a tabela do BD
                    return dadosTabela; //retorna a tabela
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public DataTable ListarSearch(string Nome)	//Método que retorna a pesquisa da tabela Monstros do DB 
        {
            try
            {
                comandoSql = new MySqlCommand();
                sql = new StringBuilder();
                dadosTabela = new DataTable();

                using (MySqlConnection conexao = new MySqlConnection(Conexao.StringConexaoMySql))
                {
                    conexao.Open();

                    sql.Append("USE bmh6qyguc3q2m5pj55e9;");
                    sql.Append("SELECT * FROM Monstros ");
                    sql.Append("WHERE Nome_Monstro LIKE @Nome"); //Condição

                    comandoSql.Parameters.Add(new MySqlParameter("@Nome", "%"+Nome+"%")); //Parametro pra condição

                    comandoSql.CommandText = sql.ToString();
                    comandoSql.Connection = conexao;
                    dadosTabela.Load(comandoSql.ExecuteReader());
                    return dadosTabela;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void Adicionar(string Nome, string Descricao, byte[] Foto, //Método para criar um Monstro
			string Habilidade1Nome, string Habilidade1Descricao, byte[] Habilidade1Foto, int Habilidade1Dano, int Habilidade1DanoPorTurno, int Habilidade1DanoPorTurno_Turnos, int Habilidade1DanoPerfurante, int Habilidade1DanoPerfurantePorTurno, int Habilidade1DanoPerfurantePorTurno_Turnos, int Habilidade1DanoVerdadeiro, int Habilidade1DanoVerdadeiroPorTurno, int Habilidade1DanoVerdadeiroPorTurno_Turnos, int Habilidade1Cura, int Habilidade1CuraPorTurno, int Habilidade1CuraPorTurno_Turnos, int Habilidade1Armadura, int Habilidade1ArmaduraPorTurno, int Habilidade1ArmaduraPorTurno_Turnos, int Habilidade1Recarga, int Habilidade1Invulnerabilidade, int Habilidade1Disposicao,
			string Habilidade2Nome, string Habilidade2Descricao, byte[] Habilidade2Foto, int Habilidade2Dano, int Habilidade2DanoPorTurno, int Habilidade2DanoPorTurno_Turnos, int Habilidade2DanoPerfurante, int Habilidade2DanoPerfurantePorTurno, int Habilidade2DanoPerfurantePorTurno_Turnos, int Habilidade2DanoVerdadeiro, int Habilidade2DanoVerdadeiroPorTurno, int Habilidade2DanoVerdadeiroPorTurno_Turnos, int Habilidade2Cura, int Habilidade2CuraPorTurno, int Habilidade2CuraPorTurno_Turnos, int Habilidade2Armadura, int Habilidade2ArmaduraPorTurno, int Habilidade2ArmaduraPorTurno_Turnos, int Habilidade2Recarga, int Habilidade2Invulnerabilidade, int Habilidade2Disposicao,
			string Habilidade3Nome, string Habilidade3Descricao, byte[] Habilidade3Foto, int Habilidade3Dano, int Habilidade3DanoPorTurno, int Habilidade3DanoPorTurno_Turnos, int Habilidade3DanoPerfurante, int Habilidade3DanoPerfurantePorTurno, int Habilidade3DanoPerfurantePorTurno_Turnos, int Habilidade3DanoVerdadeiro, int Habilidade3DanoVerdadeiroPorTurno, int Habilidade3DanoVerdadeiroPorTurno_Turnos, int Habilidade3Cura, int Habilidade3CuraPorTurno, int Habilidade3CuraPorTurno_Turnos, int Habilidade3Armadura, int Habilidade3ArmaduraPorTurno, int Habilidade3ArmaduraPorTurno_Turnos, int Habilidade3Recarga, int Habilidade3Invulnerabilidade, int Habilidade3Disposicao,
			string Habilidade4Nome, string Habilidade4Descricao, byte[] Habilidade4Foto, int Habilidade4Dano, int Habilidade4DanoPorTurno, int Habilidade4DanoPorTurno_Turnos, int Habilidade4DanoPerfurante, int Habilidade4DanoPerfurantePorTurno, int Habilidade4DanoPerfurantePorTurno_Turnos, int Habilidade4DanoVerdadeiro, int Habilidade4DanoVerdadeiroPorTurno, int Habilidade4DanoVerdadeiroPorTurno_Turnos, int Habilidade4Cura, int Habilidade4CuraPorTurno, int Habilidade4CuraPorTurno_Turnos, int Habilidade4Armadura, int Habilidade4ArmaduraPorTurno, int Habilidade4ArmaduraPorTurno_Turnos, int Habilidade4Recarga, int Habilidade4Invulnerabilidade, int Habilidade4Disposicao)
		{
            try
            {
                comandoSql = new MySqlCommand();
                sql = new StringBuilder();

                using (MySqlConnection conexao = new MySqlConnection(Conexao.StringConexaoMySql))
                {
                    conexao.Open();
					//Código SQL
                    sql.Append("USE bmh6qyguc3q2m5pj55e9;");
                    sql.Append("INSERT INTO Monstros (Nome_Monstro, Descricao_Monstro, Foto_Monstro, ");
                    sql.Append("Hab1_Nome, Hab1_Foto, Hab1_Dano, Hab1_DanoPorTurno, Hab1_DanoPorTurno_Turnos, Hab1_DanoPerfurante, Hab1_DanoPerfurantePorTurno, Hab1_DanoPerfurantePorTurno_Turnos, Hab1_DanoVerdadeiro, Hab1_DanoVerdadeiroPorTurno, Hab1_DanoVerdadeiroPorTurno_Turnos, Hab1_Cura, Hab1_CuraPorTurno, Hab1_CuraPorTurno_Turnos, Hab1_Armadura, Hab1_ArmaduraPorTurno, Hab1_ArmaduraPorTurno_Turnos, Hab1_Descricao, Hab1_Recarga, Hab1_Invulnerabilidade, Hab1_Disposicao, ");
					sql.Append("Hab2_Nome, Hab2_Foto, Hab2_Dano, Hab2_DanoPorTurno, Hab2_DanoPorTurno_Turnos, Hab2_DanoPerfurante, Hab2_DanoPerfurantePorTurno, Hab2_DanoPerfurantePorTurno_Turnos, Hab2_DanoVerdadeiro, Hab2_DanoVerdadeiroPorTurno, Hab2_DanoVerdadeiroPorTurno_Turnos, Hab2_Cura, Hab2_CuraPorTurno, Hab2_CuraPorTurno_Turnos, Hab2_Armadura, Hab2_ArmaduraPorTurno, Hab2_ArmaduraPorTurno_Turnos, Hab2_Descricao, Hab2_Recarga, Hab2_Invulnerabilidade, Hab2_Disposicao, ");
					sql.Append("Hab3_Nome, Hab3_Foto, Hab3_Dano, Hab3_DanoPorTurno, Hab3_DanoPorTurno_Turnos, Hab3_DanoPerfurante, Hab3_DanoPerfurantePorTurno, Hab3_DanoPerfurantePorTurno_Turnos, Hab3_DanoVerdadeiro, Hab3_DanoVerdadeiroPorTurno, Hab3_DanoVerdadeiroPorTurno_Turnos, Hab3_Cura, Hab3_CuraPorTurno, Hab3_CuraPorTurno_Turnos, Hab3_Armadura, Hab3_ArmaduraPorTurno, Hab3_ArmaduraPorTurno_Turnos, Hab3_Descricao, Hab3_Recarga, Hab3_Invulnerabilidade, Hab3_Disposicao, ");
					sql.Append("Hab4_Nome, Hab4_Foto, Hab4_Dano, Hab4_DanoPorTurno, Hab4_DanoPorTurno_Turnos, Hab4_DanoPerfurante, Hab4_DanoPerfurantePorTurno, Hab4_DanoPerfurantePorTurno_Turnos, Hab4_DanoVerdadeiro, Hab4_DanoVerdadeiroPorTurno, Hab4_DanoVerdadeiroPorTurno_Turnos, Hab4_Cura, Hab4_CuraPorTurno, Hab4_CuraPorTurno_Turnos, Hab4_Armadura, Hab4_ArmaduraPorTurno, Hab4_ArmaduraPorTurno_Turnos, Hab4_Descricao, Hab4_Recarga, Hab4_Invulnerabilidade, Hab4_Disposicao) ");
					sql.Append("VALUES (@Nome, @Descricao, @Foto, ");
                    sql.Append("@Hab1_Nome, @Hab1_Foto, @Hab1_Dano, @Hab1_DanoPorTurno, @Hab1_DanoPorTurno_Turnos, @Hab1_DanoPerfurante, @Hab1_DanoPerfurantePorTurno, @Hab1_DanoPerfurantePorTurno_Turnos, @Hab1_DanoVerdadeiro, @Hab1_DanoVerdadeiroPorTurno, @Hab1_DanoVerdadeiroPorTurno_Turnos, @Hab1_Cura, @Hab1_CuraPorTurno, @Hab1_CuraPorTurno_Turnos, @Hab1_Armadura, @Hab1_ArmaduraPorTurno, @Hab1_ArmaduraPorTurno_Turnos, @Hab1_Descricao, @Hab1_Recarga, @Hab1_Invulnerabilidade, @Hab1_Disposicao, ");
					sql.Append("@Hab2_Nome, @Hab2_Foto, @Hab2_Dano, @Hab2_DanoPorTurno, @Hab2_DanoPorTurno_Turnos, @Hab2_DanoPerfurante, @Hab2_DanoPerfurantePorTurno, @Hab2_DanoPerfurantePorTurno_Turnos, @Hab2_DanoVerdadeiro, @Hab2_DanoVerdadeiroPorTurno, @Hab2_DanoVerdadeiroPorTurno_Turnos, @Hab2_Cura, @Hab2_CuraPorTurno, @Hab2_CuraPorTurno_Turnos, @Hab2_Armadura, @Hab2_ArmaduraPorTurno, @Hab2_ArmaduraPorTurno_Turnos, @Hab2_Descricao, @Hab2_Recarga, @Hab2_Invulnerabilidade, @Hab2_Disposicao, ");
					sql.Append("@Hab3_Nome, @Hab3_Foto, @Hab3_Dano, @Hab3_DanoPorTurno, @Hab3_DanoPorTurno_Turnos, @Hab3_DanoPerfurante, @Hab3_DanoPerfurantePorTurno, @Hab3_DanoPerfurantePorTurno_Turnos, @Hab3_DanoVerdadeiro, @Hab3_DanoVerdadeiroPorTurno, @Hab3_DanoVerdadeiroPorTurno_Turnos, @Hab3_Cura, @Hab3_CuraPorTurno, @Hab3_CuraPorTurno_Turnos, @Hab3_Armadura, @Hab3_ArmaduraPorTurno, @Hab3_ArmaduraPorTurno_Turnos, @Hab3_Descricao, @Hab3_Recarga, @Hab3_Invulnerabilidade, @Hab3_Disposicao, ");
					sql.Append("@Hab4_Nome, @Hab4_Foto, @Hab4_Dano, @Hab4_DanoPorTurno, @Hab4_DanoPorTurno_Turnos, @Hab4_DanoPerfurante, @Hab4_DanoPerfurantePorTurno, @Hab4_DanoPerfurantePorTurno_Turnos, @Hab4_DanoVerdadeiro, @Hab4_DanoVerdadeiroPorTurno, @Hab4_DanoVerdadeiroPorTurno_Turnos, @Hab4_Cura, @Hab4_CuraPorTurno, @Hab4_CuraPorTurno_Turnos, @Hab4_Armadura, @Hab4_ArmaduraPorTurno, @Hab4_ArmaduraPorTurno_Turnos, @Hab4_Descricao, @Hab4_Recarga, @Hab4_Invulnerabilidade, @Hab4_Disposicao)");

					//Parametros do Monstro
					comandoSql.Parameters.Add(new MySqlParameter("@Nome", Nome));
                    comandoSql.Parameters.Add(new MySqlParameter("@Descricao", Descricao));
                    comandoSql.Parameters.Add(new MySqlParameter("@Foto", Foto));
					//Parametros da Hab1
					#region Habilidade 1
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_Nome", Habilidade1Nome));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_Foto", Habilidade1Foto));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_Dano", Habilidade1Dano));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_DanoPorTurno", Habilidade1DanoPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_DanoPorTurno_Turnos", Habilidade1DanoPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_DanoPerfurante", Habilidade1DanoPerfurante));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_DanoPerfurantePorTurno", Habilidade1DanoPerfurantePorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_DanoPerfurantePorTurno_Turnos", Habilidade1DanoPerfurantePorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_DanoVerdadeiro", Habilidade1DanoVerdadeiro));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_DanoVerdadeiroPorTurno", Habilidade1DanoVerdadeiroPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_DanoVerdadeiroPorTurno_Turnos", Habilidade1DanoVerdadeiroPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_Cura", Habilidade1Cura));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_CuraPorTurno", Habilidade1CuraPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_CuraPorTurno_Turnos", Habilidade1CuraPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_Armadura", Habilidade1Armadura));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_ArmaduraPorTurno", Habilidade1ArmaduraPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_ArmaduraPorTurno_Turnos", Habilidade1ArmaduraPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_Descricao", Habilidade1Descricao));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_Recarga", Habilidade1Recarga));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_Invulnerabilidade", Habilidade1Invulnerabilidade));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_Disposicao", Habilidade1Disposicao));
					#endregion
					//Parametros da Hab2
					#region Habilidade 2
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_Nome", Habilidade2Nome));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_Foto", Habilidade2Foto));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_Dano", Habilidade2Dano));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_DanoPorTurno", Habilidade2DanoPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_DanoPorTurno_Turnos", Habilidade2DanoPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_DanoPerfurante", Habilidade2DanoPerfurante));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_DanoPerfurantePorTurno", Habilidade2DanoPerfurantePorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_DanoPerfurantePorTurno_Turnos", Habilidade2DanoPerfurantePorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_DanoVerdadeiro", Habilidade2DanoVerdadeiro));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_DanoVerdadeiroPorTurno", Habilidade2DanoVerdadeiroPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_DanoVerdadeiroPorTurno_Turnos", Habilidade2DanoVerdadeiroPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_Cura", Habilidade2Cura));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_CuraPorTurno", Habilidade2CuraPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_CuraPorTurno_Turnos", Habilidade2CuraPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_Armadura", Habilidade2Armadura));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_ArmaduraPorTurno", Habilidade2ArmaduraPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_ArmaduraPorTurno_Turnos", Habilidade2ArmaduraPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_Descricao", Habilidade2Descricao));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_Recarga", Habilidade2Recarga));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_Invulnerabilidade", Habilidade2Invulnerabilidade));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_Disposicao", Habilidade2Disposicao));
					#endregion
					//Parametros da Hab3
					#region Habilidade 3
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_Nome", Habilidade3Nome));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_Foto", Habilidade3Foto));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_Dano", Habilidade3Dano));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_DanoPorTurno", Habilidade3DanoPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_DanoPorTurno_Turnos", Habilidade3DanoPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_DanoPerfurante", Habilidade3DanoPerfurante));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_DanoPerfurantePorTurno", Habilidade3DanoPerfurantePorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_DanoPerfurantePorTurno_Turnos", Habilidade3DanoPerfurantePorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_DanoVerdadeiro", Habilidade3DanoVerdadeiro));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_DanoVerdadeiroPorTurno", Habilidade3DanoVerdadeiroPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_DanoVerdadeiroPorTurno_Turnos", Habilidade3DanoVerdadeiroPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_Cura", Habilidade3Cura));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_CuraPorTurno", Habilidade3CuraPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_CuraPorTurno_Turnos", Habilidade3CuraPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_Armadura", Habilidade3Armadura));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_ArmaduraPorTurno", Habilidade3ArmaduraPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_ArmaduraPorTurno_Turnos", Habilidade3ArmaduraPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_Descricao", Habilidade3Descricao));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_Recarga", Habilidade3Recarga));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_Invulnerabilidade", Habilidade3Invulnerabilidade));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_Disposicao", Habilidade3Disposicao));
					#endregion
					//Parametros da Hab4
					#region Habilidade 4
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_Nome", Habilidade4Nome));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_Foto", Habilidade4Foto));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_Dano", Habilidade4Dano));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_DanoPorTurno", Habilidade4DanoPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_DanoPorTurno_Turnos", Habilidade4DanoPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_DanoPerfurante", Habilidade4DanoPerfurante));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_DanoPerfurantePorTurno", Habilidade4DanoPerfurantePorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_DanoPerfurantePorTurno_Turnos", Habilidade4DanoPerfurantePorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_DanoVerdadeiro", Habilidade4DanoVerdadeiro));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_DanoVerdadeiroPorTurno", Habilidade4DanoVerdadeiroPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_DanoVerdadeiroPorTurno_Turnos", Habilidade4DanoVerdadeiroPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_Cura", Habilidade4Cura));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_CuraPorTurno", Habilidade4CuraPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_CuraPorTurno_Turnos", Habilidade4CuraPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_Armadura", Habilidade4Armadura));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_ArmaduraPorTurno", Habilidade4ArmaduraPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_ArmaduraPorTurno_Turnos", Habilidade4ArmaduraPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_Descricao", Habilidade4Descricao));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_Recarga", Habilidade4Recarga));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_Invulnerabilidade", Habilidade4Invulnerabilidade));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_Disposicao", Habilidade4Disposicao));
					#endregion

					comandoSql.CommandText = sql.ToString();
                    comandoSql.Connection = conexao;
                    comandoSql.ExecuteNonQuery();	//Executa o comando sql
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        
        public void Atualizar(int ID, string Nome, string Descricao, byte[] Foto,   //Método para editar um Monstro
			string Habilidade1Nome, string Habilidade1Descricao, byte[] Habilidade1Foto, int Habilidade1Dano, int Habilidade1DanoPorTurno, int Habilidade1DanoPorTurno_Turnos, int Habilidade1DanoPerfurante, int Habilidade1DanoPerfurantePorTurno, int Habilidade1DanoPerfurantePorTurno_Turnos, int Habilidade1DanoVerdadeiro, int Habilidade1DanoVerdadeiroPorTurno, int Habilidade1DanoVerdadeiroPorTurno_Turnos, int Habilidade1Cura, int Habilidade1CuraPorTurno, int Habilidade1CuraPorTurno_Turnos, int Habilidade1Armadura, int Habilidade1ArmaduraPorTurno, int Habilidade1ArmaduraPorTurno_Turnos, int Habilidade1Recarga, int Habilidade1Invulnerabilidade, int Habilidade1Disposicao,
			string Habilidade2Nome, string Habilidade2Descricao, byte[] Habilidade2Foto, int Habilidade2Dano, int Habilidade2DanoPorTurno, int Habilidade2DanoPorTurno_Turnos, int Habilidade2DanoPerfurante, int Habilidade2DanoPerfurantePorTurno, int Habilidade2DanoPerfurantePorTurno_Turnos, int Habilidade2DanoVerdadeiro, int Habilidade2DanoVerdadeiroPorTurno, int Habilidade2DanoVerdadeiroPorTurno_Turnos, int Habilidade2Cura, int Habilidade2CuraPorTurno, int Habilidade2CuraPorTurno_Turnos, int Habilidade2Armadura, int Habilidade2ArmaduraPorTurno, int Habilidade2ArmaduraPorTurno_Turnos, int Habilidade2Recarga, int Habilidade2Invulnerabilidade, int Habilidade2Disposicao,
			string Habilidade3Nome, string Habilidade3Descricao, byte[] Habilidade3Foto, int Habilidade3Dano, int Habilidade3DanoPorTurno, int Habilidade3DanoPorTurno_Turnos, int Habilidade3DanoPerfurante, int Habilidade3DanoPerfurantePorTurno, int Habilidade3DanoPerfurantePorTurno_Turnos, int Habilidade3DanoVerdadeiro, int Habilidade3DanoVerdadeiroPorTurno, int Habilidade3DanoVerdadeiroPorTurno_Turnos, int Habilidade3Cura, int Habilidade3CuraPorTurno, int Habilidade3CuraPorTurno_Turnos, int Habilidade3Armadura, int Habilidade3ArmaduraPorTurno, int Habilidade3ArmaduraPorTurno_Turnos, int Habilidade3Recarga, int Habilidade3Invulnerabilidade, int Habilidade3Disposicao,
			string Habilidade4Nome, string Habilidade4Descricao, byte[] Habilidade4Foto, int Habilidade4Dano, int Habilidade4DanoPorTurno, int Habilidade4DanoPorTurno_Turnos, int Habilidade4DanoPerfurante, int Habilidade4DanoPerfurantePorTurno, int Habilidade4DanoPerfurantePorTurno_Turnos, int Habilidade4DanoVerdadeiro, int Habilidade4DanoVerdadeiroPorTurno, int Habilidade4DanoVerdadeiroPorTurno_Turnos, int Habilidade4Cura, int Habilidade4CuraPorTurno, int Habilidade4CuraPorTurno_Turnos, int Habilidade4Armadura, int Habilidade4ArmaduraPorTurno, int Habilidade4ArmaduraPorTurno_Turnos, int Habilidade4Recarga, int Habilidade4Invulnerabilidade, int Habilidade4Disposicao)
		{
			try
            {
                comandoSql = new MySqlCommand();
                sql = new StringBuilder();

                using (MySqlConnection conexao = new MySqlConnection(Conexao.StringConexaoMySql))
                {
                    conexao.Open();
					//Código SQL
					sql.Append("USE bmh6qyguc3q2m5pj55e9;");
                    sql.Append("UPDATE Monstros ");
                    sql.Append("SET Nome_Monstro = @Nome, Descricao_Monstro = @Descricao, Foto_Monstro =  @Foto, ");
                    sql.Append("Hab1_Nome = @Hab1_Nome, Hab1_Foto = @Hab1_Foto, Hab1_Dano = @Hab1_Dano, Hab1_DanoPorTurno = @Hab1_DanoPorTurno, Hab1_DanoPorTurno_Turnos = @Hab1_DanoPorTurno_Turnos, Hab1_DanoPerfurante = @Hab1_DanoPerfurante, Hab1_DanoPerfurantePorTurno = @Hab1_DanoPerfurantePorTurno, Hab1_DanoPerfurantePorTurno_Turnos = @Hab1_DanoPerfurantePorTurno_Turnos, Hab1_DanoVerdadeiro = @Hab1_DanoVerdadeiro, Hab1_DanoVerdadeiroPorTurno = @Hab1_DanoVerdadeiroPorTurno, Hab1_DanoVerdadeiroPorTurno_Turnos = @Hab1_DanoVerdadeiroPorTurno_Turnos, Hab1_Cura = @Hab1_Cura, Hab1_CuraPorTurno = @Hab1_CuraPorTurno, Hab1_CuraPorTurno_Turnos = @Hab1_CuraPorTurno_Turnos, Hab1_Armadura = @Hab1_Armadura, Hab1_ArmaduraPorTurno = @Hab1_ArmaduraPorTurno, Hab1_ArmaduraPorTurno_Turnos = @Hab1_ArmaduraPorTurno_Turnos, Hab1_Descricao = @Hab1_Descricao, Hab1_Recarga = @Hab1_Recarga, Hab1_Invulnerabilidade = @Hab1_Invulnerabilidade, Hab1_Disposicao = @Hab1_Disposicao, ");
					sql.Append("Hab2_Nome = @Hab2_Nome, Hab2_Foto = @Hab2_Foto, Hab2_Dano = @Hab2_Dano, Hab2_DanoPorTurno = @Hab2_DanoPorTurno, Hab2_DanoPorTurno_Turnos = @Hab2_DanoPorTurno_Turnos, Hab2_DanoPerfurante = @Hab2_DanoPerfurante, Hab2_DanoPerfurantePorTurno = @Hab2_DanoPerfurantePorTurno, Hab2_DanoPerfurantePorTurno_Turnos = @Hab2_DanoPerfurantePorTurno_Turnos, Hab2_DanoVerdadeiro = @Hab2_DanoVerdadeiro, Hab2_DanoVerdadeiroPorTurno = @Hab2_DanoVerdadeiroPorTurno, Hab2_DanoVerdadeiroPorTurno_Turnos = @Hab2_DanoVerdadeiroPorTurno_Turnos, Hab2_Cura = @Hab2_Cura, Hab2_CuraPorTurno = @Hab2_CuraPorTurno, Hab2_CuraPorTurno_Turnos = @Hab2_CuraPorTurno_Turnos, Hab2_Armadura = @Hab2_Armadura, Hab2_ArmaduraPorTurno = @Hab2_ArmaduraPorTurno, Hab2_ArmaduraPorTurno_Turnos = @Hab2_ArmaduraPorTurno_Turnos, Hab2_Descricao = @Hab2_Descricao, Hab2_Recarga = @Hab2_Recarga, Hab2_Invulnerabilidade = @Hab2_Invulnerabilidade, Hab2_Disposicao = @Hab2_Disposicao, ");
					sql.Append("Hab3_Nome = @Hab3_Nome, Hab3_Foto = @Hab3_Foto, Hab3_Dano = @Hab3_Dano, Hab3_DanoPorTurno = @Hab3_DanoPorTurno, Hab3_DanoPorTurno_Turnos = @Hab3_DanoPorTurno_Turnos, Hab3_DanoPerfurante = @Hab3_DanoPerfurante, Hab3_DanoPerfurantePorTurno = @Hab3_DanoPerfurantePorTurno, Hab3_DanoPerfurantePorTurno_Turnos = @Hab3_DanoPerfurantePorTurno_Turnos, Hab3_DanoVerdadeiro = @Hab3_DanoVerdadeiro, Hab3_DanoVerdadeiroPorTurno = @Hab3_DanoVerdadeiroPorTurno, Hab3_DanoVerdadeiroPorTurno_Turnos = @Hab3_DanoVerdadeiroPorTurno_Turnos, Hab3_Cura = @Hab3_Cura, Hab3_CuraPorTurno = @Hab3_CuraPorTurno, Hab3_CuraPorTurno_Turnos = @Hab3_CuraPorTurno_Turnos, Hab3_Armadura = @Hab3_Armadura, Hab3_ArmaduraPorTurno = @Hab3_ArmaduraPorTurno, Hab3_ArmaduraPorTurno_Turnos = @Hab3_ArmaduraPorTurno_Turnos, Hab3_Descricao = @Hab3_Descricao, Hab3_Recarga = @Hab3_Recarga, Hab3_Invulnerabilidade = @Hab3_Invulnerabilidade, Hab3_Disposicao = @Hab3_Disposicao, ");
					sql.Append("Hab4_Nome = @Hab4_Nome, Hab4_Foto = @Hab4_Foto, Hab4_Dano = @Hab4_Dano, Hab4_DanoPorTurno = @Hab4_DanoPorTurno, Hab4_DanoPorTurno_Turnos = @Hab4_DanoPorTurno_Turnos, Hab4_DanoPerfurante = @Hab4_DanoPerfurante, Hab4_DanoPerfurantePorTurno = @Hab4_DanoPerfurantePorTurno, Hab4_DanoPerfurantePorTurno_Turnos = @Hab4_DanoPerfurantePorTurno_Turnos, Hab4_DanoVerdadeiro = @Hab4_DanoVerdadeiro, Hab4_DanoVerdadeiroPorTurno = @Hab4_DanoVerdadeiroPorTurno, Hab4_DanoVerdadeiroPorTurno_Turnos = @Hab4_DanoVerdadeiroPorTurno_Turnos, Hab4_Cura = @Hab4_Cura, Hab4_CuraPorTurno = @Hab4_CuraPorTurno, Hab4_CuraPorTurno_Turnos = @Hab4_CuraPorTurno_Turnos, Hab4_Armadura = @Hab4_Armadura, Hab4_ArmaduraPorTurno = @Hab4_ArmaduraPorTurno, Hab4_ArmaduraPorTurno_Turnos = @Hab4_ArmaduraPorTurno_Turnos, Hab4_Descricao = @Hab4_Descricao, Hab4_Recarga = @Hab4_Recarga, Hab4_Invulnerabilidade = @Hab4_Invulnerabilidade, Hab4_Disposicao = @Hab4_Disposicao ");
					sql.Append("WHERE ID_Monstro = @ID");
					//Parametros do Monstro
					comandoSql.Parameters.Add(new MySqlParameter("@ID", ID));
                    comandoSql.Parameters.Add(new MySqlParameter("@Nome", Nome));
                    comandoSql.Parameters.Add(new MySqlParameter("@Descricao", Descricao));
                    comandoSql.Parameters.Add(new MySqlParameter("@Foto", Foto));
					//Parametros da Hab1
					#region Habilidade 1
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_Nome", Habilidade1Nome));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_Foto", Habilidade1Foto));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_Dano", Habilidade1Dano));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_DanoPorTurno", Habilidade1DanoPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_DanoPorTurno_Turnos", Habilidade1DanoPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_DanoPerfurante", Habilidade1DanoPerfurante));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_DanoPerfurantePorTurno", Habilidade1DanoPerfurantePorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_DanoPerfurantePorTurno_Turnos", Habilidade1DanoPerfurantePorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_DanoVerdadeiro", Habilidade1DanoVerdadeiro));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_DanoVerdadeiroPorTurno", Habilidade1DanoVerdadeiroPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_DanoVerdadeiroPorTurno_Turnos", Habilidade1DanoVerdadeiroPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_Cura", Habilidade1Cura));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_CuraPorTurno", Habilidade1CuraPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_CuraPorTurno_Turnos", Habilidade1CuraPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_Armadura", Habilidade1Armadura));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_ArmaduraPorTurno", Habilidade1ArmaduraPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_ArmaduraPorTurno_Turnos", Habilidade1ArmaduraPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_Descricao", Habilidade1Descricao));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_Recarga", Habilidade1Recarga));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_Invulnerabilidade", Habilidade1Invulnerabilidade));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab1_Disposicao", Habilidade1Disposicao));
					#endregion
					//Parametros da Hab2
					#region Habilidade 2
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_Nome", Habilidade2Nome));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_Foto", Habilidade2Foto));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_Dano", Habilidade2Dano));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_DanoPorTurno", Habilidade2DanoPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_DanoPorTurno_Turnos", Habilidade2DanoPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_DanoPerfurante", Habilidade2DanoPerfurante));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_DanoPerfurantePorTurno", Habilidade2DanoPerfurantePorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_DanoPerfurantePorTurno_Turnos", Habilidade2DanoPerfurantePorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_DanoVerdadeiro", Habilidade2DanoVerdadeiro));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_DanoVerdadeiroPorTurno", Habilidade2DanoVerdadeiroPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_DanoVerdadeiroPorTurno_Turnos", Habilidade2DanoVerdadeiroPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_Cura", Habilidade2Cura));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_CuraPorTurno", Habilidade2CuraPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_CuraPorTurno_Turnos", Habilidade2CuraPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_Armadura", Habilidade2Armadura));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_ArmaduraPorTurno", Habilidade2ArmaduraPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_ArmaduraPorTurno_Turnos", Habilidade2ArmaduraPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_Descricao", Habilidade2Descricao));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_Recarga", Habilidade2Recarga));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_Invulnerabilidade", Habilidade2Invulnerabilidade));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab2_Disposicao", Habilidade2Disposicao));
					#endregion
					//Parametros da Hab3
					#region Habilidade 3
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_Nome", Habilidade3Nome));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_Foto", Habilidade3Foto));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_Dano", Habilidade3Dano));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_DanoPorTurno", Habilidade3DanoPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_DanoPorTurno_Turnos", Habilidade3DanoPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_DanoPerfurante", Habilidade3DanoPerfurante));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_DanoPerfurantePorTurno", Habilidade3DanoPerfurantePorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_DanoPerfurantePorTurno_Turnos", Habilidade3DanoPerfurantePorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_DanoVerdadeiro", Habilidade3DanoVerdadeiro));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_DanoVerdadeiroPorTurno", Habilidade3DanoVerdadeiroPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_DanoVerdadeiroPorTurno_Turnos", Habilidade3DanoVerdadeiroPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_Cura", Habilidade3Cura));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_CuraPorTurno", Habilidade3CuraPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_CuraPorTurno_Turnos", Habilidade3CuraPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_Armadura", Habilidade3Armadura));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_ArmaduraPorTurno", Habilidade3ArmaduraPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_ArmaduraPorTurno_Turnos", Habilidade3ArmaduraPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_Descricao", Habilidade3Descricao));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_Recarga", Habilidade3Recarga));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_Invulnerabilidade", Habilidade3Invulnerabilidade));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab3_Disposicao", Habilidade3Disposicao));
					#endregion
					//Parametros da Hab4
					#region Habilidade 4
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_Nome", Habilidade4Nome));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_Foto", Habilidade4Foto));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_Dano", Habilidade4Dano));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_DanoPorTurno", Habilidade4DanoPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_DanoPorTurno_Turnos", Habilidade4DanoPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_DanoPerfurante", Habilidade4DanoPerfurante));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_DanoPerfurantePorTurno", Habilidade4DanoPerfurantePorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_DanoPerfurantePorTurno_Turnos", Habilidade4DanoPerfurantePorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_DanoVerdadeiro", Habilidade4DanoVerdadeiro));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_DanoVerdadeiroPorTurno", Habilidade4DanoVerdadeiroPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_DanoVerdadeiroPorTurno_Turnos", Habilidade4DanoVerdadeiroPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_Cura", Habilidade4Cura));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_CuraPorTurno", Habilidade4CuraPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_CuraPorTurno_Turnos", Habilidade4CuraPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_Armadura", Habilidade4Armadura));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_ArmaduraPorTurno", Habilidade4ArmaduraPorTurno));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_ArmaduraPorTurno_Turnos", Habilidade4ArmaduraPorTurno_Turnos));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_Descricao", Habilidade4Descricao));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_Recarga", Habilidade4Recarga));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_Invulnerabilidade", Habilidade4Invulnerabilidade));
					comandoSql.Parameters.Add(new MySqlParameter("@Hab4_Disposicao", Habilidade4Disposicao));
					#endregion

					comandoSql.CommandText = sql.ToString();
                    comandoSql.Connection = conexao;
                    comandoSql.ExecuteNonQuery();   //Executa o comando sql
				}
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public void Excluir(int ID) //Método para excluir um monstro 
        {
            try
            {
                comandoSql = new MySqlCommand();
                sql = new StringBuilder();

                using (MySqlConnection conexao = new MySqlConnection(Conexao.StringConexaoMySql))
                {
                    conexao.Open();
					//Codigo SQL
                    sql.Append("USE bmh6qyguc3q2m5pj55e9;");
                    sql.Append("DELETE FROM Monstros ");
                    sql.Append("WHERE ID_Monstro = @ID");
					//Parametro
                    comandoSql.Parameters.Add(new MySqlParameter("@ID", ID));

                    comandoSql.CommandText = sql.ToString();
                    comandoSql.Connection = conexao;
                    comandoSql.ExecuteNonQuery();	//Executa o código SQL
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
