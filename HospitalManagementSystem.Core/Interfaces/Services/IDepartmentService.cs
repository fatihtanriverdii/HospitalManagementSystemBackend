using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Core.Interfaces.Services
{
	public interface IDepartmentService
	{
		Task<Department> GetByIdAsync(long id);
		Task<IEnumerable<Department>> GetAllAsync();
		Task CreateAsync(Department department);
		Task UpdateAsync(Department department);
		Task DeleteAsync(long id);
	}
}