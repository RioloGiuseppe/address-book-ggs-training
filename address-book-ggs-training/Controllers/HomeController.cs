using address_book_ggs_training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace address_book_ggs_training.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Contacts = new List<ContactShort>()
            {
                new ContactShort(1, "Carlo", "Verdone"),
                new ContactShort(2, "Giovanni", "Rossi"),
                new ContactShort(3, "Maria", "Chiara"),
                new ContactShort(4, "Giuia", "Rossi")
            };

            ViewBag.Contact = new Contact()
            {
                Address = "Via...",
                Name = "Pippo",
                Lastname = "Topolino",
                Avatar = "",
                BirthDay = DateTime.Now.AddDays(-5045),
                Id = 1,

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
    }
}