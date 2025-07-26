using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Enums;
using System.Text.Json.Serialization;

namespace HospitalManagementSystem.Application.DTOs
{
    public class AppointmentDto : AppointmentCreateDto
    {
        public long Id { get; set; }
        [JsonIgnore]
        public TimeSlot TimeSlot { get; set; }
        public AppointmentStatus Status { get; set; }
    }
}
