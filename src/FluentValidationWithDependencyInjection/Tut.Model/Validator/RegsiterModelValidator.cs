using FluentValidation;

namespace Tut.Model.Validator
{
    public class RegsiterModelValidator : AbstractValidator<RegsiterModel>
    {
        public RegsiterModelValidator()
        {
            RuleFor(x => x.UserName).NotNull();
            RuleFor(x => x.Password).Null().Length(6, 100);
            RuleFor(x => x.ConfirmPassword).Equal(x => x.Password).NotNull().Length(6, 10);
        }
    }
}