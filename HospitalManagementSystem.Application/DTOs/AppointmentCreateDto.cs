using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Application.DTOs
{
    public class AppointmentCreateDto
    {
        public long PatientId { get; set; }
        public long DoctorId { get; set; }
        public DateOnly Date { get; set; }
        public TimeOnly Time { get; set; }
    }
}
