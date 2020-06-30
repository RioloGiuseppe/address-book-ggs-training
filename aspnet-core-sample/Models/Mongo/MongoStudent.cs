using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_sample.Models.Mongo
{
    public class MongoStudent : Student
    {
        [BsonId]
        public override int Id { get; set; }
    }
}
