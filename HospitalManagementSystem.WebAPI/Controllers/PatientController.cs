using HospitalManagementSystem.Application.Common.DTOs;
using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PatientController : ControllerBase
    {
        private readonly IPatientService _patientService;

        public PatientController(IPatientService patientService)
        {
            _patientService = patientService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<PatientDto>>> Create(PatientCreateDto patientCreateDto)
        {
            var created = await _patientService.CreateAsync(patientCreateDto);

            if (created != null)
            {
                return CreatedAtAction(nameof(GetById),
                    new { id = created.Id },
                    new ResponseDto<PatientDto>
                    {
                        Success = true,
                        Data = created,
                        Message = "Hasta basariyla kayit edildi"
                    });
            }
            return BadRequest(new ResponseDto<PatientDto>()
            {
                Success = false,
                Message = "Ayni TC' ye kayitli hasta var."
            });
        }

        [HttpGet("id/{id}")]
        public async Task<ActionResult<ResponseDto<PatientDto>>> GetById(long id)
        {
            var patient = await _patientService.GetByIdAsync(id);
            if (patient == null)
            {
                return NotFound(
                    new ResponseDto<PatientDto>
                    {
                        Success = false,
                        Data = null,
                        Message = "Kayitli hasta bulunamdi."
                    });
            }
            return Ok(new ResponseDto<PatientDto>
            {
                Success = true,
                Data = patient,
                Message = "Hasta basariyla getirildi."
            });
        }

        [HttpGet("tc/{tc}")]
        public async Task<ActionResult<ResponseDto<PatientDto>>> GetByTc(string tc)
        {
            var patient = await _patientService.GetByTCAsync(tc);
            if (patient == null)
            {
                return NotFound(
                    new ResponseDto<PatientDto>
                    {
                        Success = false,
                        Data = null,
                        Message = "Kayitli hasta bulunamdi."
                    });
            }
            return Ok(new ResponseDto<PatientDto>
            {
                Success = true,
                Data = patient,
                Message = "Hasta basariyla getirildi."
            });
        }
    }
}
