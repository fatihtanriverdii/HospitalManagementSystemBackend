using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Application.Interfaces.Services
{
	public interface IPatientService
	{
		Task<PatientDto> GetByIdAsync(long id);
		Task<PatientDto> GetByTCAsync(string tc);
		Task<List<PatientDto>> GetAllAsync();
		Task<PatientDto> CreateAsync(PatientCreateDto patientCreateDto);
		Task UpdateAsync(Patient patient);
		Task DeleteAsync(long id);
		Task<bool> CheckTCExistAsync(string tc);

    }
}
