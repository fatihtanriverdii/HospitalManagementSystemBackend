using HospitalManagementSystem.Core.Enums;

namespace HospitalManagementSystem.Application.DTOs
{
    public class UserDto : UserCreateDto
    {
        public long Id { get; set; }
        public Role Role { get; set; }
    }
}
