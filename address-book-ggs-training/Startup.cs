using address_book_ggs_training.Entities;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(address_book_ggs_training.Startup))]
namespace address_book_ggs_training
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);

            //app.CreatePerOwinContext(() => new InMemoryDB());
            app.CreatePerOwinContext(InMemoryDB.CreateSingleton);
            app.CreatePerOwinContext<ContactsManager>(ContactsManager.Create);
        }
    }
}
