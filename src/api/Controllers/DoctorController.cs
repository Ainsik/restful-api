using api.DTOs;
using api.Services;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    [ApiController]
    [Route("/api/doctors")]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            _doctorService = doctorService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BaseDoctorDto>>> GetAllDoctorsAsync()
        {
            var doctors = await _doctorService.GetAllAsync();
            return Ok(doctors);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BaseDoctorDto>> GetDoctorByIdAsync([FromRoute] int id)
        {
            var doctor = await _doctorService.GetByIdAsync(id);

            return Ok(doctor);
        }

        [HttpPost]
        public async Task<ActionResult> CreateDoctor([FromBody] CreateDoctorDto dto)
        {
            var (doctorId, doctor) = await _doctorService.CreateAsync(dto);

            return Created($"/api/doctors/{doctorId}", doctor);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateDoctor([FromRoute] int id, [FromBody] CreateDoctorDto dto)
        {
            await _doctorService.UpdateAsync(id, dto);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteDoctor([FromRoute] int id)
        {
            await _doctorService.DeleteAsync(id);
            return NoContent();
        }
    }
}
