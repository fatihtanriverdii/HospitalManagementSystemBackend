using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Core.Interfaces.Repositories
{
	public interface IRegistrationRepository
	{
		Task<Registration> GetByIdAsync(long id);
		Task<IEnumerable<Registration>> ListAllAsync();
		Task<IEnumerable<Registration>> ListByPatientIdAsync(long patientId);
		Task AddAsync(Registration registration);
	}
}