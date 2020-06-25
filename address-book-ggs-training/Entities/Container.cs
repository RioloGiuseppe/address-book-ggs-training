using address_book_ggs_training.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace address_book_ggs_training.Entities
{
    public class Container
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string UserId { get; set; }

        public ApplicationUser User { get; set; }
        public virtual ICollection<Contact> Contacts { get; set; }
    }
}