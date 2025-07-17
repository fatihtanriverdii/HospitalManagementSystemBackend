using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Interfaces.Repositories;
using HospitalManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Repositories
{
	public class EfPatientRepository : IPatientRepository
	{
		private readonly AppDbContext _context;

		public EfPatientRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Patient patient)
		{
			await _context.Patients.AddAsync(patient);
		}

		public void Delete(Patient patient)
		{
			_context.Patients.Remove(patient);
		}

		public async Task<Patient> GetByIdAsync(long id)
		{
			return await _context.Patients.FindAsync(id);
		}

		public async Task<Patient> GetByTCAsync(string tc)
		{
			return await _context.Patients.FirstOrDefaultAsync(p => p.TC == tc);
		}

		public async Task<IEnumerable<Patient>> ListAllAsync()
		{
			return await _context.Patients.ToListAsync();
		}

		public void Update(Patient patient)
		{
			_context.Patients.Update(patient);
		}
	}
}
