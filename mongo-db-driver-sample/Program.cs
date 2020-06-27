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
                var contacts1 = await client.Contacts.Find(c => c.Name == ContactName2).ToListAsync();
                foreach (Contact c in contacts1)
                {
                    Console.WriteLine("{0} {1}", c.Name, c.LastName);
                }

                // Delete contact by name
                Console.WriteLine("\nDELETE contact by name");
                Console.WriteLine("Insert a name to delete contact/s");
                string ContactName3 = Console.ReadLine();
                var contacts2 = await client.Contacts.Find(c => c.Name == ContactName3).ToListAsync();
                Console.WriteLine("Deleted contacts:");
                foreach (Contact c in contacts2)
                {
                    Console.WriteLine("{0} {1}", c.Name, c.LastName);
                }
                await client.Contacts.DeleteManyAsync(c => c.Name == ContactName3);
                Console.WriteLine("Delete success!");
            }, TaskCreationOptions.LongRunning);
            are.WaitOne();
        }
    }
}
