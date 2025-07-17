using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Interfaces.Repositories;
using HospitalManagementSystem.Core.Interfaces.Services;
using HospitalManagementSystem.Infrastructure.Data;

namespace HospitalManagementSystem.Infrastructure.Services
{
	public class EfRegistrationService : IRegistrationService
	{
		private readonly IRegistrationRepository _registrationRepo;
		private readonly IPatientService _patientService;
		private readonly AppDbContext _context;

		public EfRegistrationService(IRegistrationRepository registrationRepo, IPatientService patientService , AppDbContext context)
		{
			_registrationRepo = registrationRepo;
			_patientService = patientService;
			_context = context;
		}

		public async Task CreateAsync(Registration registration)
		{
			await _registrationRepo.AddAsync(registration);
			await _context.SaveChangesAsync();
		}

		public async Task<IEnumerable<Registration>> GetAllAsync()
		{
			return await _registrationRepo.ListAllAsync();
		}

		public async Task<IEnumerable<Registration>> GetAllByPatientAsync(string tc)
		{
			var patient = await _patientService.GetByTCAsync(tc);
			return await _registrationRepo.ListByPatientIdAsync(patient.Id);
		}

		public async Task<Registration> GetByIdAsync(long id)
		{
			return await _registrationRepo.GetByIdAsync(id);
		}
	}
}
