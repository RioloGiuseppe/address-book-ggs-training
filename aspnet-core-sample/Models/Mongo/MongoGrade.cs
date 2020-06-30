using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace aspnet_core_sample.Models.Mongo
{
    public class MongoGrade : Grade
    {

        public MongoGrade() : base()
        {
        }

        [BsonId]
        public override int GradeId { get; set; }

        //[BsonElement("name")]
        //public string Name { get; set; }
        //[BsonElement("last_name")]
        //public string LastName { get; set; }
    }
}
