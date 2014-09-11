using BIC.Util;

namespace BIC.Entidades {
    /// <summary>
    /// Entidade que possui um nome e um slug derivado dele (nome para URL)
    /// </summary>
    public abstract class Sluggable {

        private string _nome;
        private char _tipo;
        private string _perguntaA;
        private string _perguntaB;
        private string _perguntaC;
        private string _perguntaD;
        private string _fonte;

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

        public string Fonte {
            get {
                return this._fonte;
            }
            set {
                this._fonte = value;
            }
        }

        public string PerguntaA {
            get {
                return this._perguntaA;
            }
            set {
                this._perguntaA = value;
            }
        }

        public string PerguntaB {
            get {
                return this._perguntaB;
            }
            set {
                this._perguntaB = value;
            }
        }

        public string PerguntaC {
            get {
                return this._perguntaC;
            }
            set {
                this._perguntaC = value;
            }
        }

        public string PerguntaD {
            get {
                return this._perguntaD;
            }
            set {
                this._perguntaD = value;
            }
        }
        public char Tipo {
            get {
                return this._tipo;
            }
            set {
                this._tipo = value;
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
