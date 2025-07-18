namespace HospitalManagementSystem.Application.DTOs
{
    public class PatientDto : PatientCreateDto
    {
        public long Id { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
