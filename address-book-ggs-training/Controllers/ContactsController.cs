using address_book_ggs_training.Entities;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Mvc;

namespace address_book_ggs_training.Controllers
{
    public class ContactsController : Controller
    {
        // GET: Contacts
        [HttpPost]
        public JsonResult Remove(int contactId)
        {
            return  Json (new { result = DB.RemoveContact(contactId) });
        }
    }
}