using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Interfaces.Repositories;
using HospitalManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Repositories
{
	public class EfUserRepository : IUserRepository
	{
		private readonly AppDbContext _context;

		public EfUserRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(User user)
		{
			await _context.Users.AddAsync(user);
		}

		public void Delete(User user)
		{
			_context.Users.Remove(user);
		}

		public async Task<User> GetUserByIdAsync(long id)
		{
			return await _context.Users.FindAsync(id);
		}

		public async Task<IEnumerable<User>> ListAllUsersAsync()
		{
			return await _context.Users.ToListAsync();
		}

		public void Update(User user)
		{
			_context.Users.Update(user);
		}
	}
}
