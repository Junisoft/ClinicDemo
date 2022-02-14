using ClinicDemo.Core.Entities;
using ClinicDemo.Core.QueryFilters;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicDemo.Core.Interfaces.Services
{
    public interface IDoctorService
    {
        Task<IEnumerable<Doctor>> GetDoctors(DoctorQueryFilter filters);

        Task<Doctor> GetDoctor(int id);

        Task<bool> InsertDoctor(Doctor doctor);

        Task<bool> UpdateDoctor(Doctor doctor);

        Task<bool> DeleteDoctor(int id);

        Task<bool> EnableDisableDoctor(int id, bool isActive);
    }
}
