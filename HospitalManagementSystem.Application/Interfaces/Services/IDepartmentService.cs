using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Shared.DTOs.Paging;

namespace HospitalManagementSystem.Application.Interfaces.Services
{
	public interface IDepartmentService
	{
		Task<DepartmentDto> GetByIdAsync(long id);
		Task<List<DepartmentDto>> GetAllAsync();
		Task<PagedResponseDto<DepartmentDto>> GetAllWithPagination(int pageNumber, int pageSize);
        Task CreateAsync(Department department);
		Task UpdateAsync(Department department);
		Task DeleteAsync(long id);
	}
}