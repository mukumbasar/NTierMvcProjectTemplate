using FluentValidation;
using MUK.NTierMvcProjectTemplate.Web.Models;

namespace MUK.NTierMvcProjectTemplate.Web.ModelValidations
{
    public class RegisterViewModelValidation : AbstractValidator<RegisterViewModel>
    {
        public RegisterViewModelValidation()
        {
            RuleFor(u => u.Name).NotNull().WithMessage("Ad alanı zorunludur.").NotEmpty().WithMessage("Ad alanı zorunludur.");
            RuleFor(u => u.Name).MaximumLength(20).WithMessage("Ad uzunluğu 20 karakter olmalıdır...");
            RuleFor(u => u.Surname).NotNull().WithMessage("Soyad alanı zorunludur.").NotEmpty();

            RuleFor(u => u.Email).NotNull().WithMessage("Email adresi zorunldur").NotEmpty().WithMessage("Email adresi zorunldur");
            RuleFor(u => u.Email).EmailAddress().WithMessage("Email formatı yanlıştır. Lütfen kontrol ediniz.");

            RuleFor(u => u.Password).NotEmpty().WithMessage("Your password cannot be empty");
        }
    }
}
