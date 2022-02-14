using ClinicDemo.Core.Entities;
using ClinicDemo.Core.Interfaces.Services;
using ClinicDemo.Core.Interfaces.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicDemo.Core.Services
{
    public class SpecialtyService : ISpecialtyService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SpecialtyService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Specialty>> GetSpecialties()
        {
            using (var context = _unitOfWork.Create())
            {
                return await context.Repositories.SpecialtyRepository.GetAll();
            }
        }

        public async Task<bool> InsertSpecialty(Specialty item)
        {
            using (var context = _unitOfWork.Create())
            {
                await context.Repositories.SpecialtyRepository.Add(item);
                await context.SaveChangesAsync();

                return true;
            }
        }
    }
}
