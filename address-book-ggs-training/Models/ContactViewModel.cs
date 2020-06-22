using address_book_ggs_training.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace address_book_ggs_training.Models
{
    public class ContactViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Lastname { get; set; }
        public string Address { get; set; }
        public string Avatar { get; set; }
        public DateTime BirthDay { get; set; }
        public string WebSite { get; set; }
        public bool Shared { get; set; }
        public List<ITypedId> Numbers { get; set; }
        public List<ITypedId> Emails { get; set; }
        public Dictionary<string, string> Customs { get; set; }
    }
}