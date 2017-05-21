using System;
using Autofac;
using FluentValidation;

namespace Tut.Model.Validator
{
    public class AutofacValidatorFactory : ValidatorFactoryBase
    {
        private readonly IContainer _container;

        public AutofacValidatorFactory(IContainer container)
        {
            _container = container;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            var validator = _container.ResolveOptionalKeyed<IValidator>(validatorType);
            return validator;
        }
    }
}