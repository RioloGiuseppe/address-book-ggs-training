using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace address_book_ggs_training.Entities
{
    public class EmailAddress : ITypedId
    {
        public EmailAddress()
        {
        }

        public EmailAddress(string type, string number) : this()
        {
            Number = number;
            Type = type;
        }


        public string Number { get; set; }
        public string Type { get; set; }
    }
}