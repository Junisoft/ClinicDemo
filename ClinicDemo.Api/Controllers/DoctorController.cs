using ClinicDemo.Api.Responses;
using ClinicDemo.Core.Entities;
using ClinicDemo.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
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
            var result = await _doctorService.GetDoctors();
            var response = new ApiResponse<IEnumerable<Doctor>>(result, true);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var result = await _doctorService.GetDoctor(id);
            if (result == null) { return NotFound(); }

            var response = new ApiResponse<Doctor>(result, true);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Doctor doctor)
        {
            var result = await _doctorService.InsertDoctor(doctor);
            var response = new ApiResponse<bool>(result, true);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Doctor doctor)
        {
            doctor.Id = id;
            var result = await _doctorService.UpdateDoctor(doctor);
            var response = new ApiResponse<bool>(result, true);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _doctorService.DeleteDoctor(id);
            var response = new ApiResponse<bool>(result, true);
            return Ok(response);
        }
    }
}
