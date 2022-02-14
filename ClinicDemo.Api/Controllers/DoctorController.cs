using AutoMapper;
using ClinicDemo.Api.Responses;
using ClinicDemo.Core.DTOs;
using ClinicDemo.Core.Entities;
using ClinicDemo.Core.Interfaces.Services;
using ClinicDemo.Core.QueryFilters;
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
        private readonly IMapper _mapper;

        public DoctorController(IDoctorService doctorService, IMapper mapper)
        {
            _doctorService = doctorService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] DoctorQueryFilter filters)
        {
            var doctors = await _doctorService.GetDoctors(filters);
            var doctorsDTO = _mapper.Map<IEnumerable<DoctorDTO>>(doctors);
            var response = new ApiResponse<IEnumerable<DoctorDTO>>(doctorsDTO, true);
            return Ok(response);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var doctor = await _doctorService.GetDoctor(id);
            if (doctor == null) { return NotFound(); }

            var doctorDTO = _mapper.Map<DoctorDTO>(doctor);
            var response = new ApiResponse<DoctorDTO>(doctorDTO, true);

            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] DoctorDTO itemDTO)
        {
            var doctor = _mapper.Map<Doctor>(itemDTO);
            await _doctorService.InsertDoctor(doctor);

            itemDTO = _mapper.Map<DoctorDTO>(doctor);
            var response = new ApiResponse<DoctorDTO>(itemDTO, true);
            return Ok(response);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] DoctorDTO itemDTO)
        {
            itemDTO.Id = id;
            var doctor = _mapper.Map<Doctor>(itemDTO);
            var result = await _doctorService.UpdateDoctor(doctor);
            var response = new ApiResponse<bool>(result, true);

            return Ok(response);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var doctor = await _doctorService.GetDoctor(id);
            if (doctor == null) { return NotFound(); }

            var result = await _doctorService.DeleteDoctor(id);
            var response = new ApiResponse<bool>(result, true);
            return Ok(response);
        }

        [HttpDelete("logic/{id}")]
        public async Task<IActionResult> DeleteLogic(int id, [FromBody] DoctorDTO itemDTO)
        {
            var doctor = await _doctorService.GetDoctor(id);
            if (doctor == null) { return NotFound(); }

            var result = await _doctorService.EnableDisableDoctor(id, itemDTO.IsDeleted);
            var response = new ApiResponse<bool>(result, true);
            return Ok(response);
        }


    }
}
