using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Interfaces.Repositories;
using HospitalManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Repositories
{
    public class EfTimeSlotRepository : ITimeSlotRepository
    {
        private readonly AppDbContext _context;

        public EfTimeSlotRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<TimeSlot> GetByTimeAsync(TimeOnly timeOnly)
        {
            return await _context.TimeSlots.FirstOrDefaultAsync(ts =>  ts.Time == timeOnly);
        }

        public async Task<List<TimeSlot>> ListAllAsync()
        {
            return await _context.TimeSlots.ToListAsync();
        }
    }
}
