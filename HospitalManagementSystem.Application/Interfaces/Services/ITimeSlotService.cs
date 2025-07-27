using HospitalManagementSystem.Application.DTOs;

namespace HospitalManagementSystem.Application.Interfaces.Services
{
    public interface ITimeSlotService
    {
        Task<TimeSlotDto> GetByTimeAsync(TimeOnly time);
        Task<List<TimeSlotDto>> GetAllAsync();
    }
}
