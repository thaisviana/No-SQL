using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rastreabilidade.Entidades;

namespace Rastreabilidade.Tests.Model {
    [TestClass]
    public class ValidacaoDeDados {

        /// <summary>
        /// Verifica se ao setar o nome de uma Tabela, Caso de Uso ou Módulo
        /// o slug é gerado corretamente
        /// </summary>
        [TestMethod]
        public void VerificaSlug() {
            //verificando tabela
            Tabela t = new Tabela {
                Nome = "Tabela Espaçada"
            };

            Assert.AreEqual(t.Slug, "tabela-espacada", "O slug da tabela não foi gerado corretamente");

            Modulo m = new Modulo {
                Nome = "Módulo Zuão"
            };

            Assert.AreEqual(m.Slug, "modulo-zuao", "O slug do módulo não foi gerado corretamente");

            CasoUso uc = new CasoUso {
                Nome = "Caso de uso com o nome enorme até maior que 45 caracteres"
            };

            Assert.AreEqual(uc.Slug, "caso-de-uso-com-o-nome-enorme-ate-maior-que-4", "O slug do caso de uso não foi gerado corretamente");
        }
    }
}
