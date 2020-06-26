using address_book_ggs_training.Entities;
using address_book_ggs_training.Models;
using System.Web.Http;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using Unity.WebApi;

namespace address_book_ggs_training
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<ITestService, TestService>();

            container.RegisterType<ApplicationDbContext>();
            container.RegisterType<IContactsManager, ContactsManager>();

            DependencyResolver.SetResolver(new Unity.Mvc5.UnityDependencyResolver(container));
            GlobalConfiguration.Configuration.DependencyResolver = new Unity.WebApi.UnityDependencyResolver(container);
        }
    }
}