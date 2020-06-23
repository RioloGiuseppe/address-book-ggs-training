using address_book_ggs_training.Entities;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.Http;
using System.Web.Http.Results;

namespace address_book_ggs_training.ApiControllers
{
    public class ExampleController : ApiController
    {
        [HttpGet]
        public JsonResult<Contact> SimpleGet()
        {
            var a = new Contact()
            {
                Name = "pippo"
            };
            return Json(a);
        }

        [HttpGet]
        public JsonResult<Contact> SimpleGet2(int id)
        {
            var a = new Contact()
            {
                Name = "pippo",
                Id = id
            };
            return Json(a);
        }

        [HttpPost]
        public JsonResult<Contact> SimplePost([FromBody] object o)
        {
            var a = new Contact()
            {
                Name = "pippo"
            };
            return Json(a);
        }

        [HttpPost]
        public JsonResult<Contact> SimplePost2(string nonloso, [FromBody] object o)
        {
            var a = new Contact()
            {
                Name = "pippo"
            };
            return Json(a);
        }

    }
}