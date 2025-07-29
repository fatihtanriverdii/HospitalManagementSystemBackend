using HospitalManagementSystem.Shared.DTOs;
using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Shared.DTOs.Paging;

namespace HospitalManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentService _departmentService;

        public DepartmentController(IDepartmentService departmentService)
        {
            _departmentService = departmentService;
        }

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<DepartmentDto>>>> GetAll()
        {
            var departmentList = await _departmentService.GetAllAsync();

            return Ok(new ResponseDto<List<DepartmentDto>>
            {
                Success = true,
                Data = departmentList,
                Message = departmentList.Any()
                    ? "Departmanlar basariyla getirildi." 
                    : "Kayitli departman bulunamadi."
            });
        }

        [HttpGet("pagination")]
        public async Task<ActionResult<ResponseDto<PagedResponseDto<DepartmentDto>>>> GetAllWithPagination([FromQuery] PaginationParams paginationParams)
        {
            var pagedResult = await _departmentService.GetAllWithPagination(paginationParams.PageNumber, paginationParams.PageSize);

            return Ok(new ResponseDto<PagedResponseDto<DepartmentDto>>
            {
                Success = pagedResult.Items.Any(),
                Data = pagedResult,
                Message = pagedResult.Items.Any()
                    ? "Departmanlar basariyla getirtildi."
                    : "Kayitli departman bulunamadi."
            });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DepartmentDto>> GetById(long id)
        {
            var department = await _departmentService.GetByIdAsync(id);

            if (department == null)
            {
                return NotFound(new ResponseDto<DepartmentDto>
                {
                    Success = false,
                    Message = "Kayitli departman bulunamadi."
                });
            }
            return Ok(new ResponseDto<DepartmentDto>
            {
                Success = true,
                Data = department,
                Message = "Departmanlar basariyla getirildi."
            });
        }
    }
}
