using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Core.Interfaces.Repositories
{
	public interface IDoctorRepository
	{
		Task<Doctor> GetByIdAsync(long id);
		Task<IEnumerable<Doctor>> ListAllAsync();
		Task AddAsync(Doctor doctor);
		void Update(Doctor doctor);
		void Delete(Doctor doctor);
		Task<IEnumerable<Doctor>> ListByDepartmentAsync(long departmentId);
        Task<long> SaveChangesAsync();
    }
}