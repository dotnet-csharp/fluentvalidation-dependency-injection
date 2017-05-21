using System.Web.Mvc;
using Autofac;
using Autofac.Integration.Mvc;
using FluentValidation.Mvc;
using Tut.Controllers;
using Tut.Model.Validator;
using Tut.Repositories.Injection;
using Tut.Services.Injection;

namespace Tut.Web
{
    public class AutofacConfig
    {
        public static void RegsiterComponents()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof (BaseController).Assembly).PropertiesAutowired();
            builder.RegisterFilterProvider();
            builder.RegisterModule<ValidationModule>();
            builder.RegisterModule<DbContextModule>();
            builder.RegisterModule<ServicesModule>();
            builder.RegisterModule<RepositoryModule>();

            //Create a the builder
            var container = builder.Build();

            //Set up the FluentValidation provider factory and it as a Model validator
            var fluentValidatorModelProviderFactory =
                new FluentValidationModelValidatorProvider(new AutofacValidatorFactory(container));
            DataAnnotationsModelValidatorProvider.AddImplicitRequiredAttributeForValueTypes = false;
            fluentValidatorModelProviderFactory.AddImplicitRequiredValidator = false;
            ModelValidatorProviders.Providers.Add(fluentValidatorModelProviderFactory);

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}