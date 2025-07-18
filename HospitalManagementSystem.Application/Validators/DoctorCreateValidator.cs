using FluentValidation;
using HospitalManagementSystem.Application.DTOs;

namespace HospitalManagementSystem.Application.Validators
{
    public class DoctorCreateValidator : AbstractValidator<DoctorCreateDto>
    {
        public DoctorCreateValidator() 
        {
            RuleFor(x => x.Name)
                .NotEmpty().WithMessage("Isim bos olamaz")
                .MaximumLength(30).WithMessage("Isim en fazla 30 karakter olabilir");

            RuleFor(x => x.Surname)
                .NotEmpty().WithMessage("Soyisim bos olamaz")
                .MaximumLength(20).WithMessage("Soyisim en fazla 20 karakter olabilir");

            RuleFor(x => x.DepartmentId)
                .GreaterThan(0).WithMessage("Gecerli bir departman secmelisiniz");

        }
    }
}
