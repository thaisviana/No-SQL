
using System;

namespace BIC.Entidades.Persistence {
    /// <summary>
    /// Exceção retornada quando se tenta incluir no repositório uma entidade sem chave
    /// </summary>
    public class EmptyKeyException : Exception {
        public EmptyKeyException() {}

        public EmptyKeyException(string message, Exception innerException) : base(message, innerException) {}
    }
}
