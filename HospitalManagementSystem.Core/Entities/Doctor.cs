using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Core.Entities
{
	public class Doctor
	{
		public long Id { get; set; }
		[StringLength(30)]
		[Column(TypeName = "varchar(30)")]
		public string Name { get; set; } = null!;
		[StringLength(20)]
		[Column(TypeName = "varchar(20)")]
		public string Surname { get; set; } = null!;
		public long DepartmentId { get; set; }
		public Department Department { get; set; } = null!;

		public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
	}
}
