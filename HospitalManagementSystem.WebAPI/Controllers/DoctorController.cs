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
        private readonly IAppointmentService _appointmentService;

        public DoctorController(IDoctorService doctorService, IAppointmentService appointmentService)
        {
            _doctorService = doctorService;
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<ActionResult<ResponseDto<DoctorDto>>> Create(DoctorCreateDto doctorCreateDto)
        {
            var created = await _doctorService.CreateAsync(doctorCreateDto);

            return CreatedAtAction(nameof(GetById),
                new {id = created.Id},
                new ResponseDto<DoctorDto>
                {
                    Success = true,
                    Data = created,
                    Message = "Doktor basariyla kayit edildi." 
                });
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ResponseDto<DoctorDto>>> GetById(long id)
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

        [HttpGet]
        public async Task<ActionResult<ResponseDto<List<DoctorDto>>>> GetAll()
        {
            var doctorList = await _doctorService.GetAllAsync();
            if (doctorList == null)
            {
                return NotFound(new ResponseDto<DoctorDto>
                {
                    Success = false,
                    Message = "Kayitli doktor bulunamadi."
                });
            }
            return Ok(new ResponseDto<List<DoctorDto>>
            {
                Success = true,
                Data = doctorList,
                Message = "Doktorlar basariyla getirildi."
            });
        }

        [HttpGet("{id}/available-slots")]
        public async Task<ActionResult<ResponseDto<List<TimeSlotDto>>>> GetAvailableSlots(
            long id,
            [FromQuery] DateOnly date)
        {
            var availableTimeSlots = await _doctorService.GetAvailableTimeSlotsAsync(id, date);
            return Ok(new ResponseDto<List<TimeSlotDto>>
            {
                Success = true,
                Data = availableTimeSlots,
                Message = "Zamanlar basariyla getirildi."
            });
        }
    }
}
