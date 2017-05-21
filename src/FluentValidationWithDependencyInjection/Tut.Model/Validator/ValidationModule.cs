using Autofac;
using FluentValidation;

namespace Tut.Model.Validator
{
    public class ValidationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<RegisterModelValidator>()
                .Keyed<IValidator>(typeof (IValidator<RegsiterModel>))
                .As<IValidator>();
        }
    }
}