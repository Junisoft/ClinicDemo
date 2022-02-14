using AutoMapper;
using ClinicDemo.Api.Responses;
using ClinicDemo.Core.DTOs;
using ClinicDemo.Core.Entities;
using ClinicDemo.Core.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicDemo.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SpecialtyController : ControllerBase
    {
        private readonly ISpecialtyService _specialtyService;
        private readonly IMapper _mapper;

        public SpecialtyController(ISpecialtyService specialtyService, IMapper mapper)
        {
            _specialtyService = specialtyService;
            _mapper = mapper;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var specialties = await _specialtyService.GetSpecialties();
            var specialtiesDTO = _mapper.Map<IEnumerable<SpecialtyDTO>>(specialties);
            var response = new ApiResponse<IEnumerable<SpecialtyDTO>>(specialtiesDTO, true);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] SpecialtyDTO itemDTO)
        {
            var specialty = _mapper.Map<Specialty>(itemDTO);

            var result = await _specialtyService.InsertSpecialty(specialty);
            var response = new ApiResponse<bool>(result, true);
            return Ok(response);
        }
    }
}
