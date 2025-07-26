using HospitalManagementSystem.Application.Common.DTOs;
using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

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
            if (departmentList == null)
            {
                return NotFound(new ResponseDto<DepartmentDto>
                {
                    Success = false,
                    Message = "Kayitli departman bulunamadi."
                });
            }
            return Ok(new ResponseDto<List<DepartmentDto>>
            {
                Success = true,
                Data = departmentList,
                Message = "Departmanlar basariyla getirildi."
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
