using address_book_ggs_training.Entities;
using Antlr.Runtime.Tree;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
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
        public IEnumerable<ContactShort> List()
        {
            try
            {
                return StoreDB.GetContactsShort();
            }
            catch (Exception e)
            {
                return null;
            }
        }

        // GET: api/Contacts/5
        [HttpGet]
        public Contact Get(int id)
        {
            try
            {
                return StoreDB.GetContactById(id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // POST: api/Contacts
        [HttpPost]
        public Contact Create([FromBody] Contact value)
        {
            try
            {
                return StoreDB.AddContact(value);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        // PUT: api/Contacts/5
        [HttpPut]
        public Contact Update(int id, [FromBody] Contact value)
        {
            try
            {
                return StoreDB.UpdateContact(id, value);
            }
            catch (Exception)
            {
                return null;
            }
        }

        // DELETE: api/Contacts/5
        [HttpDelete]
        public bool Delete(int id)
        {
            try
            {
                return StoreDB.RemoveContact(id);
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
