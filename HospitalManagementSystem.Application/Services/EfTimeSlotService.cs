using AutoMapper;
using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Application.Interfaces.Services;
using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Interfaces.Repositories;

namespace HospitalManagementSystem.Application.Services
{
    public class EfTimeSlotService : ITimeSlotService
    {
        private readonly ITimeSlotRepository _timeSlotRepo;
        private readonly IMapper _mapper;

        public EfTimeSlotService(ITimeSlotRepository timeSlotRepository, IMapper mapper)
        {
            _timeSlotRepo = timeSlotRepository;
            _mapper = mapper;
        }

        public async Task<List<TimeSlotDto>> GetAllAsync()
        {
            var timeSlots = await _timeSlotRepo.ListAllAsync();
            return _mapper.Map<List<TimeSlotDto>>(timeSlots);
        }

        public async Task<TimeSlotDto> GetByTimeAsync(TimeOnly time)
        {
            var timesSlot = await _timeSlotRepo.GetByTimeAsync(time);
            return _mapper.Map<TimeSlotDto>(timesSlot);
        }
    }
}
