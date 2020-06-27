using Intermediario;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Model;
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
    }
}
