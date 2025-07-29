namespace HospitalManagementSystem.Application.DTOs
{
    public class AvailableAppointmentDto
    {
        public DateOnly Date { get; set; }
        public List<TimeOnly> Time { get; set; } = new List<TimeOnly>();
    }
}
