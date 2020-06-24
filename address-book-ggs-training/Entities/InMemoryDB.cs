using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace address_book_ggs_training.Entities
{
    public class InMemoryDB : IDisposable, IContactsManager
    {
        private static InMemoryDB instance = null;

        public static InMemoryDB Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new InMemoryDB();
                }
                return instance;
            }
        }

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

        public static InMemoryDB CreateSingleton()
        {
            return Instance;
        }

        #region Sync

        public Contact AddContact(Contact contact)
        {
            contact.Id = contacts.Count > 0 ? contacts.Max(o => o.Id) + 1 : 1;
            contacts.Add(contact);
            return contact;
        }

        public bool RemoveContact(int id)
        {
            int rm = contacts.RemoveAll(x => x.Id == id);
            return rm >= 1;
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

        public Contact GetContactById(int id)
        {
            return contacts.FirstOrDefault(o => o.Id == id);
        }

        #endregion

        #region Async

        public Task<Contact> AddContactAsync(Contact contact)
        {
            return Task<Contact>.Factory.StartNew(() =>
            {
                return AddContact(contact);
            });
        }

        public Task<List<Contact>> GetContactsAsync(int skip = 0, int? take = null)
        {
            return Task<List<Contact>>.Factory.StartNew(() =>
            {
                return GetContacts(skip, take);
            });
        }

        public Task<List<ContactShort>> GetContactsShortAsync(int skip = 0, int? take = null)
        {
            return Task<List<ContactShort>>.Factory.StartNew(() =>
            {
                return GetContactsShort(skip, take);
            });
        }

        public Task<bool> RemoveContactAsync(int id)
        {
            return Task<bool>.Factory.StartNew(() =>
            {
                return RemoveContact(id);
            });
        }

        public Task<Contact> GetContactByIdAsync(int id)
        {
            return Task<Contact>.Factory.StartNew(() =>
            {
                return GetContactById(id);
            });
        }

        public Task<Contact> UpdateContactAsync(int id, Contact newContact)
        {
            return Task<Contact>.Factory.StartNew(() =>
            {
                return UpdateContact(id, newContact);
            });
        }

        #endregion

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    contacts.Clear();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }

        #endregion
    }
}