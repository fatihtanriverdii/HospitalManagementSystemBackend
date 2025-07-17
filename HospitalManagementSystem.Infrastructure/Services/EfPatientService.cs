using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Interfaces.Repositories;
using HospitalManagementSystem.Core.Interfaces.Services;
using HospitalManagementSystem.Infrastructure.Data;

namespace HospitalManagementSystem.Infrastructure.Services
{
	public class EfPatientService : IPatientService
	{
		private readonly IPatientRepository _patientRepo;
		private readonly AppDbContext _context;

		public EfPatientService(IPatientRepository patientRepo, AppDbContext context)
		{
			_patientRepo = patientRepo;
			_context = context;
		}

		public async Task CreateAsync(Patient patient)
		{
			await _patientRepo.AddAsync(patient);
			await _context.SaveChangesAsync();
		}

		public async Task DeleteAsync(long id)
		{
			var patient = await _patientRepo.GetByIdAsync(id);
			if (patient == null)
			{
				throw new KeyNotFoundException("Patient not found");
			}
			_patientRepo.Delete(patient);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Patient>> GetAllAsync()
		{
			return await _patientRepo.ListAllAsync();
		}

		public async Task<Patient> GetByIdAsync(long id)
		{
			return await _patientRepo.GetByIdAsync(id);
		}

		public async Task<Patient> GetByTCAsync(string tc)
		{
			return await _patientRepo.GetByTCAsync(tc);
		}

		public async Task UpdateAsync(Patient patient)
		{
			_patientRepo.Update(patient);
			await _context.SaveChangesAsync();
		}
	}
}
