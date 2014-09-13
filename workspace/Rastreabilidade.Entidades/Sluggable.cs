using BIC.Util;

namespace BIC.Entidades {
    /// <summary>
    /// Entidade que possui um nome e um slug derivado dele (nome para URL)
    /// </summary>
    public abstract class Sluggable {

        private string _nome;
        private string _tipo;
        private string _fonte;
        private double _tema;

        private string _Complemento;
        private string _Data;

        //perguntas  PA
        private string _Oque;
        private string _Porque;

        //perguntas BP

        private string _razao;
        private string _detalhes;

        //perguntas LA

        private string _esperado;
        private string _aconteceu;
        private string _diferencas;
        private string _aprendizado;

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


        public double Tema {
            get {
                return this._tema;
            }
            set {
                this._tema = value;
            }
        }
        public string Tipo {
            get {
                return this._tipo;
            }
            set {
                this._tipo = value;
            }
        }


        //Perguntas PA

        public string Oque {
            get {
                return this._Oque;
            }
            set {
                this._Oque = value;
            }
        }

        public string Porque {
            get {
                return this._Porque;
            }
            set {
                this._Porque = value;
            }
        }

        //Perguntas BP

        public string Razao {
            get {
                return this._razao;
            }
            set {
                this._razao = value;
            }
        }

        public string Detalhes {
            get {
                return this._detalhes;
            }
            set {
                this._detalhes = value;
            }
        }


        //perguntas LA
        
        public string Aprendizado {
            get {
                return this._aprendizado;
            }
            set {
                this._aprendizado = value;
            }
        }

        public string Diferencas {
            get {
                return this._diferencas;
            }
            set {
                this._diferencas = value;
            }
        }


        public string Aconteceu {
            get {
                return this._aconteceu ;
            }
            set {
                this._aconteceu = value;
            }
        }

        public string Esperado {
            get {
                return this._esperado;
            }
            set {
                this._esperado = value;
            }
        }

        public string Complemento {
            get {
                return this._Complemento;
            }
            set {
                this._Complemento = value;
            }
        }

        public string Data {
            get {
                return this._Data;
            }
            set {
                this._Data = value;
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
