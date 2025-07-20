using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Interfaces.Repositories;
using HospitalManagementSystem.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace HospitalManagementSystem.Infrastructure.Repositories
{
	public class EfAppointmentRepository : IAppointmentRepository
	{
		private readonly AppDbContext _context;

		public EfAppointmentRepository(AppDbContext context)
		{
			_context = context;
		}

		public async Task AddAsync(Appointment registration)
		{
			await _context.Appointments.AddAsync(registration);
		}

		public async Task<Appointment> GetByIdAsync(long id)
		{
			return await _context.Appointments.FindAsync(id);
		}

		public async Task<IEnumerable<Appointment>> ListAllAsync()
		{
			return await _context.Appointments
								.Include(r => r.Patient)
								.Include(r => r.Doctor)
								.ToListAsync();
		}

        public async Task<List<Appointment>> ListByDoctorAndDateAsync(long doctorId, DateOnly dateOnly)
        {
			return await _context.Appointments
								.Where(a => a.DoctorId == doctorId && a.Date == dateOnly)
								.ToListAsync();
        }

        public async Task<IEnumerable<Appointment>> ListByPatientIdAsync(long patientId)
		{
			return await _context.Appointments
								.Include(r => r.Patient)
								.Include(r => r.Doctor)
								.Where(r => r.PatientId == patientId)
								.ToListAsync();
		}

        public async Task<long> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
