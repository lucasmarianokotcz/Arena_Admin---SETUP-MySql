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
        private readonly string monstro = MonstroRegras.NomeTabela;
        private readonly string m = MonstroRegras.AliasTabela;
        private readonly int numeroHabilidades = MonstroRegras.NumeroHabilidades;

        #endregion

        #region Methods

        public bool Insert(Monstro obj)
        {
            bool aux;
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            #region Query
            sql.Append($" INSERT INTO {monstro} VALUES ");
            sql.Append(" (NULL, ");
            sql.Append($" @nome_{monstro}, ");
            sql.Append($" @descricao_{monstro}, ");
            sql.Append($" @foto_{monstro}) ");
            #endregion

            #region Parameters            
            parameters[$"@nome_{monstro}"] = obj.Nome;
            parameters[$"@descricao_{monstro}"] = obj.Descricao;
            parameters[$"@foto_{monstro}"] = obj.Foto;
            #endregion

            obj.Id = acesso.Insert_(sql.ToString(), parameters);
            aux = obj.Id > 0;

            for (int i = 1; i <= numeroHabilidades; i++)
            {
                if (!aux)
                    return aux;

                #region Query
                sql.Clear();
                sql.Append($" INSERT INTO {monstro}_hab{i} VALUES ");
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
                parameters[$"@hab{i}_id_{monstro}"] = obj.Id;
                #endregion

                aux = acesso.Insert(sql.ToString(), parameters);
            }

            return aux;
        }

        public bool Update(Monstro obj)
        {
            bool aux;
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            #region Query
            sql.Append($" UPDATE {monstro} SET ");
            sql.Append($" nome_{monstro} = @nome_{monstro}, ");
            sql.Append($" descricao_{monstro} = @descricao_{monstro}, ");
            sql.Append($" foto_{monstro} = @foto_{monstro} ");
            sql.Append($" WHERE id_{monstro} = @id_{monstro} ");
            #endregion

            #region Parameters            
            parameters[$"@nome_{monstro}"] = obj.Nome;
            parameters[$"@descricao_{monstro}"] = obj.Descricao;
            parameters[$"@foto_{monstro}"] = obj.Foto;
            parameters[$"@id_{monstro}"] = obj.Id;
            #endregion

            aux = acesso.Update(sql.ToString(), parameters);

            for (int i = 1; i <= numeroHabilidades; i++)
            {
                if (!aux)
                    return aux;

                #region Query
                sql.Clear();
                sql.Append($" UPDATE {monstro}_hab{i} SET ");
                sql.Append($" hab{i}_nome = @hab{i}_nome, ");
                sql.Append($" hab{i}_foto = @hab{i}_foto, ");
                sql.Append($" hab{i}_dano = @hab{i}_dano, ");
                sql.Append($" hab{i}_dano_por_turno = @hab{i}_dano_por_turno, ");
                sql.Append($" hab{i}_dano_por_turno_turnos = @hab{i}_dano_por_turno_turnos, ");
                sql.Append($" hab{i}_dano_perfurante = @hab{i}_dano_perfurante, ");
                sql.Append($" hab{i}_dano_perfurante_por_turno = @hab{i}_dano_perfurante_por_turno, ");
                sql.Append($" hab{i}_dano_perfurante_por_turno_turnos = @hab{i}_dano_perfurante_por_turno_turnos, ");
                sql.Append($" hab{i}_dano_verdadeiro = @hab{i}_dano_verdadeiro, ");
                sql.Append($" hab{i}_dano_verdadeiro_por_turno = @hab{i}_dano_verdadeiro_por_turno, ");
                sql.Append($" hab{i}_dano_verdadeiro_por_turno_turnos = @hab{i}_dano_verdadeiro_por_turno_turnos, ");
                sql.Append($" hab{i}_cura = @hab{i}_cura, ");
                sql.Append($" hab{i}_cura_por_turno = @hab{i}_cura_por_turno, ");
                sql.Append($" hab{i}_cura_por_turno_turnos = @hab{i}_cura_por_turno_turnos, ");
                sql.Append($" hab{i}_armadura = @hab{i}_armadura, ");
                sql.Append($" hab{i}_armadura_por_turno = @hab{i}_armadura_por_turno, ");
                sql.Append($" hab{i}_armadura_por_turno_turnos = @hab{i}_armadura_por_turno_turnos, ");
                sql.Append($" hab{i}_descricao = @hab{i}_descricao, ");
                sql.Append($" hab{i}_recarga = @hab{i}_recarga, ");
                sql.Append($" hab{i}_invulnerabilidade = @hab{i}_invulnerabilidade, ");
                sql.Append($" hab{i}_disposicao = @hab{i}_disposicao ");
                sql.Append($" WHERE id_hab{i} = @id_hab{i} ");
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
                parameters[$"@id_hab{i}"] = obj.Habilidades[i - 1].Id;
                #endregion

                aux = acesso.Update(sql.ToString(), parameters);
            };

            return aux;
        }

        public bool Delete(int id)
        {
            bool aux = true;
            Dictionary<string, object> parameters = new Dictionary<string, object>();

            for (int i = 1; i <= numeroHabilidades; i++)
            {
                if (!aux)
                    return aux;

                #region Query
                sql.Clear();
                sql.Append($" DELETE FROM {monstro}_hab{i} ");
                sql.Append($" WHERE hab{i}_id_{monstro} = @hab{i}_id_{monstro} ");
                #endregion

                #region Parameters
                parameters.Clear();
                parameters[$"@hab{i}_id_{monstro}"] = id;
                #endregion

                aux = acesso.Delete(sql.ToString(), parameters);
            };

            #region Query
            sql.Clear();
            sql.Append($" DELETE FROM {monstro} ");
            sql.Append($" WHERE id_{monstro} = @id_{monstro} ");
            #endregion

            #region Parameters       
            parameters.Clear();
            parameters[$"@id_{monstro}"] = id;
            #endregion

            aux = acesso.Delete(sql.ToString(), parameters);

            return aux;
        }

        public List<Monstro> Select()
        {
            var lst = new List<Monstro>();

            sql.Append($" SELECT * FROM {monstro} {m} ");
            for (int i = 1; i <= numeroHabilidades; i++)
            {
                sql.Append($" INNER JOIN {monstro}_hab{i} h{i} ON h{i}.hab{i}_id_{monstro} = {m}.id_{monstro} ");
            }

            DataTable dt = acesso.Select(sql.ToString());

            if (dt != null && dt.Rows.Count > 0)
            {
                foreach (DataRow r in dt.Rows)
                {
                    var obj = new Monstro()
                    {
                        Id = Convert.ToInt32(r[$"id_{monstro}"]),
                        Nome = Convert.ToString(r[$"nome_{monstro}"]),
                        Descricao = r[$"descricao_{monstro}"] is DBNull ? string.Empty : Convert.ToString(r[$"descricao_{monstro}"]),
                        Foto = (byte[])r[$"foto_{monstro}"]
                    };
                    for (int i = 1; i <= numeroHabilidades; i++)
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
