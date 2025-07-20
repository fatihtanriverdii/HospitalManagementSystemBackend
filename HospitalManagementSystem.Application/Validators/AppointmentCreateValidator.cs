using FluentValidation;
using HospitalManagementSystem.Application.DTOs;

namespace HospitalManagementSystem.Application.Validators
{
    public class AppointmentCreateValidator : AbstractValidator<AppointmentCreateDto>
    {
        public AppointmentCreateValidator() 
        {
            RuleFor(x => x.PatientId)
                .GreaterThan(0).WithMessage("Gecerli bir hasta secmelisiniz");

            RuleFor(x => x.DoctorId)
                .GreaterThan(0).WithMessage("Gecerli doktor secmelisiniz");

            RuleFor(x => x.Date)
                .GreaterThanOrEqualTo(DateOnly.FromDateTime(DateTime.Now)).WithMessage("Kayit tarihi bugun veya bugunden sonraki bir tarih olmali");
        }
    }
}
