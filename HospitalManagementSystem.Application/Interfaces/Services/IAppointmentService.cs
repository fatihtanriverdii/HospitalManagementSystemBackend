﻿using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Application.Interfaces.Services
{
	public interface IAppointmentService
	{
		Task<AppointmentDto> GetByIdAsync(long id);
		Task<IEnumerable<Appointment>> GetAllAsync();
		Task<IEnumerable<Appointment>> GetAllByPatientAsync(string tc);
		Task<List<AppointmentDto>> GetAllByPatientIdAsync(long id);
		Task<List<AppointmentHistoryDto>> GetAllPatientHistoryAsync(long patientId);
        Task<List<AppointmentDto>> GetAllByDoctorAndDateAsync(long id, DateOnly dateOnly);
		Task<bool> CheckConflickAsync(long doctorId, DateOnly dateOnly, TimeOnly newStart);
        Task<AppointmentDto> CreateAsync(AppointmentCreateDto appointmentCreateDto);

    }
}