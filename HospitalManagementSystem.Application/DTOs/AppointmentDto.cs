using HospitalManagementSystem.Core.Enums;

namespace HospitalManagementSystem.Application.DTOs
{
    public class AppointmentDto : AppointmentCreateDto
    {
        public long Id { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}
