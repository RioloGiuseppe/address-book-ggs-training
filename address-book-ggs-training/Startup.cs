using Microsoft.Owin;
using Owin;
using address_book_ggs_training.Entities;

[assembly: OwinStartupAttribute(typeof(address_book_ggs_training.Startup))]
namespace address_book_ggs_training
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            app.CreatePerOwinContext(InMemoryDB.Create);
        }
    }
}
