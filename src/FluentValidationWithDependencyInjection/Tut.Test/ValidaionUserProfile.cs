using Faker;
using FluentValidation.TestHelper;
using Moq;
using NUnit.Framework;
using Tut.Entities;
using Tut.Model.Validator;
using Tut.Repositories;

namespace Tut.Test
{
    [TestFixture]
    public class ValidaionUserProfile
    {
        private Mock<IUserProfileRepository> repository;
        private RegisterModelValidator validator;

        [SetUp]
        public void SetUp()
        {
            repository = new Mock<IUserProfileRepository>();
            repository.Setup(x => x.GetUserProfileByUserName("existing_username"))
                .Returns(new UserProfile());

            validator = new RegisterModelValidator(repository.Object);
        }

        [Test]
        public void ShouldHaveValidationErrorWhenUserNameExists()
        {
            validator.ShouldHaveValidationErrorFor(f => f.UserName, "existing_username");
        }

        [Test]
        public void The_user_name_cannot_be_empty()
        {
            validator.ShouldHaveValidationErrorFor(f => f.UserName, string.Empty);
        }

        [Test]
        public void Should_get_by_user_name_is_ok()
        {
            var userProfile = new UserProfile
            {
                Id = NumberFaker.Number(1, 100),
                UserName = NameFaker.Name(),
                Email = InternetFaker.Email()
            };
            var _repository = new Mock<IUserProfileRepository>();
            _repository.Setup(x => x.GetUserProfileByUserName(userProfile.UserName))
                .Returns(userProfile);

            var result = _repository.Object.GetUserProfileByUserName(userProfile.UserName);

            Assert.AreEqual(result, userProfile);
        }
    }
}