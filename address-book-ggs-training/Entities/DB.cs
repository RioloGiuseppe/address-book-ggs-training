using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace address_book_ggs_training.Entities
{
    public static class DB
    {
        private static List<Contact> contacts;

        static DB()
        {
            contacts = new List<Contact>();
        }

        public static void AddContact(Contact contact)
        {
            contact.Id = contacts.Count;
            contacts.Add(contact);
        }


        public static bool RemoveContact(int id)
        {
            var contactToDelete = contacts.FirstOrDefault(x => x.Id == id);
            if (contactToDelete == null) return false;
            contacts.Remove(contactToDelete);
            return true;
        }


        public static IEnumerable<Contact> GetContacts(int from, int n)
        {
            if (contacts.Count < from-1  ) return  Enumerable.Empty<Contact>();

            int nRemainingContacts = contacts.Count - from - 1;

            if (nRemainingContacts<n)
                return contacts.Skip(from).Take(nRemainingContacts);
            
            return contacts.Skip(from).Take(n);
        }

        public static bool UpdateContact(int id, Contact newContact)
        {

            var contactToUpdate = contacts.FirstOrDefault(x => x.Id == id);
            if (contactToUpdate == null) return false;

            contactToUpdate.Address = newContact.Address;
            contactToUpdate.Avatar = newContact.Avatar;
            contactToUpdate.BirthDay = newContact.BirthDay;
            contactToUpdate.Customs = newContact.Customs;
            contactToUpdate.Emails = newContact.Emails;
            contactToUpdate.Lastname = newContact.Lastname;
            contactToUpdate.Name = newContact.Name;
            contactToUpdate.Numbers = newContact.Numbers;
            contactToUpdate.Shared = newContact.Shared;
            contactToUpdate.WebSite = newContact.WebSite;

            return true;



        }



    }
}