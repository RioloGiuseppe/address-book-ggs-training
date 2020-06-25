using System.Collections.Generic;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using address_book_ggs_training.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace address_book_ggs_training.Models
{
    // You can add profile data for the user by adding more properties to your ApplicationUser class, please visit https://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
    public class ApplicationUser : IdentityUser
    {
        public virtual ICollection<Container> Containers { get; }
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("SQLServer", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Contact> Contacts { get; set; }
        public virtual IDbSet<Container> Containers { get; set; }
        public virtual IDbSet<EmailAddress> Emails { get; set; }
        public virtual IDbSet<TelephoneNumber> Numbers { get; set; }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }

        public System.Data.Entity.DbSet<address_book_ggs_training.Entities.TelephoneNumber> TelephoneNumbers { get; set; }

        public System.Data.Entity.DbSet<address_book_ggs_training.Entities.EmailAddress> EmailAddresses { get; set; }
    }
}