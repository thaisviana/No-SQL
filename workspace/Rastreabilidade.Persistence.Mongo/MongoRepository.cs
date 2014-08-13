using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using Rastreabilidade.Entidades;
using Rastreabilidade.Entidades.Persistence;

namespace Rastreabilidade.Persistence.Mongo {

    /// <summary>
    /// Implementa a persistência via o banco de dados MongoDB 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MongoRepository<T> : IRepository<T> where T : class, new() {

        private string _connString { get; set; }
        private MongoServer _server { get; set; }
        private MongoDatabase _database { get; set; }
        private MongoCollection<T> _collection { get; set; }
        private ClassMapConfiguration _classMapConfig { get; set; }

        public MongoRepository() {
            _connString = ConfigurationManager.ConnectionStrings["rastreabilidade"].ConnectionString;
            Console.Write(_connString);
            _server = MongoServer.Create(_connString);
            _database = _server.GetDatabase(MongoUrl.Create(_connString).DatabaseName);
            _collection = _database.GetCollection<T>(typeof(T).Name.ToLower());
            _classMapConfig = ClassMapConfiguration.Instance;
        }

        /// <summary>
        /// Retorna um único elemento do repositório que possua uma chave <param name="key">Key</param>
        /// </summary>
        public T Single(object key) {
            QueryDocument query = new QueryDocument("_id", BsonValue.Create(key));
            T entity = _collection.FindOneAs<T>(query);

            if (entity == null) throw new EntityNotFoundException();

            return entity;
        }

        /// <summary>
        /// Retorna todos os elementos do repositório
        /// </summary>
        public IEnumerable<T> All() {
            return _collection.AsQueryable();
        }

        /// <summary>
        /// Verifica se o elemento de chave <param name="key">Key</param> existe no repositório
        /// </summary>
        public bool Exists(object key) {
            try {
                this.Single(key);
            } catch (EntityNotFoundException e) {
                return false;
            }
            return true;
        }

        /// <summary>
        /// Persiste o elemento no repositório
        /// caso o elemento não possua chave, dispara exceção
        /// </summary>
        public void Save(T item) {
            try {
                _collection.Save(item);
            } catch (InvalidOperationException e) {
                throw new EmptyKeyException(e.Message, e);
            }
        }

        /// <summary>
        /// Remove o elemento do respositório
        /// </summary>
        public void Delete(object key) {
            _collection.Remove(new QueryDocument("_id",
                                                 BsonValue.Create(key)));
            /*string type = typeof(T).Name;
            string blah = "Modulo";
            bool test = type.Equals(blah);
            if (keyType.Equals("Tabela")) {
                IQueryable query = _collection.AsQueryable<Modulo>().Select(m => m.Tabelas);
                foreach (Modulo m in query) {
                    MongoCollection<Modulo> tempCollection = _database.GetCollection<Modulo>("modulo");
                    foreach (Tabela t in m.Tabelas) {
                        if (t.Slug.Equals(key)) {
                            m.Tabelas.Remove(t);
                        }
                    }
                    tempCollection.Save(m);
                }
            }*/

        }
    }
}
