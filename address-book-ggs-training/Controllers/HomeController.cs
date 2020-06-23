using address_book_ggs_training.Entities;
using address_book_ggs_training.Models;
using Microsoft.AspNet.Identity.Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace address_book_ggs_training.Controllers
{
    public class HomeController : Controller
    {
        public HomeController()
        {

        }

        private InMemoryDB _inMemoryDB;

        public InMemoryDB InMemoryDB
        {
            get
            {
                return _inMemoryDB ?? HttpContext.GetOwinContext().Get<InMemoryDB>();
            }
            private set
            {
                _inMemoryDB = value;
            }
        }

        protected StoreDB _storeDB;

        public StoreDB StoreDB
        {
            get
            {
                return _storeDB ?? HttpContext.GetOwinContext().Get<StoreDB>();
            }
            private set
            {
                _storeDB = value;
            }
        }


        public ActionResult Index()
        {
            ViewBag.Contacts = StoreDB.GetContactsShort();
            ViewBag.Contact = new Contact()
            {
                Address = "Via...",
                Name = "Pippo",
                Lastname = "Topolino",
                Avatar = "",
                BirthDay = DateTime.Now.AddDays(-5045),
                Id = 1,
                WebSite = "test.com",

                Numbers = new List<ITypedId>()
                {
                    new TelephoneNumber("Home", "+39 051 552 888"),
                    new TelephoneNumber("Work", "+39 051 888 225")
                },
                Emails = new List<ITypedId>()
                {
                    new EmailAddress("Home", "home@email.it"),
                    new EmailAddress("Work", "work@email.it")
                },
                Customs = new Dictionary<string, string>()
                {
                    { "Note", "Bla bla bla"}
                }
            };

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Save(ContactViewModel model)
        {
            Contact newContact = new Contact()
            {
                Address = model.Address,
                Name = model.Name,
                Lastname = model.Lastname,
                Avatar = "",
                BirthDay = model.BirthDay,
                WebSite = model.WebSite,

                Numbers = new List<ITypedId>()
                {
                    new TelephoneNumber("Home", "+39 051 552 888"),
                    new TelephoneNumber("Work", "+39 051 888 225")
                },
                Emails = new List<ITypedId>()
                {
                    new EmailAddress("Home", "home@email.it"),
                    new EmailAddress("Work", "work@email.it")
                },
                Customs = new Dictionary<string, string>()
                {
                    { "Note", "Bla bla bla"}
                }
            };

            StoreDB.AddContact(newContact);

            ViewBag.Contact = newContact;
            ViewBag.Contacts = StoreDB.GetContactsShort();

            return Redirect("index");
        }

    }
}