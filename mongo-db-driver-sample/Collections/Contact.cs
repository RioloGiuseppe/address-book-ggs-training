using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mongo_db_driver_sample.Collections
{
    public class Contact
    {
        [BsonId]
        public ObjectId ID { get; set; }


        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("last_name")]
        public string LastName { get; set; }
    }
}
