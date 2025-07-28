using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Core.Interfaces.Repositories
{
	public interface IAppointmentRepository
	{
		Task<Appointment> GetByIdAsync(long id);
		Task<IEnumerable<Appointment>> ListAllAsync();
		Task AddAsync(Appointment appointment);
		Task<List<Appointment>> ListAllByPatientIdAsync(long patientId);
		IQueryable<Appointment> QueryByPatient(long patientId);
        Task<List<Appointment>> ListAllByDoctorAndDateAsync(long doctorId, DateOnly dateOnly);
        Task<long> SaveChangesAsync();
    }
}