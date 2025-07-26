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
		private readonly IAppointmentService _appointmentService;
		private readonly ITimeSlotService _timeSlotService;
		private readonly IMapper _mapper;

		public EfDoctorService(IDoctorRepository doctorRepository, IAppointmentService appointmentService, ITimeSlotService timeSlotService, IMapper mapper)
		{
			_doctorRepo = doctorRepository;
			_appointmentService = appointmentService;
			_timeSlotService = timeSlotService;
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

		public async Task<List<DoctorDto>> GetAllAsync()
		{
			var doctors = await _doctorRepo.ListAllAsync();
			if (doctors == null)
				return null;
			return _mapper.Map<List<DoctorDto>>(doctors);
		}

		public async Task<IEnumerable<Doctor>> GetByDepartmentAsync(long departmentId)
		{
			return await _doctorRepo.ListByDepartmentAsync(departmentId);
		}

		public async Task<List<TimeSlotDto>> GetAvailableTimeSlotsAsync(long doctorId, DateOnly date)
		{
			var appList = await _appointmentService.GetAllByDoctorAndDateAsync(doctorId, date);
			var timeSlots = await _timeSlotService.GetAllAsync();
			List<TimeSlot> busyTimeSlots = new List<TimeSlot>();

			foreach (var appointment in appList)
			{
				busyTimeSlots.Add(appointment.TimeSlot);
			}

			var availableTimeSlots = await _doctorRepo.ListAvailableTimeSlotsAsync(busyTimeSlots);

			if(date == DateOnly.FromDateTime(DateTime.Now))
			{
				List<TimeSlot> todayAvailableTimeSlot = new List<TimeSlot>();
				foreach (var availableTimeSlot in availableTimeSlots)
				{
					if (availableTimeSlot.Time > TimeOnly.FromDateTime(DateTime.Now))
						todayAvailableTimeSlot.Add(availableTimeSlot);
				}
				return _mapper.Map<List<TimeSlotDto>>(todayAvailableTimeSlot);
			}

			return _mapper.Map<List<TimeSlotDto>>(availableTimeSlots);
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
