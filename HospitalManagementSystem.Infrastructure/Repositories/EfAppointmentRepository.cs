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

		public async Task<List<Appointment>> ListAllByPatientIdAsync(long patientId)
		{
			return await _context.Appointments
								.Where(a => a.PatientId == patientId)
								.Include(a => a.Doctor)
								.Include(a => a.TimeSlot)
								.OrderByDescending(a => a.Date)
								.ToListAsync();
		}

		public IQueryable<Appointment> QueryByPatient(long patientId)
		{
			return _context.Appointments
							.Where(a => a.PatientId == patientId);
		}

        public async Task<List<Appointment>> ListAllByDoctorAndDateAsync(long doctorId, DateOnly dateOnly)
        {
			return await _context.Appointments
								.Where(a => a.DoctorId == doctorId && a.Date == dateOnly)
								.Include(a => a.TimeSlot)
								.ToListAsync();
        }

        public async Task<long> SaveChangesAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
