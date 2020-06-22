using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using System;
using address_book_ggs_training.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

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
            throw new NotImplementedException();
        }

        public List<Contact> GetContacts(int skip = 0, int? take = null)
        {
            throw new NotImplementedException();
        }

        public List<ContactShort> GetContactsShort(int skip = 0, int? take = null)
        {
            throw new NotImplementedException();
        }

        public bool RemoveContact(int id)
        {
            throw new NotImplementedException();
        }

        public Contact UpdateContact(int id, Contact newContact)
        {
            throw new NotImplementedException();
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