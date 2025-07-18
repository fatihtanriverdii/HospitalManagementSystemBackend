using FluentValidation;
using HospitalManagementSystem.Application.DTOs;

namespace HospitalManagementSystem.Application.Validators
{
    public class RegistrationCreateValidator : AbstractValidator<RegistrationCreateDto>
    {
        public RegistrationCreateValidator() 
        {
            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("Gecerli bir hasta secmelisiniz");

            RuleFor(x => x.DoctorId)
                .GreaterThan(0).WithMessage("Gecerli doktor secmelisiniz");

            RuleFor(x => x.CreatedAt)
                .GreaterThanOrEqualTo(DateTime.Now).WithMessage("Kayit tarihi bugun veya bugunden sonraki bir tarih olmali");
        }
    }
}
