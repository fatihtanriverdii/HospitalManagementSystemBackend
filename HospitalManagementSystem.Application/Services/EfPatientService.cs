using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Interfaces.Repositories;
using HospitalManagementSystem.Application.Interfaces.Services;
using HospitalManagementSystem.Application.DTOs;
using AutoMapper;

namespace HospitalManagementSystem.Infrastructure.Services
{
	public class EfPatientService : IPatientService
	{
		private readonly IPatientRepository _patientRepo;
		private readonly IMapper _mapper;

		public EfPatientService(IPatientRepository patientRepo, IMapper mapper)
		{
			_patientRepo = patientRepo;
			_mapper = mapper;
		}

		public async Task<PatientDto> CreateAsync(PatientCreateDto patientCreateDto)
		{
			if(await CheckTCExistAsync(patientCreateDto.TC))
			{
				return null;
			}

			Patient patient = _mapper.Map<Patient>(patientCreateDto);
			await _patientRepo.AddAsync(patient);
			await _patientRepo.SaveChangesAsync();

			return _mapper.Map<PatientDto>(patient);
		}

		public async Task DeleteAsync(long id)
		{
			var patient = await _patientRepo.GetByIdAsync(id);
			if (patient == null)
			{
				throw new KeyNotFoundException("Patient not found");
			}
			_patientRepo.Delete(patient);
			await _patientRepo.SaveChangesAsync();
		}

		public async Task<List<PatientDto>> GetAllAsync()
		{
			var patientList = await _patientRepo.ListAllAsync();
			if (patientList == null)
				return null;
			var patientsDto = _mapper.Map<List<PatientDto>>(patientList);
			return patientsDto;
		}

		public async Task<PatientDto> GetByIdAsync(long id)
		{
			var patient = await _patientRepo.GetByIdAsync(id);
			if (patient == null)
				return null;
			var patientDto = _mapper.Map<PatientDto>(patient);
			return patientDto;
		}

		public async Task<Patient> GetByTCAsync(string tc)
		{
			return await _patientRepo.GetByTCAsync(tc);
		}

		public async Task UpdateAsync(Patient patient)
		{
			_patientRepo.Update(patient);
			await _patientRepo.SaveChangesAsync();
		}

		public async Task<bool> CheckTCExistAsync(string tc)
		{
			var patient = await _patientRepo.GetByTCAsync(tc);
			if (patient == null)
				return false;
			return true;
		}
	}
}
