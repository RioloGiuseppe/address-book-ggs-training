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

        public ActionResult Emanuele()
        {
            ViewData["NumTimes"] = 2;
            ViewData["Message"] = "Hello from Emanuele";
            ViewData["DateTime"] = DateTime.Now;

            return View();
        }

        public ActionResult Maicol()
        {
            ViewBag.Message = "Maicol's page.";

            return View();
        }
    }
}