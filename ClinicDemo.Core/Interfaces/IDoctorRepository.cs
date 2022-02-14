using ClinicDemo.Core.Entities;
using System.Threading.Tasks;

namespace ClinicDemo.Core.Interfaces
{
    public interface IDoctorRepository: IRepository<Doctor>
    {
        Task EnableDisableDoctor(int id, bool isActive);
    }
}
