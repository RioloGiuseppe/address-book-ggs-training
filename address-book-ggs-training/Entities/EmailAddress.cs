using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            Email = number;
            Type = type;
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Email { get; set; }
        public string Type { get; set; }
    }
}