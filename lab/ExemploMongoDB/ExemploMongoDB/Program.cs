
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Builders;


namespace ConsoleApplication1 {
    public class Entity {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
    }

    class Program {
        static void Main(string[] args) {
            var connectionString = "mongodb://localhost/?safe=true";
            var server = MongoServer.Create(connectionString);
            var database = server.GetDatabase("test");
            var collection = database.GetCollection<Entity>("entities");

            var entity = new Entity { Name = "Tom" };
            collection.Insert(entity);
            var id = entity.Id;

            var query = Query.EQ("_id", id);
            entity = collection.FindOne(query);

            entity.Name = "Dick";
            collection.Save(entity);

            var update = Update.Set("Name", "Harry");
            collection.Update(query, update);

            collection.Remove(query);
        }
    }
}