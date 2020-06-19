using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace address_book_ggs_training.Entities
{
    public class InMemoryDB
    {
        private List<Contact> contacts;

        public InMemoryDB()
        {
            contacts = new List<Contact>();
        }

        public Contact AddContact(Contact contact)
        {
            contact.Id = contacts.Max(o => o.Id) + 1;
            contacts.Add(contact);
            return contact;
        }

        public bool RemoveContact(int id)
        {
            int rm = contacts.RemoveAll(x => x.Id == id);
            return rm > 1;
        }

        public List<Contact> GetContacts(int skip = 0, int? take = null)
        {
            if (take == null)
            {
                return contacts.Skip(skip).ToList();
            }
            return contacts.Skip(skip).Take(take.Value).ToList();
        }

        public List<ContactShort> GetContactsShort(int skip = 0, int? take = null)
        {
            return GetContacts(skip, take).Select(o => new ContactShort(o)).ToList();
        }

        public Contact UpdateContact(int id, Contact newContact)
        {
            var contactToUpdate = contacts.FirstOrDefault(x => x.Id == id);
            if (contactToUpdate == null) return null;

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

            return contactToUpdate;
        }
    }
}