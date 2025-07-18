namespace HospitalManagementSystem.Application.DTOs
{
    public class RegistrationCreateDto
    {
        public long PatientId { get; set; }
        public long DoctorId { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
