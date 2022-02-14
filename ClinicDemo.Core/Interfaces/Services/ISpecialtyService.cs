using ClinicDemo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDemo.Core.Interfaces.Services
{
    public interface ISpecialtyService
    {
        Task<IEnumerable<Specialty>> GetSpecialties();

        Task<bool> InsertSpecialty(Specialty item);

    }
}
