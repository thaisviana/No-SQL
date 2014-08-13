using MongoDB.Bson.Serialization;
using Rastreabilidade.Entidades;

namespace Rastreabilidade.Persistence.Mongo {
    /// <summary>
    /// Cria mapeamento das entidades de negócio e seus membros 
    /// em atributos dos documentos do mongoDB
    /// </summary>
    public class ClassMapConfiguration {

        private static ClassMapConfiguration _instance;

        private ClassMapConfiguration() {
            BsonClassMap.RegisterClassMap<Sluggable>(cm => {
                cm.AutoMap();
                cm.SetIdMember(cm.GetMemberMap(c => c.Slug));
            });
        }

        /// <summary>
        /// Retorna uma instância do mapa de configuração de classes
        /// </summary>
        public static ClassMapConfiguration Instance {
            get {
                if (_instance == null) _instance = new ClassMapConfiguration();
                return _instance;
            }
        }
    }
}
