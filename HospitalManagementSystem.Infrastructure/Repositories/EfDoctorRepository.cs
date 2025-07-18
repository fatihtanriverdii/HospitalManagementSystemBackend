using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Interfaces.Repositories;
using HospitalManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Repositories
{
	public class EfDoctorRepository : IDoctorRepository
	{
		private readonly AppDbContext _context;

		public EfDoctorRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Doctor doctor)
		{
			await _context.Doctors.AddAsync(doctor);
		}

		public void Delete(Doctor doctor)
		{
			_context.Doctors.Remove(doctor);
		}

		public async Task<Doctor> GetByIdAsync(long id)
		{
			return await _context.Doctors.FindAsync(id);
		}

		public async Task<IEnumerable<Doctor>> ListAllAsync()
		{
			return await _context.Doctors.ToListAsync();
		}

		public async Task<IEnumerable<Doctor>> ListByDepartmentAsync(long departmentId)
		{
			return await _context.Doctors
								.Where(d => d.DepartmentId == departmentId)
								.ToListAsync();
		}

        public async Task<long> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Update(Doctor doctor)
		{
			_context.Doctors.Update(doctor);
		}
	}
}
