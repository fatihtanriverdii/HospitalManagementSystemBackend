using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Core.Interfaces.Services
{
	public interface IRegistrationService
	{
		Task<Registration> GetByIdAsync(long id);
		Task<IEnumerable<Registration>> GetAllAsync();
		Task<IEnumerable<Registration>> GetAllByPatientAsync(string tc);
		Task CreateAsync(Registration registration);
	}
}