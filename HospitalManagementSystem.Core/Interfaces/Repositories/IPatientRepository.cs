using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Core.Interfaces.Repositories
{
	public interface IPatientRepository
	{
		Task<Patient> GetByIdAsync(long id);
		Task<Patient> GetByTCAsync(string tc);
		Task<IEnumerable<Patient>> ListAllAsync();
		Task AddAsync(Patient patient);
		void Update(Patient patient);
		void Delete(Patient patient);
		IQueryable<Patient> AsQueryable();
        Task<long> SaveChangesAsync();
    }
}