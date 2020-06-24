using address_book_ggs_training.Entities;
using Antlr.Runtime.Tree;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace address_book_ggs_training.ApiControllers
{
    public class ContactsController : ApiController
    {
        protected StoreDB _storeDB;
        public StoreDB StoreDB
        {
            get
            {
                return _storeDB ?? Request.GetOwinContext().Get<StoreDB>();
            }
            private set
            {
                _storeDB = value;
            }
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<IEnumerable<ContactShort>> List()
        {
            try
            {
                return await StoreDB.GetContactsShortAsync();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        // GET: api/Contacts/5
        [HttpGet]
        public async Task<Contact> Get(int id)
        {
            try
            {
                return await StoreDB.GetContactByIdAsync(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // POST: api/Contacts
        [HttpPost]
        public async Task<Contact> Create([FromBody] Contact value)
        {
            try
            {
                var ret = await StoreDB.AddContactAsync(value);
                return ret;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // PUT: api/Contacts/5
        [HttpPut]
        public async Task<Contact> Update(int id, [FromBody] Contact value)
        {
            try
            {
                return await StoreDB.UpdateContactAsync(id, value);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // DELETE: api/Contacts/5
        [HttpDelete]
        public async Task<bool> Delete(int id)
        {
            try
            {
                return await StoreDB.RemoveContactAsync(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
