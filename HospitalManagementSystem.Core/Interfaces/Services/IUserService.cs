using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Core.Interfaces.Services
{
	public interface IUserService
	{
		Task<User> GetByIdAsync(long id);
		Task<IEnumerable<User>> GetAllAsync();
		Task CreateAsync(User user);
		Task UpdateAsync(User user);
		Task DeleteAsync(long id);
	}
}