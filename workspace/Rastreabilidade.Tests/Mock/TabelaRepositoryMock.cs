using System;
using System.Collections.Generic;
using Rastreabilidade.Entidades.Persistence;
using Rastreabilidade.Entidades;

namespace Rastreabilidade.Tests.Mock {
    public class TabelaRepositoryMock : IRepository<Tabela> {

        public Tabela Single(object key) {
            if (key.ToString().Equals("tabelateste")) {
                return new Tabela {
                    Nome = "TabelaTeste"
                };
            } else if (key.ToString().Equals("nome")) {
                return new Tabela {
                    Nome = "Nome"
                };
            } else if (key.ToString().Equals("teste")) {
                return new Tabela {
                    Nome = "Teste"
                };
            }
            throw new EntityNotFoundException();
        }

        public IEnumerable<Tabela> All() {
            throw new NotImplementedException();
        }

        public bool Exists(object key) {
            throw new NotImplementedException();
        }

        public void Save(Tabela item) {
            if (string.IsNullOrWhiteSpace(item.Slug))
                throw new EmptyKeyException();
        }

        public void Delete(object key) {
            if (string.IsNullOrWhiteSpace(key.ToString()))
                throw new EmptyKeyException();
        }
    }
}
