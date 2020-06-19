using Microsoft.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace address_book_ggs_training.Entities
{
    public class InMemoryDB : IDisposable
    {
        private List<Contact> contacts;
        private bool disposedValue;

        public InMemoryDB()
        {
            contacts = new List<Contact>();
        }

        public static InMemoryDB Create()
        {
            return new InMemoryDB();
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

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposedValue = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~InMemoryDB()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}