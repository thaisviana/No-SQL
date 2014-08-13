using Rastreabilidade.Entidades;

namespace Rastreabilidade.Models {
    public class TabelaModelView : Tabela {

        public TabelaModelView() { }

        public TabelaModelView(Tabela tabela) {
            this.Nome = tabela.Nome;
        }

        public string oldID { get; set; }
    }
}