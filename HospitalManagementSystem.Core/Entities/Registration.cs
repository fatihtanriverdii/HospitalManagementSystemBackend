namespace HospitalManagementSystem.Core.Entities
{
	public class Registration
	{
		public long Id { get; set; }

		public long PatientId { get; set; }
		public Patient Patient { get; set; } = null!;

		public long DoctorId { get; set; }
		public Doctor Doctor { get; set; } = null!;

		public DateTime CreatedAt { get; set; }
	}
}
