using Autofac;

namespace Tut.Repositories.Injection
{
    public class DbContextModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<DbFactory>().As<IDbFactory>().InstancePerLifetimeScope();
        }
    }
}