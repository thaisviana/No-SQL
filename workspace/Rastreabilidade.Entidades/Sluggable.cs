using Rastreabilidade.Util;

namespace Rastreabilidade.Entidades {
    /// <summary>
    /// Entidade que possui um nome e um slug derivado dele (nome para URL)
    /// </summary>
    public abstract class Sluggable {

        private string _nome;

        /// <summary>
        /// Nome da tabela sem o schema
        /// Exemplo: "Produto"
        /// </summary>
       
        public string Nome {
            get {
                return this._nome;
            }
            set {
                this._nome = value;
                this.Slug = value.GenerateSlug();
            }
        }

        private string _slug;
        /// <summary>
        /// Campo preechido automaticamente a partir do nome removendo caracteres especiais 
        /// e colocando tudo em caixa-baixa (usado para a url)
        /// 
        /// Não pode ser uma string vazia!
        /// </summary>
        public string Slug {
            get {
                return this._slug;
            }
            set {
                this._slug = string.IsNullOrWhiteSpace(value) ? null : value;
            }
        }
 
    }
}
