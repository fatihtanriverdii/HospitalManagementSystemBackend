using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Shared.DTOs.Paging;

namespace HospitalManagementSystem.Application.Interfaces.Services
{
	public interface IAppointmentService
	{
		Task<AppointmentDto> GetByIdAsync(long id);
		Task<List<AppointmentDto>> GetAllAsync();
		Task<IEnumerable<Appointment>> GetAllByPatientAsync(string tc);
		Task<List<AppointmentDto>> GetAllByPatientIdAsync(long id);
		Task<PagedResponseDto<AppointmentHistoryDto>> GetAllPatientHistoryAsync(long patientId, int pageNumber, int pageSize);
        Task<List<AppointmentDto>> GetAllByDoctorAndDateAsync(long id, DateOnly dateOnly);
		Task<bool> CheckConflickAsync(long doctorId, DateOnly dateOnly, TimeOnly newStart);
        Task<AppointmentDto> CreateAsync(AppointmentCreateDto appointmentCreateDto);

    }
}