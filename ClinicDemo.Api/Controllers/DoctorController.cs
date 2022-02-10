using ClinicDemo.Core.Entities;
using ClinicDemo.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ClinicDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DoctorController : ControllerBase
    {
        private readonly IDoctorService _doctorService;

        public DoctorController(IDoctorService doctorService)
        {
            this._doctorService = doctorService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            return Ok(await _doctorService.GetDoctors());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var response = await _doctorService.GetDoctor(id);
            if (response == null) { return NotFound(); }

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Doctor doctor)
        {
            return Ok(await _doctorService.InsertDoctor(doctor));
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Doctor doctor)
        {
            doctor.Id = id;
            return Ok(await _doctorService.UpdateDoctor(doctor));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            return Ok(await _doctorService.DeleteDoctor(id));
        }
    }
}
