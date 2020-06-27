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
            bool aux = false;


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
