using FluentValidation;
using MUK.NTierMvcProjectTemplate.Web.Models;

namespace MUK.NTierMvcProjectTemplate.Web.ModelValidations
{
    public class LogInViewModelValidation : AbstractValidator<LogInViewModel>
    {
        public LogInViewModelValidation()
        {
            RuleFor(u => u.Email).NotNull().WithMessage("Email adresi zorunldur").NotEmpty().WithMessage("Email adresi zorunldur");
            RuleFor(u => u.Password).NotNull().WithMessage("Parola zorunldur").NotEmpty().WithMessage("Parola zorunldur");
        }
    }
}
