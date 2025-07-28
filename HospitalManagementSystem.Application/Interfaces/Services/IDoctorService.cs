using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Application.Interfaces.Services
{
	public interface IDoctorService
	{
		Task<DoctorDto> GetByIdAsync(long id);
        Task<List<DoctorDto>> GetAllAsync();
		Task<DoctorDto> CreateAsync(DoctorCreateDto doctorCreateDto);
        Task UpdateAsync(Doctor doctor);
		Task<List<TimeSlotDto>> GetAvailableTimeSlotsAsync(long doctorId, DateOnly date);
        Task DeleteAsync(long id);
	}
}