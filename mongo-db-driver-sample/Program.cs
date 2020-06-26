using mongo_db_driver_sample.Collections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mongo_db_driver_sample
{
    class Program
    {
        static AutoResetEvent are = new AutoResetEvent(false);

        static void Main(string[] args)
        {
            Task.Factory.StartNew(async () =>
            {
                var client = new MongoDbContext("mongodb://localhost:27017/?readPreference=primary&ssl=false");
                await client.InitDb();
                await client.Contacts.InsertOneAsync(new Contact()
                {
                    Name = "Giovanni",
                    LastName = "Rossi"
                });
            }, TaskCreationOptions.LongRunning);
            are.WaitOne();
        }
    }
}
