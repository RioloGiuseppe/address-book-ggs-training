using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.SymbolStore;
using System.Linq;
using System.Web;

namespace address_book_ggs_training.Entities
{
    public class Contact
    {

        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public DateTime BirthDay { get; set; }
        public string WebSite { get; set; }
        public bool Shared { get; set; }
        public ICollection<TelephoneNumber> Numbers { get; set; }
        public ICollection<EmailAddress> Emails { get; set; }
    }

    public class ContactShort
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Avatar { get; set; }

        public ContactShort()
        {

        }

        public ContactShort(Contact contact) : this()
        {
            Id = contact.Id;
            Name = contact.Name;
            Lastname = contact.Lastname;
            Avatar = contact.Avatar;
        }

        public ContactShort(int id, string name, string lastname)
        {
            Id = id;
            Name = name;
            Lastname = lastname;
        }
    }
}