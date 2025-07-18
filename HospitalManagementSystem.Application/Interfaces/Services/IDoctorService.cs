using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Application.Interfaces.Services
{
	public interface IDoctorService
	{
		Task<Doctor> GetByIdAsync(long id);
		Task<IEnumerable<Doctor>> GetAllAsync();
		Task<IEnumerable<Doctor>> GetByDepartmentAsync(long departmentId);
		Task CreateAsync(Doctor doctor);
		Task UpdateAsync(Doctor doctor);
		Task DeleteAsync(long id);
	}
}