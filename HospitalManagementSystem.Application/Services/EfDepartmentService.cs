﻿using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Interfaces.Repositories;
using HospitalManagementSystem.Application.Interfaces.Services;
using AutoMapper;
using HospitalManagementSystem.Application.DTOs;

namespace HospitalManagementSystem.Infrastructure.Services
{
	public class EfDepartmentService : IDepartmentService
	{
		private readonly IDepartmentRepository _departmentRepo;
		private readonly IMapper _mapper;

		public EfDepartmentService(IDepartmentRepository departmentRepo, IMapper mapper)
		{
			_departmentRepo = departmentRepo;
			_mapper = mapper;
		}

		public async Task CreateAsync(Department department)
		{
			await _departmentRepo.AddAsync(department);
			await _departmentRepo.SaveChangesAsync();
		}

		public async Task DeleteAsync(long id)
		{
			var department = await _departmentRepo.GetByIdAsync(id);
			if (department == null)
			{
				throw new KeyNotFoundException("Department not found");
			}
			_departmentRepo.Delete(department);
			await _departmentRepo.SaveChangesAsync();
		}

		public async Task<List<DepartmentDto>> GetAllAsync()
		{
			var departments = await _departmentRepo.ListAllAsync();
			if (departments == null)
				return null;
			return _mapper.Map<List<DepartmentDto>>(departments);
		}

		public async Task<DepartmentDto> GetByIdAsync(long id)
		{
			var department = await _departmentRepo.GetByIdAsync(id);
			return _mapper.Map<DepartmentDto>(department);
		}

		public async Task UpdateAsync(Department department)
		{
			_departmentRepo.Update(department);
			await _departmentRepo.SaveChangesAsync();
		}
	}
}
