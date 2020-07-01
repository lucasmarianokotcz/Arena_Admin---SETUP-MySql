using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Personagem;
using Model.Personagem.Regras.Classes;
using System.Collections.Generic;

namespace Testes
{
    [TestClass]
    public class PersonagemErrosTest
    {
        [TestMethod]
        public void ValidaPersonagem()
        {
            Personagem personagem = new Personagem()
            {
                Nome = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA ",
                Foto = new byte[0]
            };

            personagem.Habilidades = new List<HabilidadePersonagem>();
            personagem.Habilidades.Add(new HabilidadePersonagem() { Nome = "a", Foto = new byte[0] });
            personagem.Habilidades.Add(new HabilidadePersonagem() { Nome = "a", Foto = new byte[0] });
            personagem.Habilidades.Add(new HabilidadePersonagem() { Nome = "a", Foto = new byte[0] });
            personagem.Habilidades.Add(new HabilidadePersonagem() { Nome = "a", Foto = new byte[0] });

            PersonagemValidacao validacao = new PersonagemValidacao();
            validacao.ValidaPersonagem(personagem);
            Assert.IsTrue(validacao.Erros.Length <= 0, validacao.Erros);
        }
    }
}
