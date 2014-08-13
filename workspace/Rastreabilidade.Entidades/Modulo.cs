
using System.Collections.Generic;

namespace Rastreabilidade.Entidades {
    /// <summary>
    /// Módulo onde tabelas e casos de uso estão agrupados
    /// </summary>
    public class Modulo : Sluggable {

        /// <summary>
        /// Tabelas que pertencem ao módulo
        /// </summary>
        public List<Tabela> Tabelas { get; set; }

        public Modulo() {
            Tabelas = new List<Tabela>();
        }

    }
}
