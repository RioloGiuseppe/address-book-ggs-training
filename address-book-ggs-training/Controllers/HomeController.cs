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
        private InMemoryDB _inMemoryDB;

        public HomeController()
        {
            
        }
        //public HomeController(InMemoryDB inMemoryDB)
        //{
        //    _inMemoryDB = inMemoryDB;
        //}
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

        public ActionResult Index()
        {
            InMemoryDB.AddContact(new Contact()
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
            });

            ViewBag.Contacts = InMemoryDB.GetContactsShort();
            //ViewBag.Contacts = new List<ContactShort>()
            //{
            //    new ContactShort(1, "Carlo", "Verdone"),
            //    new ContactShort(2, "Giovanni", "Rossi"),
            //    new ContactShort(3, "Maria", "Chiara"),
            //    new ContactShort(4, "Giuia", "Rossi")
            //};

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
            ViewBag.Contacts = InMemoryDB.GetContactsShort();
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

            return View("index");
        }

    }
}