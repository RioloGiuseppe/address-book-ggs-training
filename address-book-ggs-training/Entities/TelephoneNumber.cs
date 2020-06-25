using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace address_book_ggs_training.Entities
{
    public class TelephoneNumber : ITypedId
    {
        public TelephoneNumber()
        {
        }

        public TelephoneNumber(string type, string number) : this()
        {
            Number = number;
            Type = type;
        }

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Number { get; set; }
        public string Type { get; set; }
    }
}