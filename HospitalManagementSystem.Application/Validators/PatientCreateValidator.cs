using FluentValidation;
using HospitalManagementSystem.Application.DTOs;

namespace HospitalManagementSystem.Application.Validators
{
    public class PatientCreateValidator : AbstractValidator<PatientCreateDto>
    {
        public PatientCreateValidator() 
        {
            RuleFor(x => x.TC)
                .NotEmpty().WithMessage("T.C. kimlik numarasi bos olamaz")
                .Length(11).WithMessage("T.C. kimlik numarasi 11 haneli olmali")
                .Matches("^[0-9]{11}$").WithMessage("T.C. kimlik numarasi sadece rakamlardan olusmali");

            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Isim bos olamaz")
                .MaximumLength(30).WithMessage("Isim en fazla 30 karakter olabilir");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Soyisim bos olamaz")
                .MaximumLength(20).WithMessage("Isim en fazla 20 karakter olabilir");

            RuleFor(x => x.Phone)
                .NotEmpty().WithMessage("Telefon numarasi bos olamaz")
                .Matches(@"^[0-9]{10}$").WithMessage("Gecerli bir telefon numarasi girin (basinda 0 olmadan)");

            RuleFor(x => x.Address)
                .NotEmpty().WithMessage("Adres bos olamaz")
                .MaximumLength(100).WithMessage("Adres en fazla 100 karakter olabilir");
        }
    }
}
