using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Interfaces.Repositories;
using HospitalManagementSystem.Application.Interfaces.Services;
using HospitalManagementSystem.Application.DTOs;
using AutoMapper;

namespace HospitalManagementSystem.Infrastructure.Services
{
	public class EfDoctorService : IDoctorService
	{
		private readonly IDoctorRepository _doctorRepo;
		private readonly IMapper _mapper;

		public EfDoctorService(IDoctorRepository doctorRepository, IMapper mapper)
		{
			_doctorRepo = doctorRepository;
			_mapper = mapper;
		}

		public async Task<DoctorDto> CreateAsync(DoctorCreateDto doctorCreateDto)
		{
			var doctor = _mapper.Map<Doctor>(doctorCreateDto);
			await _doctorRepo.AddAsync(doctor);
			await _doctorRepo.SaveChangesAsync();

			return _mapper.Map<DoctorDto>(doctor);
		}

		public async Task DeleteAsync(long id)
		{
			var doctor = await _doctorRepo.GetByIdAsync(id);
			if (doctor == null)
			{
				throw new KeyNotFoundException("Doctor not found");
			}
			_doctorRepo.Delete(doctor);
			await _doctorRepo.SaveChangesAsync();
		}

		public async Task<IEnumerable<Doctor>> GetAllAsync()
		{
			return await _doctorRepo.ListAllAsync();
		}

		public async Task<IEnumerable<Doctor>> GetByDepartmentAsync(long departmentId)
		{
			return await _doctorRepo.ListByDepartmentAsync(departmentId);
		}

		public async Task<DoctorDto> GetByIdAsync(long id)
		{
			var doctor = await _doctorRepo.GetByIdAsync(id);
			if (doctor == null)
				return null;
			return _mapper.Map<DoctorDto>(doctor);
		}

		public async Task UpdateAsync(Doctor doctor)
		{
			_doctorRepo.Update(doctor);
			await _doctorRepo.SaveChangesAsync();
		}
	}
}
