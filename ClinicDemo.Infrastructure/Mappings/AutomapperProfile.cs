using AutoMapper;
using ClinicDemo.Core.DTOs;
using ClinicDemo.Core.Entities;

namespace ClinicDemo.Infrastructure.Mappings
{
    public class AutomapperProfile : Profile
    {
        public AutomapperProfile()
        {
            CreateMap<Doctor, DoctorDTO>().ReverseMap();
            CreateMap<Specialty, SpecialtyDTO>().ReverseMap();
        }
    }
}
