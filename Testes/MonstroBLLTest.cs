using Intermediario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
using Model.Atributos;
using Model.Regras.Classes;
using System;
using System.Collections.Generic;

namespace Testes
{
    [TestClass]
    public class MonstroBLLTest
    {
        [TestMethod]
        public void ReturnListMonstros()
        {
            List<Monstro> lstMonstros = new MonstroBLL().Select();
            Assert.IsTrue(lstMonstros != null, "Deve acessar o banco e retornar uma lista de monstros (mesmo que vazia).");
        }

        [TestMethod]
        public void ReturnOneMonstro()
        {
            List<Monstro> lstMonstros = new MonstroBLL().Select();
            Assert.IsTrue(lstMonstros.Count > 0, "Deve retornar ao menos 1 registro na tabela monstros.");
        }

        [TestMethod]
        public void InsereMonstro()
        {
            var random = new Random();

            // cria objeto monstro
            Monstro obj = new Monstro()
            {
                Nome = "Teste " + random.Next(1, 100),
                Descricao = "Teste descrição " + random.Next(1, 100),
                Foto = new byte[0],
            };

            // cria habilidades do monstro
            List<Habilidade> lst = new List<Habilidade>();
            for (int i = 1; i <= MonstroRegras.NumeroHabilidades; i++)
            {
                lst.Add(new Habilidade()
                {
                    Nome = "Teste hab " + i,
                    Descricao = "Teste hab descrição " + i,
                    Armadura = new Armadura() { ArmaduraHabilidade = i },
                    ArmaduraPorTurno = new ArmaduraPorTurno() { ArmaduraHabilidade = i, Turnos = i },
                    Cura = new Cura() { CuraHabilidade = i },
                    CuraPorTurno = new CuraPorTurno() { CuraHabilidade = i, Turnos = i },
                    Dano = new Dano() { DanoHabilidade = i },
                    DanoPerfurante = new DanoPerfurante() { DanoHabilidade = i },
                    DanoPerfurantePorTurno = new DanoPerfurantePorTurno() { DanoHabilidade = i, Turnos = i },
                    DanoPorTurno = new DanoPorTurno() { DanoHabilidade = i, Turnos = i },
                    DanoVerdadeiro = new DanoVerdadeiro() { DanoHabilidade = i },
                    DanoVerdadeiroPorTurno = new DanoVerdadeiroPorTurno() { DanoHabilidade = i, Turnos = i },
                    Disposicao = i,
                    Foto = new byte[0],
                    Invulnerabilidade = i,
                    Recarga = i,
                });
            }

            obj.Habilidades = lst;

            // tenta persistir monstro
            bool aux = new MonstroBLL().Insert(obj);
            Assert.IsTrue(aux, "Deve inserir um monstro no banco de dados em todas as tabelas.");
        }

        [TestMethod]
        public void AlteraMonstro()
        {
            var random = new Random();

            // cria objeto monstro
            Monstro obj = new Monstro()
            {
                Id = 10,
                Nome = "Teste " + random.Next(1, 100),
                Descricao = "Teste descrição " + random.Next(1, 100),
                Foto = new byte[0],
            };

            // cria habilidades do monstro
            List<Habilidade> lst = new List<Habilidade>();
            for (int i = 1; i <= MonstroRegras.NumeroHabilidades; i++)
            {
                lst.Add(new Habilidade()
                {
                    Id = 6,
                    Nome = "Teste hab " + 5,
                    Descricao = "Teste hab descrição " + 5,
                    Armadura = new Armadura() { ArmaduraHabilidade = i },
                    ArmaduraPorTurno = new ArmaduraPorTurno() { ArmaduraHabilidade = i, Turnos = i },
                    Cura = new Cura() { CuraHabilidade = i },
                    CuraPorTurno = new CuraPorTurno() { CuraHabilidade = i, Turnos = i },
                    Dano = new Dano() { DanoHabilidade = i },
                    DanoPerfurante = new DanoPerfurante() { DanoHabilidade = i },
                    DanoPerfurantePorTurno = new DanoPerfurantePorTurno() { DanoHabilidade = i, Turnos = i },
                    DanoPorTurno = new DanoPorTurno() { DanoHabilidade = i, Turnos = i },
                    DanoVerdadeiro = new DanoVerdadeiro() { DanoHabilidade = i },
                    DanoVerdadeiroPorTurno = new DanoVerdadeiroPorTurno() { DanoHabilidade = i, Turnos = i },
                    Disposicao = i,
                    Foto = new byte[0],
                    Invulnerabilidade = i,
                    Recarga = i,
                });
            }

            obj.Habilidades = lst;

            // tenta persistir monstro
            bool aux = new MonstroBLL().Update(obj);
            Assert.IsTrue(aux, "Deve alterar um monstro no banco de dados em todas as tabelas.");
        }
    }
}
