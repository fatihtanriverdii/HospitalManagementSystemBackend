using HospitalManagementSystem.Application.Common.DTOs;
using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace HospitalManagementSystem.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;
        private readonly IPatientService _patientService;
        private readonly IDoctorService _doctorService;

        public AppointmentController(IAppointmentService appointmentService, IPatientService patientService, IDoctorService doctorService)
        {
            _appointmentService = appointmentService;
            _patientService = patientService;
            _doctorService = doctorService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<AppointmentDto>>> Create([FromBody] AppointmentCreateDto appointmentCreateDto)
        {
            var patient = await _patientService.GetByIdAsync(appointmentCreateDto.PatientId);
            if (patient == null)
                return NotFound( new ResponseDto<AppointmentDto>
                {
                    Success = false,
                    Message = "Hasta bulunamadi."
                });
            
            var doctor = await _doctorService.GetByIdAsync(appointmentCreateDto.DoctorId);
            if (doctor == null)
                return NotFound( new ResponseDto<AppointmentDto>
                {
                    Success = false,
                    Message = "Doktor bulunamadi."
                });

            bool conflick = await _appointmentService.CheckConflickAsync(appointmentCreateDto.DoctorId, appointmentCreateDto.Date, appointmentCreateDto.Time);
            if (conflick)
            {
                return Conflict(new ResponseDto<AppointmentDto>
                {
                    Success = false,
                    Message = "Doktor musait degil."
                });
            }
            Console.WriteLine(conflick);

            var app = await _appointmentService.CreateAsync(appointmentCreateDto);

            return CreatedAtAction(nameof(GetById),
                new { id = app.Id},
                new ResponseDto<AppointmentDto>
                {
                    Success = true,
                    Data = app,
                    Message = "Kayit basariyla olusturuldu."
                });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<AppointmentDto>>> GetById(long id)
        {
            var app = await _appointmentService.GetByIdAsync(id);

            if (app == null)
            {
                return NotFound(new ResponseDto<AppointmentDto>
                {
                    Success = false,
                    Message = "Kayit bulunamadi."
                });
            }
            return Ok(new ResponseDto<AppointmentDto>
            {
                Success = true,
                Data = app,
                Message = "Kayit basariyla getirildi."
            });
        }

        [HttpGet("patient/{patientId}")]
        public async Task<ActionResult<ResponseDto<List<AppointmentHistoryDto>>>> GetByPatientId(long patientId)
        {
            var histories = await _appointmentService.GetAllPatientHistoryAsync(patientId);

            if (!histories.Any())
            {
                return NotFound(new ResponseDto<AppointmentHistoryDto>
                {
                    Success = false,
                    Message = "Kayitlar bulunamadi."
                });
            }
                
            return Ok(new ResponseDto<List<AppointmentHistoryDto>>
            {
                Success = true,
                Data = histories,
                Message = "Kayitlar basariyla getirildi." 
            });
        }
    }
}
