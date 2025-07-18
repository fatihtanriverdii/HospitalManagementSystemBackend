using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Core.Interfaces.Repositories
{
	public interface IUserRepository
	{
		Task<User> GetUserByIdAsync(long id);
		Task<IEnumerable<User>> ListAllUsersAsync();
		Task AddAsync(User user);
		void Update(User user);
		void Delete(User user);
        Task<long> SaveChangesAsync();
    }
}