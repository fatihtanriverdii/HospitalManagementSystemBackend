using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Interfaces.Repositories;
using HospitalManagementSystem.Application.Interfaces.Services;
using HospitalManagementSystem.Application.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using HospitalManagementSystem.Shared.Exceptions;
using HospitalManagementSystem.Shared.DTOs.Paging;

namespace HospitalManagementSystem.Application.Services
{
	public class EfAppointmentService : IAppointmentService
	{
		private readonly IAppointmentRepository _appointmentRepo;
		private readonly IPatientService _patientService;
		private readonly ITimeSlotService _timeSlotService;
		private readonly IMapper _mapper;

		public EfAppointmentService(IAppointmentRepository appointmentRepo, IPatientService patientService, ITimeSlotService timeSlotService, IMapper mapper)
		{
            _appointmentRepo = appointmentRepo;
			_patientService = patientService;
			_timeSlotService = timeSlotService;
			_mapper = mapper;
		}

		public async Task<AppointmentDto> CreateAsync(AppointmentCreateDto appointmentCreateDto)
		{
			var appointment = _mapper.Map<Appointment>(appointmentCreateDto);

			var slot = await _timeSlotService.GetByTimeAsync(appointmentCreateDto.Time);

			if (slot == null)
				throw new NotFoundException("Girilen saate ait TimeSlot bulunamadi.");

			appointment.TimeSlotId = slot.Id;

			await _appointmentRepo.AddAsync(appointment);
			await _appointmentRepo.SaveChangesAsync();

			return _mapper.Map<AppointmentDto>(appointment);
		}

		public async Task<List<AppointmentDto>> GetAllAsync()
		{
			var appList = await _appointmentRepo.ListAllAsync();
			return _mapper.Map<List<AppointmentDto>>(appList);
		}

		public async Task<List<AppointmentDto>> GetAllByDoctorAndDateAsync(long id, DateOnly dateOnly)
		{
			var appList = await _appointmentRepo.ListAllByDoctorAndDateAsync(id, dateOnly);

			return _mapper.Map<List<AppointmentDto>>(appList);
		}

		public async Task<bool> CheckConflickAsync(long doctorId, DateOnly dateOnly, TimeOnly newStart)
		{
			var appList = await GetAllByDoctorAndDateAsync(doctorId, dateOnly);

			foreach (var app in appList)
			{
				if (app.Time == newStart)
				{
					return true;
				}
			}
			return false;
		}

		public async Task<List<AppointmentDto>> GetAllByPatientIdAsync(long id)
		{
			var appList = await _appointmentRepo.ListAllByPatientIdAsync(id);
			return _mapper.Map<List<AppointmentDto>>(appList);
		}

		public async Task<PagedResponseDto<AppointmentHistoryDto>> GetAllPatientHistoryAsync(long patientId, int pageNumber, int pageSize)
		{
			var query = _appointmentRepo
				.QueryByPatient(patientId)
				.Include(a => a.Doctor)
					.ThenInclude(d => d.Department)
				.Include(a => a.TimeSlot)
				.OrderByDescending(a => a.Date)
				.ThenBy(a => a.TimeSlot.Time)
				.AsNoTracking();

			var totalCount = await query.CountAsync();

			var data = await query
				.Skip((pageNumber - 1) * pageSize)
				.Take(pageSize)
				.Select(a => new AppointmentHistoryDto
				{
					DoctorName = a.Doctor.Name,
					DoctorSurname = a.Doctor.Surname,
					DepartmentName = a.Doctor.Department.Name,
					Date = a.Date,
					Time = a.TimeSlot.Time
				})
				.ToListAsync();


			return new PagedResponseDto<AppointmentHistoryDto>
			{
				Items = data,
				PageNumber = pageNumber,
				PageSize = pageSize,
				TotalCount = totalCount
			};
		}

		public async Task<IEnumerable<Appointment>> GetAllByPatientAsync(string tc)
		{
			var patient = await _patientService.GetByTCAsync(tc);
			return await _appointmentRepo.ListAllByPatientIdAsync(patient.Id);
		}

		public async Task<AppointmentDto> GetByIdAsync(long id)
		{
			var app = await _appointmentRepo.GetByIdAsync(id);
            return _mapper.Map<AppointmentDto>(app); 
		}
	}
}
