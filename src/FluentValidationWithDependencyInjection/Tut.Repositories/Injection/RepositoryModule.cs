using System.Reflection;
using Autofac;
using Module = Autofac.Module;

namespace Tut.Repositories.Injection
{
    public class RepositoryModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.Register(c => new DIContext()).InstancePerRequest();

            builder.RegisterAssemblyTypes(Assembly.Load("Tut.Repositories"))
                .Where(t => t.Name.EndsWith("Repository")).
                AsImplementedInterfaces().InstancePerLifetimeScope();
        }
    }
}