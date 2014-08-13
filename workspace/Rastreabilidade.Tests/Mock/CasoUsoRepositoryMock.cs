using System.Collections.Generic;
using Rastreabilidade.Entidades;
using Rastreabilidade.Entidades.Persistence;

namespace Rastreabilidade.Tests.Mock {
    class CasoUsoRepositoryMock : IRepository<CasoUso> {
        public CasoUso Single(object key) {
            return new CasoUso {
                Nome = "Manter Produto",
                Menu = "Produtos > Produto",
                Referencias = new List<Referencia> {
                    new Referencia {
                        Tabela = new Tabela {
                            Nome = "Produto"
                        },
                        TarefasTFS = new List<int> {12, 34, 17},
                        TipoReferencia = TipoReferencia.ESCRITA
                    },
                    new Referencia {
                        Tabela = new Tabela {
                            Nome = "GrupoProduto"
                        },
                        TarefasTFS = new List<int> {2763},
                        TipoReferencia = TipoReferencia.LEITURA
                    }
                }
            };
        }

        public System.Collections.Generic.IEnumerable<CasoUso> All() {
            throw new System.NotImplementedException();
        }

        public bool Exists(object key) {
            throw new System.NotImplementedException();
        }

        public void Save(CasoUso item) {
            if (string.IsNullOrWhiteSpace(item.Slug))
                throw new EmptyKeyException();
        }

        public void Delete(object key) {
            if (string.IsNullOrWhiteSpace(key.ToString()))
                throw new EmptyKeyException();
        }
    }
}
