using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Application.Interfaces.Services
{
	public interface IDepartmentService
	{
		Task<DepartmentDto> GetByIdAsync(long id);
		Task<List<DepartmentDto>> GetAllAsync();
		Task CreateAsync(Department department);
		Task UpdateAsync(Department department);
		Task DeleteAsync(long id);
	}
}