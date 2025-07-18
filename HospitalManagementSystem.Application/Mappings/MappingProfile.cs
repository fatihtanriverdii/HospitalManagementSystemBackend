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

            CreateMap<RegistrationCreateDto, Registration>();
            CreateMap<Registration, RegistrationCreateDto>();

            CreateMap<DoctorCreateDto, Doctor>();
            CreateMap<Doctor, DoctorCreateDto>();

            CreateMap<UserCreateDto, User>();
            CreateMap<User, UserCreateDto>();

            CreateMap<DepartmentCreateDto, Department>();
            CreateMap<Department, DepartmentCreateDto>();
        }
    }
}
