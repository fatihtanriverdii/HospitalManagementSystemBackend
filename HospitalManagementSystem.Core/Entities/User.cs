using HospitalManagementSystem.Core.Enums;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HospitalManagementSystem.Core.Entities
{
	public class User
	{
		public long Id { get; set; }
		[StringLength(30)]
		[Column(TypeName = "varchar(30)")]
		public string Name { get; set; } = null!;
		[StringLength(20)]
		[Column(TypeName = "varchar(20)")]
		public string Surname { get; set; } = null!;
		[EmailAddress]
		[StringLength(75)]
		public string Email { get; set; } = null!;
		public string Password { get; set; } = null!;
		public Role Role { get; set; } = Role.USER;
	}
}
