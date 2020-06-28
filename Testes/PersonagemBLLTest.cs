using Intermediario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Shared;
using Model.Personagem;
using Model.Personagem.Regras.Classes;
using System;
using System.Collections.Generic;
using Model.Personagem.Energias;

namespace Testes
{
    [TestClass]
    public class PersonagemBLLTest
    {
        [TestMethod]
        public void ReturnListPersonagems()
        {
            List<Personagem> lstPersonagems = new PersonagemBLL().Select();
            Assert.IsTrue(lstPersonagems != null, "Deve acessar o banco e retornar uma lista de personagens (mesmo que vazia).");
        }

        [TestMethod]
        public void ReturnOnePersonagem()
        {
            List<Personagem> lstPersonagems = new PersonagemBLL().Select();
            Assert.IsTrue(lstPersonagems.Count > 0, "Deve retornar ao menos 1 registro na tabela personagens.");
        }

        [TestMethod]
        public void InserePersonagem()
        {
            var random = new Random();

            // cria objeto personagem
            Personagem obj = new Personagem()
            {
                Nome = "Teste " + random.Next(1, 100),
                Descricao = "Teste descrição " + random.Next(1, 100),
                Foto = new byte[0],
            };

            // cria habilidades do personagem
            List<HabilidadePersonagem> lst = new List<HabilidadePersonagem>();
            for (int i = 1; i <= PersonagemRegras.NumeroHabilidades; i++)
            {
                lst.Add(new HabilidadePersonagem()
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
                    EnergiaVerde = new EnergiaVerde() { Quantidade = i, Ganho = i },
                    EnergiaAzul = new EnergiaAzul() { Quantidade = i, Ganho = i },
                    EnergiaVermelho = new EnergiaVermelho() { Quantidade = i, Ganho = i },
                    EnergiaPreto = new EnergiaPreto() { Quantidade = i, Ganho = i },
                    Foto = new byte[0],
                    Invulnerabilidade = i,
                    Recarga = i,
                });
            }

            obj.Habilidades = lst;

            // tenta persistir personagem
            bool aux = new PersonagemBLL().Insert(obj);
            Assert.IsTrue(aux, "Deve inserir um personagem no banco de dados em todas as tabelas.");
        }

        [TestMethod]
        public void AlteraPersonagem()
        {
            var random = new Random();

            // cria objeto personagem
            Personagem obj = new Personagem()
            {
                Id = 1,
                Nome = "Teste " + random.Next(1, 100),
                Descricao = "Teste descrição " + random.Next(1, 100),
                Foto = new byte[0],
            };

            // cria habilidades do personagem
            List<HabilidadePersonagem> lst = new List<HabilidadePersonagem>();
            for (int i = 1; i <= PersonagemRegras.NumeroHabilidades; i++)
            {
                lst.Add(new HabilidadePersonagem()
                {
                    Id = 1,
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
                    EnergiaVerde = new EnergiaVerde() { Quantidade = i, Ganho = i },
                    EnergiaAzul = new EnergiaAzul() { Quantidade = i, Ganho = i },
                    EnergiaVermelho = new EnergiaVermelho() { Quantidade = i, Ganho = i },
                    EnergiaPreto = new EnergiaPreto() { Quantidade = i, Ganho = i },
                    Foto = new byte[0],
                    Invulnerabilidade = i,
                    Recarga = i,
                });
            }

            obj.Habilidades = lst;

            // tenta persistir personagem
            bool aux = new PersonagemBLL().Update(obj);
            Assert.IsTrue(aux, "Deve alterar um personagem no banco de dados em todas as tabelas.");
        }

        [TestMethod]
        public void ExcluiPersonagem()
        {
            int id = 1;

            // tenta excluir personagem e suas habilidades
            bool aux = new PersonagemBLL().Delete(id);
            Assert.IsTrue(aux, "Deve excluir um personagem no banco de dados em todas as tabelas.");
        }
    }
}
