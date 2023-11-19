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

            RuleFor(u => u.Password).NotEmpty().WithMessage("Your password cannot be empty")
                    .MinimumLength(8).WithMessage("Your password length must be at least 8.")
                    .MaximumLength(16).WithMessage("Your password length must not exceed 16.")
                    .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                    .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                    .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");
        }
    }
}
