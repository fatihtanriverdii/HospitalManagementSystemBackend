using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Interfaces.Repositories;
using HospitalManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Repositories
{
	public class EfDepartmentRepository : IDepartmentRepository
	{
		private readonly AppDbContext _context;

		public EfDepartmentRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Department department)
		{
			await _context.Departments.AddAsync(department);
		}

		public void Delete(Department department)
		{
			_context.Departments.Remove(department);
		}

		public async Task<IEnumerable<Department>> ListAllAsync()
		{
			return await _context.Departments.ToListAsync();
		}

		public async Task<List<Department>> ListAllWithPagination(int pageNumber, int pageSize)
		{
			return await _context.Departments
				.OrderBy(d => d.Name)
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.AsNoTracking()
				.ToListAsync();
		}

		public async Task<int> GetCountAsync()
		{
			return await _context.Departments .CountAsync();
		}

		public async Task<Department> GetByIdAsync(long id)
		{
			return await _context.Departments.FindAsync(id);
		}

		public void Update(Department department)
		{
			_context.Departments.Update(department);
		}

        public async Task<long> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
