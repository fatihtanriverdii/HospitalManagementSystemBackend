using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HospitalManagementSystem.Core.Entities
{
	public class Patient
	{
		public long Id { get; set; }
		[StringLength(11)]
		[Column(TypeName = "char(11)")]
		public string TC { get; set; } = null!;
		[StringLength(30)]
		[Column(TypeName = "varchar(30)")]
		public string Name { get; set; } = null!;
		[StringLength(20)]
		[Column(TypeName = "varchar(20)")]
		public string Surname { get; set; } = null!;
		[StringLength(11)]
		[Column(TypeName = "char(11)")]
		public string Phone { get; set; } = null!;
		[StringLength(100)]
		[Column(TypeName = "varchar(100)")]
		public string Address { get; set; } = null!;

		public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
	}
}
