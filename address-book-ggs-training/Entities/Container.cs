using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace address_book_ggs_training.Entities
{
    public class Container
    {
        public virtual ICollection<Contact> Contacts { get; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    }
}