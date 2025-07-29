using HospitalManagementSystem.Core.Entities;
using HospitalManagementSystem.Core.Interfaces.Repositories;
using HospitalManagementSystem.Application.Interfaces.Services;
using AutoMapper;
using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Shared.Exceptions;
using HospitalManagementSystem.Shared.DTOs.Paging;

namespace HospitalManagementSystem.Application.Services
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
				throw new NotFoundException("Department not found");
			}
			_departmentRepo.Delete(department);
			await _departmentRepo.SaveChangesAsync();
		}

		public async Task<List<DepartmentDto>> GetAllAsync()
		{
			var departments = await _departmentRepo.ListAllAsync();
			return _mapper.Map<List<DepartmentDto>>(departments);
		}

		public async Task<PagedResponseDto<DepartmentDto>> GetAllWithPagination(int pageNumber, int pageSize)
		{
			var data = await _departmentRepo.ListAllWithPagination(pageNumber, pageSize);
			var totalCount = await _departmentRepo.GetCountAsync();

			var dtos = data
				.Select(d => _mapper.Map<DepartmentDto>(d))
				.ToList();

			return new PagedResponseDto<DepartmentDto>
			{
				Items = dtos,
				PageNumber = pageNumber,
				PageSize = pageSize,
				TotalCount = totalCount
			};
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
