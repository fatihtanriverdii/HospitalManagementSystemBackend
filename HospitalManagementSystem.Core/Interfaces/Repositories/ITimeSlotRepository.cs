using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Core.Interfaces.Repositories
{
    public interface ITimeSlotRepository
    {
        Task<TimeSlot> GetByTimeAsync(TimeOnly timeOnly);
        Task<List<TimeSlot>> ListAllAsync();
    }
}
