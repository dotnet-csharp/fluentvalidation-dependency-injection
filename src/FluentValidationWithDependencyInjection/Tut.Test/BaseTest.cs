using Autofac;
using Faker;
using FluentValidation;
using Moq;
using NUnit.Framework;
using Tut.Entities;
using Tut.Model;
using Tut.Model.Validator;
using Tut.Repositories;
using Tut.Repositories.Injection;

namespace Tut.Test
{
    [TestFixture]
    public class BaseTest
    {
        protected readonly UserProfile Profile = new UserProfile
        {
            Id = NumberFaker.Number(1, 100),
            UserName = NameFaker.Name(),
            Email = InternetFaker.Email()
        };

        protected IValidator<RegsiterModel> Validator;

        [SetUp]
        public void set_dependency_injection_repository()
        {
            //var container = Bootstrapper.RegsiterComponents();
            var builder = new ContainerBuilder();
            builder.RegisterModule<RepositoryModule>();

            var repository = new Mock<IUserProfileRepository>();
            builder.RegisterInstance(repository.Object).As<IUserProfileRepository>();

            repository.Setup(x => x.GetUserProfileByUserName(Profile.UserName)).Returns(Profile);

            Validator = new RegisterModelValidator(repository.Object);

            builder.Build();
        }
    }
}