using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Interfaces.Repositories;
using HospitalManagementSystem.Application.Interfaces.Services;
using HospitalManagementSystem.Application.DTOs;
using AutoMapper;

namespace HospitalManagementSystem.Infrastructure.Services
{
	public class EfAppointmentService : IAppointmentService
	{
		private readonly IAppointmentRepository _appointmentRepo;
		private readonly IPatientService _patientService;
		private readonly IMapper _mapper;

		public EfAppointmentService(IAppointmentRepository registrationRepo, IPatientService patientService, IMapper mapper)
		{
            _appointmentRepo = registrationRepo;
			_patientService = patientService;
			_mapper = mapper;
		}

		public async Task<AppointmentDto> CreateAsync(AppointmentCreateDto appointmentCreateDto)
		{
			var appointment = _mapper.Map<Appointment>(appointmentCreateDto);
			await _appointmentRepo.AddAsync(appointment);
			await _appointmentRepo.SaveChangesAsync();

			return _mapper.Map<AppointmentDto>(appointment);
		}

		public async Task<IEnumerable<Appointment>> GetAllAsync()
		{
			return await _appointmentRepo.ListAllAsync();
		}

		public async Task<List<AppointmentDto>> GetByDoctorAndDateAsync(long id, DateOnly dateOnly)
		{
			var appList = await _appointmentRepo.ListByDoctorAndDateAsync(id, dateOnly);

			return _mapper.Map<List<AppointmentDto>>(appList);
		}

		public async Task<bool> CheckConflickAsync(long doctorId, DateOnly dateOnly, TimeSpan newStart)
		{
			var appList = await GetByDoctorAndDateAsync(doctorId, dateOnly);
			var busy = newStart - TimeSpan.FromMinutes(30);
			var busy2 = newStart + TimeSpan.FromMinutes(30);

			foreach (var app in appList)
			{
				if (busy2 > app.StartTime && app.StartTime > busy)
				{
					return true;
				}
			}
			return false;
		}

		public async Task<IEnumerable<Appointment>> GetAllByPatientAsync(string tc)
		{
			var patient = await _patientService.GetByTCAsync(tc);
			return await _appointmentRepo.ListByPatientIdAsync(patient.Id);
		}

		public async Task<AppointmentDto> GetByIdAsync(long id)
		{
			var app = await _appointmentRepo.GetByIdAsync(id);
			if (app == null)
				return null;
            return _mapper.Map<AppointmentDto>(app); 
		}
	}
}
