using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Core.Entities
{
	public class Department
	{
		public long Id { get; set; }
		[StringLength(50)]
		[Column(TypeName = "varchar(50)")]
		public string Name { get; set; } = null!;

		public ICollection<Doctor> Doctors { get; set; } = new List<Doctor>();
	}
}
