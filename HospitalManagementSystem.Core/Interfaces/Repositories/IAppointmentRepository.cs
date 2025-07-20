using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Core.Interfaces.Repositories
{
	public interface IAppointmentRepository
	{
		Task<Appointment> GetByIdAsync(long id);
		Task<IEnumerable<Appointment>> ListAllAsync();
		Task<IEnumerable<Appointment>> ListByPatientIdAsync(long patientId);
		Task AddAsync(Appointment registration);
        Task<List<Appointment>> ListByDoctorAndDateAsync(long doctorId, DateOnly dateOnly);
        Task<long> SaveChangesAsync();
    }
}