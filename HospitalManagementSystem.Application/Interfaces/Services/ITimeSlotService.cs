using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Application.Interfaces.Services
{
    public interface ITimeSlotService
    {
        Task<TimeSlotDto> GetByTimeAsync(TimeOnly time);
        Task<List<TimeSlotDto>> GetAllAsync();
    }
}
