using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Application.Interfaces.Services
{
	public interface IDoctorService
	{
		Task<DoctorDto> GetByIdAsync(long id);
        Task<IEnumerable<Doctor>> GetAllAsync();
		Task<IEnumerable<Doctor>> GetByDepartmentAsync(long departmentId);
		Task<DoctorDto> CreateAsync(DoctorCreateDto doctorCreateDto);
        Task UpdateAsync(Doctor doctor);
		Task DeleteAsync(long id);
	}
}