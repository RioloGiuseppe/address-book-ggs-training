using mongo_db_driver_sample.Collections;
using MongoDB.Driver;
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

                // Insert contact
                Console.WriteLine("\nCREATE new contact");
                Console.WriteLine("Insert name");
                string ContactName1 = Console.ReadLine();
                Console.WriteLine("Insert lastname");
                string ContactLastname = Console.ReadLine();

                await client.Contacts.InsertOneAsync(new Contact()
                {
                    Name = ContactName1,
                    LastName = ContactLastname
                });
                Console.WriteLine("Contact {0} {1} created", ContactName1, ContactLastname);

                // Get contact by name
                Console.WriteLine("\nGET contact by name");
                Console.WriteLine("Insert a name to find contact info");
                string ContactName2 = Console.ReadLine();
                var contacts = await client.Contacts.Find(c => c.Name == ContactName2).ToListAsync();
                foreach (Contact c in contacts)
                {
                    Console.WriteLine("{0} {1}", c.Name, c.LastName);
                }
            }, TaskCreationOptions.LongRunning);
            are.WaitOne();
        }
    }
}
