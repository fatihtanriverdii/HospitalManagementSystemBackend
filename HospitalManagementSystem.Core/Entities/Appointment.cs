using HospitalManagementSystem.Core.Enums;

namespace HospitalManagementSystem.Core.Entities
{
	public class Appointment
	{
		public long Id { get; set; }
		public long PatientId { get; set; }
		public Patient Patient { get; set; } = null!;
		public long DoctorId { get; set; }
		public Doctor Doctor { get; set; } = null!;
		public DateOnly Date { get; set; }
		public long TimeSlotId { get; set; }
		public TimeSlot TimeSlot { get; set; }
		public AppointmentStatus Status { get; set; } = AppointmentStatus.Pending;
		public DateTime CreatedAt { get; set; }
	}
}
