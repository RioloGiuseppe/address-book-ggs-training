using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace address_book_ggs_training.Entities
{
    public class EmailAddress : ITypedId
    {
        public string Number { get; set; }
        public string Type { get; set; }
    }
}