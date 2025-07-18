using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Interfaces.Repositories;
using HospitalManagementSystem.Application.Interfaces.Services;

namespace HospitalManagementSystem.Infrastructure.Services
{
	public class EfPatientService : IPatientService
	{
		private readonly IPatientRepository _patientRepo;

		public EfPatientService(IPatientRepository patientRepo)
		{
			_patientRepo = patientRepo;
		}

		public async Task CreateAsync(Patient patient)
		{
			await _patientRepo.AddAsync(patient);
			await _patientRepo.SaveChangesAsync();
		}

		public async Task DeleteAsync(long id)
		{
			var patient = await _patientRepo.GetByIdAsync(id);
			if (patient == null)
			{
				throw new KeyNotFoundException("Patient not found");
			}
			_patientRepo.Delete(patient);
			await _patientRepo.SaveChangesAsync();
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
			await _patientRepo.SaveChangesAsync();
		}
	}
}
