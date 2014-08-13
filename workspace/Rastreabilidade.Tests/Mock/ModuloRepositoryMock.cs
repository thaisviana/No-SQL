using System;
using System.Collections.Generic;
using Rastreabilidade.Entidades;
using Rastreabilidade.Entidades.Persistence;

namespace Rastreabilidade.Tests.Mock {
    public class ModuloRepositoryMock : IRepository<Modulo> {

        public Modulo Single(object key) {
            if (key.ToString().Equals("moduloteste")) {
                return new Modulo {
                    Nome = "MóduloTeste"
                };
            } else if (key.ToString().Equals("nome")) {
                return new Modulo {
                    Nome = "Nome"
                };
            } else if (key.ToString().Equals("teste")) {
                return new Modulo {
                    Nome = "Teste"
                };
            }
            throw new EntityNotFoundException();
        }

        public IEnumerable<Modulo> All() {
            throw new NotImplementedException();
        }

        public bool Exists(object key) {
            throw new NotImplementedException();
        }

        public void Save(Modulo item) {
            if (string.IsNullOrWhiteSpace(item.Slug))
                throw new EmptyKeyException();
        }

        public void Delete(object key) {
            if (string.IsNullOrWhiteSpace(key.ToString()))
                throw new EmptyKeyException();
        }
    }
}
