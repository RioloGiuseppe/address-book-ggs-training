using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using address_book_ggs_training.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using Microsoft.Ajax.Utilities;

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
                return Contacts.Skip(skip).ToList();
            }
            return Contacts.Skip(skip).Take(take.Value).ToList();
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

        #region Dispose

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    // TODO: dispose managed state (managed objects)
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