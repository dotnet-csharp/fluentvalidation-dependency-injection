using System.ComponentModel.DataAnnotations;

namespace Tut.Model
{
    [FluentValidation.Attributes.Validator(typeof(Validator.RegsiterModelValidator))]
    public class RegsiterModel
    {
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Confirm password")]
        public string ConfirmPassword { get; set; }
    }
}