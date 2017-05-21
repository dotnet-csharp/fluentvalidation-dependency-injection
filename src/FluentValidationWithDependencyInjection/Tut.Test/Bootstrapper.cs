using Autofac;
using Tut.Repositories.Injection;

namespace Tut.Test
{
    public class Bootstrapper
    {
        public static IContainer RegsiterComponents()
        {
            var builder = new ContainerBuilder();
            //builder.RegisterModule<ValidationModule>();
            //builder.RegisterModule<DbContextModule>();
            builder.RegisterModule<RepositoryModule>();

            //Create a the builder
            var container = builder.Build();

            //Set up the FluentValidation provider factory and it as a Model validator
            //var fluentValidatorModelProviderFactory =
            //    new FluentValidationModelValidatorProvider(new AutofacValidatorFactory(container))
            //    {
            //        AddImplicitRequiredValidator = false
            //    };
            //DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            //ModelValidatorProviders.Providers.Add(fluentValidatorModelProviderFactory);

            return container;
        }
    }
}