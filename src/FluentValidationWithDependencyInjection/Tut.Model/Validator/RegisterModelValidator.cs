using FluentValidation;
using Tut.Repositories;

namespace Tut.Model.Validator
{
    public class RegisterModelValidator : AbstractValidator<RegsiterModel>
    {
        private readonly IUserProfileRepository _userProfileRepository;

        public RegisterModelValidator(IUserProfileRepository userProfileRepository)
        {
            _userProfileRepository = userProfileRepository;
        }

        public RegisterModelValidator()
        {
            RuleFor(x => x.UserName).NotEmpty().Must(
                (profile, username)
                    => _userProfileRepository.GetUserProfileByUserName(username) != null).
                WithMessage("This user name is already regsitered");
            RuleFor(x => x.Password).NotEmpty().Length(6, 100);
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).NotNull().Length(6, 10);
        }
    }
}