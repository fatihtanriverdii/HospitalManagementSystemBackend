using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Application.Interfaces.Services
{
	public interface IPatientService
	{
		Task<Patient> GetByIdAsync(long id);
		Task<Patient> GetByTCAsync(string tc);
		Task<IEnumerable<Patient>> GetAllAsync();
		Task CreateAsync(Patient patient);
		Task UpdateAsync(Patient patient);
		Task DeleteAsync(long id);
	}
}
