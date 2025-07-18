using FluentValidation;
using HospitalManagementSystem.Application.DTOs;

namespace HospitalManagementSystem.Application.Validators
{
    public class UserCreateValidator : AbstractValidator<UserCreateDto>
    {
        public UserCreateValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Isim bos olamaz")
                .MaximumLength(30).WithMessage("Isim en fazla 30 karakter olabilir");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Soyisim bos olamaz")
                .MaximumLength(20).WithMessage("Soyisim en fazla 20 karakter olabilir");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email bos olamaz")
                .MaximumLength(75).WithMessage("e-posta en fazla 75 karakter olabilir")
                .EmailAddress().WithMessage("Gecerli bir e-posta adresi yaziniz");

            RuleFor(x => x.Password)
                .NotEmpty().WithMessage("Sifre bos olamaz");
        }
    }
}
