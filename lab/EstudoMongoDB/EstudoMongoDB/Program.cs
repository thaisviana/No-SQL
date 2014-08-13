using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Linq;
using MongoDB.Driver.Builders;
using Rastreabilidade.Entidades;

namespace EstudoMongoDB {
    class Program {
        static void Main(string[] args) {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoServer server = MongoServer.Create(connectionString);
            MongoDatabase database = server.GetDatabase("rastreabilidade");

            MongoCollection<BsonDocument> modulo = database.GetCollection<BsonDocument>("modulo");
            MongoCollection tabela = database.GetCollection<Tabela>("tabela");

            List<Modulo> modulos = new List<Modulo>();

            //string name;
            string s1 = "TESTEEEEEEEEEEEE"; string s2 = "exemplo1"; string s3 = "exemplo2";
            BsonDocument mod = new BsonDocument { { "Modulo", s1 }, { "Tabelas", s2 } };
           // modulo.Insert<BsonDocument> (mod);

            IMongoQuery query = Query.EQ("Modulo", "fofa=)");
            IMongoUpdate update = Update.Set("Modulo", "tata");
            SafeModeResult updatedBook = modulo.Update(query, update);

            /*foreach (Modulo mod in modulo.FindAll()) {
                name = mod.Nome;
                Console.WriteLine("Nome: ", name);
                modulos.Add(mod);
                Console.WriteLine("Modulo: ", mod);
            }*/

            /*var query = Query.EQ("Nome", id);
            entity = collection.FindOne(query);

            var update = Update.Set("Name", "Harry");
            collection.Update(query, update);*/


            // var query = modulo.AsQueryable<Modulo>().Where(m => m.Nome == "TESTEEEEEEEEEEEE").Select(m => m);

            //Console.WriteLine(query);

            //Modulo mod = new Modulo { Nome = "TESTEEEEEEEEEEEE"};
            //modulo.Insert<Modulo> (mod);
            
        }
    }
}
