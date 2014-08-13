using System;
using System.Collections.Generic;
using System.Linq;
using Rastreabilidade.Entidades;
using Rastreabilidade.Entidades.Persistence;

namespace Rastreabilidade.Tests.Mock {
    class BuscaRepositoryMock : IRepository<Busca> {

        public Busca Single(object key) {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Base de mock de alguns módulos e tabelas 
        /// </summary>
        /// <returns></returns>
        public IEnumerable<Busca> All() {
            return new List<Busca> {
                new Busca { Nome = "Acordo", TipoEntidade=TipoEntidade.MODULO},
                new Busca { Nome = "Ambiente", TipoEntidade=TipoEntidade.MODULO},
                new Busca { Nome = "AutenticaçãoAutorização", TipoEntidade=TipoEntidade.MODULO},
                new Busca { Nome = "Funcionalidade", TipoEntidade=TipoEntidade.TABELA},
                new Busca { Nome = "Acrescimo", TipoEntidade=TipoEntidade.TABELA},
                new Busca { Nome = "Desconto", TipoEntidade=TipoEntidade.TABELA},
                new Busca { Nome = "Manutenção de Funcionalidade", TipoEntidade=TipoEntidade.CASOUSO}
            };
        }

        public bool Exists(object key) {
            throw new NotImplementedException();
        }

        public void Save(Busca item) {
            throw new NotImplementedException();
        }

        public void Delete(object key) {
            throw new NotImplementedException();
        }

        public IQueryable<Busca> Collection() {
            throw new NotImplementedException();
        }
    }
}
