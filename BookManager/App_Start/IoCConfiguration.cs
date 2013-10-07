using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;

using BookManager.Models;
using BookManager.Repositories;
using BookManager.Repositories.Interfaces;

namespace BookManager.App_Start
{
    public class IoCConfiguration
    {
        public static void RegisterDependencies()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterType<BookRepository>()
                .As<IBookRepository>()
                .InstancePerHttpRequest();

            builder.RegisterType<BookContext>()
                .AsSelf()
                .InstancePerHttpRequest();

            IContainer container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}