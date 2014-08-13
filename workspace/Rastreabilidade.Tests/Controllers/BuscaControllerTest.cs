using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rastreabilidade.Controllers;
using Rastreabilidade.Entidades;
using Rastreabilidade.Tests.Mock;

namespace Rastreabilidade.Tests.Controllers {
    /// <summary>
    /// Testa as features referentes às açoes de busca
    /// </summary>
    [TestClass]
    public class BuscaControllerTest {

        /// <summary>
        /// Verifica se é possível executar uma busca exatamente
        /// </summary>
        [TestMethod]
        public void ExecutaBusca() {
            BuscaController controller = new BuscaController(new BuscaRepositoryMock());

            IEnumerable<Busca> searchResult = controller.Get("dade").Data as IEnumerable<Busca>;

            foreach (Busca b in searchResult)
                Assert.IsTrue(b.Nome.Contains("dade"));
        }

    }
}
