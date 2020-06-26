using address_book_ggs_training.Entities;
using address_book_ggs_training.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace address_book_ggs_training.ApiControllers
{
    public class ContactsController : ApiController
    {

        readonly ContactsManager _storeDB;

        public ContactsController()
        {

        }

        public ContactsController(ContactsManager storeDB)
        {
            _storeDB = storeDB;
        }

        // GET: api/Contacts
        [HttpGet]
        public async Task<IEnumerable<ContactShort>> List()
        {
            try
            {
                return await _storeDB.GetContactsShortAsync();
            }
            catch (Exception)
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
                return await _storeDB.GetContactByIdAsync(id);
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
                var ret = await _storeDB.AddContactAsync(value);
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
                return await _storeDB.UpdateContactAsync(id, value);
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
                return await _storeDB.RemoveContactAsync(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
