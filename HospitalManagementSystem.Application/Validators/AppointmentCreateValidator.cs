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

            RuleFor(x => x.Time)
                .InclusiveBetween(new TimeOnly(8,0), new TimeOnly(17,0))
                .Must(t => t.Minute == 0 || t.Minute == 30)
                .WithMessage("Randevu saatleri 08:00 - 17:00 arasi sadece tam saat (00) veya bucuk saat (30) diliminde olmalidir.");
        }
    }
}
