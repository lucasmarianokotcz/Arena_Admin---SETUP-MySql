using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model.Monstro;
using Model.Monstro.Regras.Classes;
using System.Collections.Generic;

namespace Testes
{
    [TestClass]
    public class MonstroErrosTest
    {
        [TestMethod]
        public void ValidaMonstro()
        {
            Monstro monstro = new Monstro()
            {
                Nome = "AAAAAAAAAAAAAAAAAAAAAAAAAAAAAA ",
                Foto = new byte[0]
            };

            monstro.Habilidades = new List<HabilidadeMonstro>();
            monstro.Habilidades.Add(new HabilidadeMonstro() { Nome = "a", Foto = new byte[0] });
            monstro.Habilidades.Add(new HabilidadeMonstro() { Nome = "a", Foto = new byte[0] });
            monstro.Habilidades.Add(new HabilidadeMonstro() { Nome = "a", Foto = new byte[0] });
            monstro.Habilidades.Add(new HabilidadeMonstro() { Nome = "a", Foto = new byte[0] });

            MonstroValidacao validacao = new MonstroValidacao();
            validacao.ValidaMonstro(monstro);
            Assert.IsTrue(validacao.Erros.Length <= 0, validacao.Erros);
        }
    }
}
