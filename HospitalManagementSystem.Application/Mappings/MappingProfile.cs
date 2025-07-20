using AutoMapper;
using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Core.Entities;

namespace HospitalManagementSystem.Application.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<PatientCreateDto, Patient>();
            CreateMap<Patient, PatientCreateDto>();
            CreateMap<Patient, PatientDto>();

            CreateMap<AppointmentCreateDto, Appointment>();
            CreateMap<Appointment, AppointmentCreateDto>();
            CreateMap<Appointment, AppointmentDto>();

            CreateMap<DoctorCreateDto, Doctor>();
            CreateMap<Doctor, DoctorCreateDto>();
            CreateMap<Doctor, DoctorDto>();

            CreateMap<UserCreateDto, User>();
            CreateMap<User, UserCreateDto>();

            CreateMap<DepartmentCreateDto, Department>();
            CreateMap<Department, DepartmentCreateDto>();
        }
    }
}
