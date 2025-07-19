using HospitalManagementSystem.Application.Common.DTOs;
using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<DoctorDto>>> Create(DoctorCreateDto doctorCreateDto)
        {
            var created = await _doctorService.CreateAsync(doctorCreateDto);

            return CreatedAtAction(nameof(GetById), new {id = created.Id},
                new ResponseDto<DoctorDto>
                {
                    Success = true,
                    Data = created,
                    Message = "Doktor basariyla kayit edildi." 
                });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<DoctorDto>> GetById(long id)
        {
            var doctor = await _doctorService.GetByIdAsync(id);

            if (doctor == null)
            {
                return NotFound(new ResponseDto<DoctorDto>
                {
                    Success = false,
                    Data = null,
                    Message = "Kayitli doktor bulunamadi."
                });
            }
            return Ok(new ResponseDto<DoctorDto>
            {
                Success = true,
                Data = doctor,
                Message = "Doktor basariyla getirildi."
            });
        }
    }
}
