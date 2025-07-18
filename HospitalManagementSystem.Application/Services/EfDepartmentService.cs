using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Interfaces.Repositories;
using HospitalManagementSystem.Application.Interfaces.Services;

namespace HospitalManagementSystem.Infrastructure.Services
{
	public class EfDepartmentService : IDepartmentService
	{
		private readonly IDepartmentRepository _departmentRepo;

		public EfDepartmentService(IDepartmentRepository departmentRepo)
		{
			_departmentRepo = departmentRepo;
		}

		public async Task CreateAsync(Department department)
		{
			await _departmentRepo.AddAsync(department);
			await _departmentRepo.SaveChangesAsync();
		}

		public async Task DeleteAsync(long id)
		{
			var department = await _departmentRepo.GetByIdAsync(id);
			if (department == null)
			{
				throw new KeyNotFoundException("Department not found");
			}
			_departmentRepo.Delete(department);
			await _departmentRepo.SaveChangesAsync();
		}

		public async Task<IEnumerable<Department>> GetAllAsync()
		{
			return await _departmentRepo.ListAllAsync();
		}

		public async Task<Department> GetByIdAsync(long id)
		{
			return await _departmentRepo.GetByIdAsync(id);
		}

		public async Task UpdateAsync(Department department)
		{
			_departmentRepo.Update(department);
			await _departmentRepo.SaveChangesAsync();
		}
	}
}
