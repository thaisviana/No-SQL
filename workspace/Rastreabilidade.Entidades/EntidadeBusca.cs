
using System;
using Rastreabilidade.Util;

namespace Rastreabilidade.Entidades {

    /// <summary>
    /// Referência para uma entidade a que pode ser buscada
    /// Tipicamente módulos, tabelas e casos de uso
    /// </summary>
    public class Busca : Sluggable {

        /// <summary>
        /// Tipo de entidade buscável
        /// </summary>
        public TipoEntidade TipoEntidade { get; set; }

        /// <summary>
        /// Retorna a Url do recurso que foi buscado
        /// </summary>
        public string Url {
            get {
                string cleanActionName = Enum.GetName(typeof(TipoEntidade), TipoEntidade).GenerateSlug();
                return string.Format("/{0}/{1}", cleanActionName, this.Slug); 
            }
        }

    }
}
