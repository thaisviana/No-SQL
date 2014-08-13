using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rastreabilidade.Entidades.Persistence;
using Rastreabilidade.Entidades;
using Rastreabilidade.Persistence.Mongo;
using System.Linq;

namespace Rastreabilidade.Tests.Model {
    [TestClass]
    public class MongoRepositoryTest {

        private IRepository<Modulo> _rp;

        [TestInitialize]
        public void InstanciaRepository() {
            _rp = new MongoRepository<Modulo>();
            
            //apangando todos os documentos do repositório para o próximo teste
            foreach (Modulo m in _rp.All())
                _rp.Delete(m.Slug);
        }

        /// <summary>
        /// Verifica um CRUD de um módulo no banco mongodb
        /// </summary>
        [TestMethod]
        public void CicloVidaModulo() {
            // Cria um novo módulo m
            Modulo m = new Modulo {
                Nome = "MóduloTeste"
            };

            // Adiciona esse novo módulo ao banco
            _rp.Save(m);

            // Retorna o objeto que possui a id passada no parâmetro
            Modulo m2 = _rp.Single("moduloteste");
            // Confere se o nome do módulo retornado é igual ao nome do módulo inserido
            Assert.AreEqual(m2.Nome, m.Nome, "Não foi possível recuperar o módulo");

            // Adiciona tabelas ao módulo
            m2.Tabelas = new List<Tabela> {
                new Tabela {
                    Nome = "TabelaTeste"
                }
            };
            // Como esse módulo já existe, save tem a função de atualizar
            _rp.Save(m2);

            m = _rp.Single("moduloteste");
            // Confere se o módulo retornado possui alguma tabela com o nome que foi inserido
            Assert.IsTrue(m.Tabelas.Any(t => t.Nome == "TabelaTeste"));

            m = new Modulo {
                Nome = "MóduloTeste2"
            };
            _rp.Save(m);

            // Confere se o método All encontra os dois módulos inseridos
            Assert.AreEqual(2, _rp.All().Count());

            // Apaga um módulo do banco
            _rp.Delete("moduloteste");
            // Confere se o módulo foi mesmo apagado pela quantidade de módulos encontrados no All
            Assert.AreEqual(1, _rp.All().Count());
        }

        /// <summary>
        /// Testa se joga a exceção caso não encontre o módulo
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(EntityNotFoundException))]
        public void ExcecaoBuscaModuloInexistente() {
            Modulo m = _rp.Single("moduloteste3");
        }

        /// <summary>
        /// Testa se joga a exceção caso salve uma entidade sem chave
        /// </summary>
        [TestMethod]
        [ExpectedException(typeof(EmptyKeyException))]
        public void SalvandoEntidadeSemChave() {
            Modulo m = new Modulo {
                Nome = "ModuloTeste",
                Slug = "    "
            };
            _rp.Save(m);
        }
    }
}
