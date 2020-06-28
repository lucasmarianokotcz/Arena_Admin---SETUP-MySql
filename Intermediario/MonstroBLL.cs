using AcessoDados;
using Intermediario.Interfaces;
using Model;
using Model.Atributos;
using Model.Regras.Classes;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Intermediario
{
    public class MonstroBLL : IRepository<Monstro>
    {
        #region Atributes

        private readonly Acesso acesso = new Acesso();
        private readonly StringBuilder sql = new StringBuilder();

        #endregion

        #region Methods

        public bool Insert(Monstro obj)
        {
            bool aux;
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            #region Query
            sql.Append($" INSERT INTO {MonstroRegras.NomeTabela} VALUES ");
            sql.Append(" (NULL, ");
            sql.Append($" @nome_{MonstroRegras.NomeTabela}, ");
            sql.Append($" @descricao_{MonstroRegras.NomeTabela}, ");
            sql.Append($" @foto_{MonstroRegras.NomeTabela}) ");
            #endregion

            #region Parameters            
            parameters[$"@nome_{MonstroRegras.NomeTabela}"] = obj.Nome;
            parameters[$"@descricao_{MonstroRegras.NomeTabela}"] = obj.Descricao;
            parameters[$"@foto_{MonstroRegras.NomeTabela}"] = obj.Foto;
            #endregion

            obj.Id = acesso.Insert_(sql.ToString(), parameters);
            aux = obj.Id > 0;

            for (int i = 1; i <= MonstroRegras.NumeroHabilidades; i++)
            {
                if (!aux)
                    return aux;

                #region Query
                sql.Clear();
                sql.Append($" INSERT INTO {MonstroRegras.NomeTabela}_hab{i} VALUES ");
                sql.Append(" (NULL, ");
                sql.Append($" @hab{i}_nome, ");
                sql.Append($" @hab{i}_foto, ");
                sql.Append($" @hab{i}_dano, ");
                sql.Append($" @hab{i}_dano_por_turno, ");
                sql.Append($" @hab{i}_dano_por_turno_turnos, ");
                sql.Append($" @hab{i}_dano_perfurante, ");
                sql.Append($" @hab{i}_dano_perfurante_por_turno, ");
                sql.Append($" @hab{i}_dano_perfurante_por_turno_turnos, ");
                sql.Append($" @hab{i}_dano_verdadeiro, ");
                sql.Append($" @hab{i}_dano_verdadeiro_por_turno, ");
                sql.Append($" @hab{i}_dano_verdadeiro_por_turno_turnos, ");
                sql.Append($" @hab{i}_cura, ");
                sql.Append($" @hab{i}_cura_por_turno, ");
                sql.Append($" @hab{i}_cura_por_turno_turnos, ");
                sql.Append($" @hab{i}_armadura, ");
                sql.Append($" @hab{i}_armadura_por_turno, ");
                sql.Append($" @hab{i}_armadura_por_turno_turnos, ");
                sql.Append($" @hab{i}_descricao, ");
                sql.Append($" @hab{i}_recarga, ");
                sql.Append($" @hab{i}_invulnerabilidade, ");
                sql.Append($" @hab{i}_disposicao, ");
                sql.Append($" @hab{i}_id_monstro) ");
                #endregion

                #region Parameters
                parameters.Clear();
                parameters[$"@hab{i}_nome"] = obj.Habilidades[i - 1].Nome;
                parameters[$"@hab{i}_foto"] = obj.Habilidades[i - 1].Foto;
                parameters[$"@hab{i}_dano"] = obj.Habilidades[i - 1].Dano.DanoHabilidade;
                parameters[$"@hab{i}_dano_por_turno"] = obj.Habilidades[i - 1].DanoPorTurno.DanoHabilidade;
                parameters[$"@hab{i}_dano_por_turno_turnos"] = obj.Habilidades[i - 1].DanoPorTurno.Turnos;
                parameters[$"@hab{i}_dano_perfurante"] = obj.Habilidades[i - 1].DanoPerfurante.DanoHabilidade;
                parameters[$"@hab{i}_dano_perfurante_por_turno"] = obj.Habilidades[i - 1].DanoPerfurantePorTurno.DanoHabilidade;
                parameters[$"@hab{i}_dano_perfurante_por_turno_turnos"] = obj.Habilidades[i - 1].DanoPerfurantePorTurno.Turnos;
                parameters[$"@hab{i}_dano_verdadeiro"] = obj.Habilidades[i - 1].DanoVerdadeiro.DanoHabilidade;
                parameters[$"@hab{i}_dano_verdadeiro_por_turno"] = obj.Habilidades[i - 1].DanoVerdadeiroPorTurno.DanoHabilidade;
                parameters[$"@hab{i}_dano_verdadeiro_por_turno_turnos"] = obj.Habilidades[i - 1].DanoVerdadeiroPorTurno.Turnos;
                parameters[$"@hab{i}_cura"] = obj.Habilidades[i - 1].Cura.CuraHabilidade;
                parameters[$"@hab{i}_cura_por_turno"] = obj.Habilidades[i - 1].CuraPorTurno.CuraHabilidade;
                parameters[$"@hab{i}_cura_por_turno_turnos"] = obj.Habilidades[i - 1].CuraPorTurno.Turnos;
                parameters[$"@hab{i}_armadura"] = obj.Habilidades[i - 1].Armadura.ArmaduraHabilidade;
                parameters[$"@hab{i}_armadura_por_turno"] = obj.Habilidades[i - 1].ArmaduraPorTurno.ArmaduraHabilidade;
                parameters[$"@hab{i}_armadura_por_turno_turnos"] = obj.Habilidades[i - 1].ArmaduraPorTurno.Turnos;
                parameters[$"@hab{i}_descricao"] = obj.Habilidades[i - 1].Descricao;
                parameters[$"@hab{i}_recarga"] = obj.Habilidades[i - 1].Recarga;
                parameters[$"@hab{i}_invulnerabilidade"] = obj.Habilidades[i - 1].Invulnerabilidade;
                parameters[$"@hab{i}_disposicao"] = obj.Habilidades[i - 1].Disposicao;
                parameters[$"@hab{i}_id_monstro"] = obj.Id;
                #endregion

                aux = acesso.Insert(sql.ToString(), parameters);
            }

            return aux;
        }

        public bool Update(Monstro obj)
        {
            // TODO: Update Monstro
            return false;
        }

        public bool Delete(int id)
        {
            // TODO: Delete Monstro
            return false;
        }

        public List<Monstro> Select()
        {
            var lst = new List<Monstro>();

            sql.Append($" SELECT * FROM {MonstroRegras.NomeTabela} {MonstroRegras.AliasTabela} ");
            for (int i = 1; i <= MonstroRegras.NumeroHabilidades; i++)
            {
                sql.Append($" INNER JOIN {MonstroRegras.NomeTabela}_hab{i} h{i} ON h{i}.hab{i}_id_{MonstroRegras.NomeTabela} = {MonstroRegras.AliasTabela}.id_{MonstroRegras.NomeTabela} ");
            }

            DataTable dt = acesso.Select(sql.ToString());

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    var obj = new Monstro()
                    {
                        Id = Convert.ToInt32(r[$"id_{MonstroRegras.NomeTabela}"]),
                        Nome = Convert.ToString(r[$"nome_{MonstroRegras.NomeTabela}"]),
                        Descricao = r[$"descricao_{MonstroRegras.NomeTabela}"] is DBNull ? string.Empty : Convert.ToString(r[$"descricao_{MonstroRegras.NomeTabela}"]),
                        Foto = (byte[])r[$"foto_{MonstroRegras.NomeTabela}"]
                    };
                    for (int i = 1; i <= MonstroRegras.NumeroHabilidades; i++)
                    {
                        obj.Habilidades.Add(new Habilidade()
                        {
                            Id = Convert.ToInt32(r[$"id_hab{i}"]),
                            Nome = Convert.ToString(r[$"hab{i}_nome"]),
                            Foto = (byte[])r[$"hab{i}_foto"],
                            Dano = new Dano() { DanoHabilidade = Convert.ToInt32(r[$"hab{i}_dano"]) },
                            DanoPorTurno = new DanoPorTurno() { DanoHabilidade = Convert.ToInt32(r[$"hab{i}_dano_por_turno"]), Turnos = Convert.ToInt32(r[$"hab{i}_dano_por_turno_turnos"]) },
                            DanoPerfurante = new DanoPerfurante() { DanoHabilidade = Convert.ToInt32(r[$"hab{i}_dano_perfurante"]) },
                            DanoPerfurantePorTurno = new DanoPerfurantePorTurno() { DanoHabilidade = Convert.ToInt32(r[$"hab{i}_dano_perfurante_por_turno"]), Turnos = Convert.ToInt32(r[$"hab{i}_dano_perfurante_por_turno_turnos"]) },
                            DanoVerdadeiro = new DanoVerdadeiro() { DanoHabilidade = Convert.ToInt32(r[$"hab{i}_dano_verdadeiro"]) },
                            DanoVerdadeiroPorTurno = new DanoVerdadeiroPorTurno() { DanoHabilidade = Convert.ToInt32(r[$"hab{i}_dano_verdadeiro_por_turno"]), Turnos = Convert.ToInt32(r[$"hab{i}_dano_verdadeiro_por_turno_turnos"]) },
                            Cura = new Cura() { CuraHabilidade = Convert.ToInt32(r[$"hab{i}_cura"]) },
                            CuraPorTurno = new CuraPorTurno() { CuraHabilidade = Convert.ToInt32(r[$"hab{i}_cura_por_turno"]), Turnos = Convert.ToInt32(r[$"hab{i}_cura_por_turno_turnos"]) },
                            Armadura = new Armadura() { ArmaduraHabilidade = Convert.ToInt32(r[$"hab{i}_armadura"]) },
                            ArmaduraPorTurno = new ArmaduraPorTurno() { ArmaduraHabilidade = Convert.ToInt32(r[$"hab{i}_armadura_por_turno"]), Turnos = Convert.ToInt32(r[$"hab{i}_armadura_por_turno_turnos"]) },
                            Descricao = r[$"hab{i}_descricao"] is DBNull ? string.Empty : Convert.ToString(r[$"hab{i}_descricao"]),
                            Recarga = Convert.ToInt32(r[$"hab{i}_recarga"]),
                            Invulnerabilidade = Convert.ToInt32(r[$"hab{i}_invulnerabilidade"]),
                            Disposicao = Convert.ToInt32(r[$"hab{i}_disposicao"])
                        });
                    }
                    lst.Add(obj);
                }
            }

            return lst;
        }

        #endregion
    }
}
