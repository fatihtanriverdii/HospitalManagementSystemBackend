namespace HospitalManagementSystem.Application.DTOs
{
    public class AppointmentCreateDto
    {
        public long PatientId { get; set; }
        public long DoctorId { get; set; }
        public DateOnly Date { get; set; }
        public TimeSpan StartTime { get; set; }
    }
}
