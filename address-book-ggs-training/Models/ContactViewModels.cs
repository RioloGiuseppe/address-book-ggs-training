using address_book_ggs_training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace address_book_ggs_training.Models
{
    public class CreateContactViewModel
    {
        public CreateContactViewModel()
        {

        }

        public CreateContactViewModel(Contact contact) : this()
        {
            Id = contact.Id;
            Name = contact.Name;
            Lastname = contact.Lastname;
            Address = contact.Address;
            Avatar = contact.Avatar;
            BirthDay = contact.BirthDay;
            WebSite = contact.WebSite;
            Shared = contact.Shared;
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public DateTime BirthDay { get; set; }
        public string WebSite { get; set; }
        public bool Shared { get; set; }
        public int ContainerId { get; set; }
    }



}