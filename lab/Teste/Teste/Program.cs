using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Driver.Builders;
using MongoDB.Driver.Linq;

namespace Teste {
    class Modulo {
        public ObjectId Id { get; set; }
        public string Nome { get; set; }
        public List<Tabela> Tabelas { get; set; }
    }
    class Tabela {
        public ObjectId Id {get; set;}
        public string Nome {get; set;}
    }
    class Program {
        static void Main(string[] args) {
            var connectionString = "mongodb://localhost/?safe=true";
            MongoServer server = MongoServer.Create(connectionString);
            MongoDatabase database = server.GetDatabase("rastreabilidade_teste");

            MongoCollection<BsonDocument> modulo = database.GetCollection<BsonDocument>("modulos");
            MongoCollection tabela = database.GetCollection<Tabela>("tabelas");

            string s = "TESTEEEEEEEEEEEE"; var id = 00000;
            BsonDocument mod = new BsonDocument {{"Modulo", s}, {"ModuloID", id}};
            //modulo.Insert<BsonDocument> (mod);
            //var id = mod.Id;

            Modulo mod2 = new Modulo { Nome = "exemplo" };
            //modulo.Insert<Modulo>(mod2);
            var id2 = mod2.Id;
            
            var query = Query.EQ("_id", id2);
            mod = modulo.FindOne(query);

            var update = Update.Set("Nome", "ZZZZZ");
            modulo.Update(query, update);

            var query2 = modulo.AsQueryable<Modulo>().Where(m => m.Nome == "TESTEEEEEEEEEEEE").Select(m => m);

            var result = modulo.AsQueryable<Modulo>().Count();

            Console.WriteLine(query2);
            Console.WriteLine(result);

            //modulo.Remove(query);
            //modulo.Drop();
        }
    }
}
