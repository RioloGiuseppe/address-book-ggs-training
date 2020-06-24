using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using address_book_ggs_training.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;
using System.Data.Entity.Core.Common.CommandTrees;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace address_book_ggs_training.Entities
{
    public class StoreDB : IDisposable, IContactsManager
    {
        private bool disposedValue;
        protected ApplicationDbContext _context;

        public IDbSet<Contact> Contacts { get => _context.Contacts; }

        public static StoreDB Create(IdentityFactoryOptions<StoreDB> options, IOwinContext context)
        {
            return new StoreDB(context);
        }

        protected StoreDB(IOwinContext context)
        {
            _context = context.Get<ApplicationDbContext>();
        }

        #region Sync

        public Contact AddContact(Contact contact)
        {
            contact.Id = Contacts.Count() > 0 ? Contacts.Max(o => o.Id) + 1 : 1;
            Contacts.Add(contact);
            _context.SaveChanges();
            return contact;
        }

        public List<Contact> GetContacts(int skip = 0, int? take = null)
        {
            if (take == null)
            {
                return Contacts.OrderBy(o => o.Id).Skip(skip).ToList();
            }
            return Contacts.OrderBy(o => o.Id).Skip(skip).Take(take.Value).ToList();
        }

        public Contact GetContactById(int id)
        {
            return Contacts.FirstOrDefault(o => o.Id == id);
        }

        public List<ContactShort> GetContactsShort(int skip = 0, int? take = null)
        {
            return GetContacts(skip, take).Select(o => new ContactShort(o)).ToList();
        }

        public bool RemoveContact(int id)
        {
            Contacts.Remove(Contacts.FirstOrDefault(m => m.Id == id));
            _context.SaveChanges();
            return true;
        }

        public Contact UpdateContact(int id, Contact newContact)
        {
            var contactToUpdate = Contacts.FirstOrDefault(x => x.Id == id);
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

            _context.SaveChanges();

            return contactToUpdate;
        }

        #endregion

        #region Async

        public async Task<Contact> AddContactAsync(Contact contact)
        {
            contact.Id = Contacts.Count() > 0 ? Contacts.Max(o => o.Id) + 1 : 1;
            Contacts.Add(contact);
            await _context.SaveChangesAsync();
            return contact;
        }

        public async Task<List<Contact>> GetContactsAsync(int skip = 0, int? take = null)
        {
            if (take == null)
            {
                return await Contacts.OrderBy(o => o.Id).Skip(skip).ToListAsync();
            }
            return await Contacts.OrderBy(o => o.Id).Skip(skip).Take(take.Value).ToListAsync();
        }

        public async Task<List<ContactShort>> GetContactsShortAsync(int skip = 0, int? take = null)
        {
            var contacts = await GetContactsAsync(skip, take);
            return contacts.Select(o => new ContactShort(o)).ToList();
        }

        public async Task<bool> RemoveContactAsync(int id)
        {
            var contactToRemove = Contacts.FirstOrDefault(m => m.Id == id);
            Contacts.Remove(contactToRemove);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<Contact> GetContactByIdAsync(int id)
        {
            return await Contacts.FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task<Contact> UpdateContactAsync(int id, Contact newContact)
        {
            var contactToUpdate = Contacts.FirstOrDefault(x => x.Id == id);
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

            await _context.SaveChangesAsync();

            return contactToUpdate;
        }

        #endregion

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _context.Dispose();
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