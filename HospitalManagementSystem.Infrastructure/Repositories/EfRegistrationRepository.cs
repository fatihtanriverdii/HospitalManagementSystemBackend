using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Interfaces.Repositories;
using HospitalManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Repositories
{
	public class EfRegistrationRepository : IRegistrationRepository
	{
		private readonly AppDbContext _context;

		public EfRegistrationRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Registration registration)
		{
			await _context.Registrations.AddAsync(registration);
		}

		public async Task<Registration> GetByIdAsync(long id)
		{
			return await _context.Registrations.FindAsync(id);
		}

		public async Task<IEnumerable<Registration>> ListAllAsync()
		{
			return await _context.Registrations
								.Include(r => r.Patient)
								.Include(r => r.Doctor)
								.ToListAsync();
		}

		public async Task<IEnumerable<Registration>> ListByPatientIdAsync(long patientId)
		{
			return await _context.Registrations
								.Include(r => r.Patient)
								.Include(r => r.Doctor)
								.Where(r => r.PatientId == patientId)
								.ToListAsync();
		}

        public async Task<long> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
