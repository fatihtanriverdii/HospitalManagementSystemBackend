using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Interfaces.Repositories;
using HospitalManagementSystem.Application.Interfaces.Services;

namespace HospitalManagementSystem.Infrastructure.Services
{
	public class EfDoctorService : IDoctorService
	{
		private readonly IDoctorRepository _doctorRepo;

		public EfDoctorService(IDoctorRepository doctorRepository)
		{
			_doctorRepo = doctorRepository;
		}

		public async Task CreateAsync(Doctor doctor)
		{
			await _doctorRepo.AddAsync(doctor);
			await _doctorRepo.SaveChangesAsync();
		}

		public async Task DeleteAsync(long id)
		{
			var doctor = await _doctorRepo.GetByIdAsync(id);
			if (doctor == null)
			{
				throw new KeyNotFoundException("Doctor not found");
			}
			_doctorRepo.Delete(doctor);
			await _doctorRepo.SaveChangesAsync();
		}

		public async Task<IEnumerable<Doctor>> GetAllAsync()
		{
			return await _doctorRepo.ListAllAsync();
		}

		public async Task<IEnumerable<Doctor>> GetByDepartmentAsync(long departmentId)
		{
			return await _doctorRepo.ListByDepartmentAsync(departmentId);
		}

		public async Task<Doctor> GetByIdAsync(long id)
		{
			return await _doctorRepo.GetByIdAsync(id);
		}

		public async Task UpdateAsync(Doctor doctor)
		{
			_doctorRepo.Update(doctor);
			await _doctorRepo.SaveChangesAsync();
		}
	}
}
