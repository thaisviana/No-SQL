
using System.Collections.Generic;

namespace Rastreabilidade.Entidades {
    public class Referencia {
        
        public TipoReferencia TipoReferencia { get ; set; }
        public List<int> TarefasTFS { get; set; }
        public Tabela Tabela { get; set; }
    }
}
