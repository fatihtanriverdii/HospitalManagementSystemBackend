using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Core.Interfaces.Repositories
{
	public interface IDepartmentRepository
	{
		Task<Department> GetByIdAsync(long id);
		Task<IEnumerable<Department>> ListAllAsync();
		Task<List<Department>> ListAllWithPagination(int pageNumber, int pageSize);
		Task<int> GetCountAsync();
        Task AddAsync(Department department);
		void Update(Department department);
		void Delete(Department department);
		Task<long> SaveChangesAsync();
	}
}