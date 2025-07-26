namespace HospitalManagementSystem.Application.DTOs
{
    public class AppointmentHistoryDto
    {
        public string DoctorName { get; set; }
        public string DoctorSurname { get; set; }
        public string DepartmentName { get; set; }
        public DateOnly Date {  get; set; }
        public TimeOnly Time { get; set; }
    }
}