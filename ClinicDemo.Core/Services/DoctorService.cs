using ClinicDemo.Core.Entities;
using ClinicDemo.Core.Interfaces.Services;
using ClinicDemo.Core.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDemo.Core.Services
{
    public class DoctorService : IDoctorService
    {
        private readonly IUnitOfWork _unitOfWork;

        public DoctorService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Doctor> GetDoctor(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                return await context.Repositories.DoctorRepository.GetById(id);
            }
        }

        public async Task<IEnumerable<Doctor>> GetDoctors()
        {
            using (var context = _unitOfWork.Create())
            {
                return await context.Repositories.DoctorRepository.GetAll();
            }
        }

        public async Task<bool> InsertDoctor(Doctor doctor)
        {
            using (var context = _unitOfWork.Create())
            {
                await context.Repositories.DoctorRepository.Insert(doctor);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<bool> UpdateDoctor(Doctor doctor)
        {
            using (var context = _unitOfWork.Create())
            {
                await context.Repositories.DoctorRepository.Update(doctor);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<bool> DeleteDoctor(int id)
        {
            using (var context = _unitOfWork.Create())
            {
                await context.Repositories.DoctorRepository.DeleteById(id);
                await context.SaveChangesAsync();

                return true;
            }
        }
    }
}
