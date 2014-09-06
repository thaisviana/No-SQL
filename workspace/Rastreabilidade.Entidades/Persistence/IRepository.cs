using System.Collections.Generic;
using System.Linq;

namespace BIC.Entidades.Persistence {
    
    /// <summary>
    /// Define um repositório de armazenamento de entidades que deve implementar uma lógica de persistência
    /// </summary>
    /// <typeparam name="T">Tipo do elemento que será armazenado (precisa ser uma classe e um construtor público sem parâmetros)</typeparam>
    public interface IRepository<T> where T : class, new() {
        /// <summary>
        /// Retorna um único elemento do repositório que possua uma chave <param name="key">Key</param>
        /// </summary>
        /// <exception cref="BIC.Entidades.Persistence.EntityNotFoundException">Ocorre quando não encontramos o elemento buscado</exception>
        T Single(object key);
        
        /// <summary>
        /// Retorna todos os elementos do repositório
        /// </summary>
        IEnumerable<T> All();

        /// <summary>
        /// Verifica se o elemento de chave <param name="key">Key</param> existe no repositório
        /// </summary>
        bool Exists(object key);

        /// <summary>
        /// Persiste o elemento no repositório
        /// </summary>
        void Save(T item);

        /// <summary>
        /// Remove o elemento do respositório
        /// </summary>
        void Delete(object key);
    }
}
