using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace Tut.Services.Injection
{
    public class ServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(Assembly.Load("Tut.Services")).
                Where(t => t.Name.EndsWith("Services"))
                .AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}