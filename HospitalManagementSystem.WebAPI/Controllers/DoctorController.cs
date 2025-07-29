using HospitalManagementSystem.Shared.DTOs;
using HospitalManagementSystem.Application.DTOs;
using HospitalManagementSystem.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using HospitalManagementSystem.Shared.DTOs.Paging;

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

            return Ok(new ResponseDto<List<DoctorDto>>
            {
                Success = true,
                Data = doctorList,
                Message = doctorList.Any()
                    ? "Doktorlar basariyla getirildi."
                    : "Kayitli doktor bulunamadi."
            });
        }

        [HttpGet("pagination")]
        public async Task<ActionResult<ResponseDto<PagedResponseDto<DoctorDto>>>> GetAllWithPagination([FromQuery] PaginationParams paginationParams)
        {
            var pagedResult = await _doctorService.GetAllWithPaginationAsync(paginationParams.PageNumber, paginationParams.PageSize);

            return Ok(new ResponseDto<PagedResponseDto<DoctorDto>>
            {
                Success = pagedResult.Items.Any(),
                Data = pagedResult,
                Message = pagedResult.Items.Any()
                    ? "Doktorlar basariyla getirildi."
                    : "Kayitli doktor bulunamadi."
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
