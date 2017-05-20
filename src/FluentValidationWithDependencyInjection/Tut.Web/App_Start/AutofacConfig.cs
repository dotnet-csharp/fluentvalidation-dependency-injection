using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using Tut.Controllers;

namespace Tut.Web
{
    public class AutofacConfig
    {
        public static void RegsiterComponents()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof (BaseController).Assembly);
            builder.RegisterFilterProvider();

            //Create a the builder
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}