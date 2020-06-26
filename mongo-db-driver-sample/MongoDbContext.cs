using mongo_db_driver_sample.Collections;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mongo_db_driver_sample
{
    public class MongoDbContext
    {
        protected MongoClient Client { get; set; }
        public IMongoDatabase Database { get; protected set; }
        public IMongoCollection<Contact> Contacts { get; protected set; }

        public MongoDbContext(string connectionString)
        {
            Client = new MongoClient(connectionString);
        }

        public async virtual Task InitDb()
        {
            // get or create db
            Database = Client.GetDatabase("demo");

            // List databases on server
            Console.WriteLine("Databases:");
            var t = await Client.ListDatabasesAsync();
            await t.ForEachAsync(db => Console.WriteLine($"  {db["name"]}"));
            Console.WriteLine();

            // List databases on server
            Console.WriteLine("Collections:");
            await (await Database.ListCollectionsAsync()).ForEachAsync(db => Console.WriteLine($"  {db["name"]}"));
            Console.WriteLine();

            Contacts = Database.GetCollection<Contact>("Contacts");

            Console.WriteLine("Contacts:");
            var contacts = await Contacts.Find(new BsonDocument()).ToListAsync();
            foreach (var c in contacts)
            {
                Console.WriteLine($"  {c.Name} {c.LastName}");
            }
        }
    }
}
