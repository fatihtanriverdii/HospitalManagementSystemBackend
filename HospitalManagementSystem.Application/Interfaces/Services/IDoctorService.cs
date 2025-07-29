using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Shared.DTOs.Paging;

namespace HospitalManagementSystem.Application.Interfaces.Services
{
	public interface IDoctorService
	{
		Task<DoctorDto> GetByIdAsync(long id);
        Task<List<DoctorDto>> GetAllAsync();
        Task<PagedResponseDto<DoctorDto>> GetAllWithPaginationAsync(int pageNumber, int pageSize);
        Task<DoctorDto> CreateAsync(DoctorCreateDto doctorCreateDto);
        Task UpdateAsync(Doctor doctor);
		Task<List<TimeSlotDto>> GetAvailableTimeSlotsAsync(long doctorId, DateOnly date);
        Task DeleteAsync(long id);
	}
}