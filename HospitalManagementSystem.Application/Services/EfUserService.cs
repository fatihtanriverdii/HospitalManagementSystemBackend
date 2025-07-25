﻿using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Interfaces.Repositories;
using HospitalManagementSystem.Application.Interfaces.Services;

namespace HospitalManagementSystem.Infrastructure.Services
{
	public class EfUserService : IUserService
	{
		private readonly IUserRepository _userRepo;

		public EfUserService(IUserRepository userRepo)
		{
			_userRepo = userRepo;
		}

		public async Task CreateAsync(User user)
		{
			await _userRepo.AddAsync(user);
			await _userRepo.SaveChangesAsync();
		}

		public async Task DeleteAsync(long id)
		{
			var user = await _userRepo.GetUserByIdAsync(id);
			if (user == null)
			{
				throw new KeyNotFoundException("User not found");
			}
			_userRepo.Delete(user);
			await _userRepo.SaveChangesAsync();
		}

		public async Task<IEnumerable<User>> GetAllAsync()
		{
			return await _userRepo.ListAllUsersAsync();
		}

		public async Task<User> GetByIdAsync(long id)
		{
			return await _userRepo.GetUserByIdAsync(id);
		}

		public async Task UpdateAsync(User user)
		{
			_userRepo.Update(user);
			await _userRepo.SaveChangesAsync();
		}
	}
}
