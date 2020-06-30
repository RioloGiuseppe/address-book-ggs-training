using aspnet_core_sample.Models.Mongo;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_sample.Data
{
    public class MongoDbClient
    {

        protected MongoClient Client { get; set; }
        public IMongoDatabase Database { get => Client.GetDatabase("demo2"); }
        public IMongoCollection<MongoGrade> Grades { get => Database.GetCollection<MongoGrade>("Grades"); }
        public IMongoCollection<MongoStudent> Students { get => Database.GetCollection<MongoStudent>("Students"); }
        public MongoDbClient()
        {
            Client = new MongoClient("mongodb://localhost:27017/?readPreference=primary&ssl=false");
        }
    }
}
