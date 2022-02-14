using ClinicDemo.Core.Entities;
using ClinicDemo.Core.Interfaces.Services;
using ClinicDemo.Core.Interfaces.UnitOfWork;
using ClinicDemo.Core.QueryFilters;
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

        public async Task<IEnumerable<Doctor>> GetDoctors(DoctorQueryFilter filters)
        {
            using (var context = _unitOfWork.Create())
            {
                filters.PageNumber = filters.PageNumber == 0 ? 1 : filters.PageNumber;
                filters.PageSize = filters.PageSize == 0 ? 10 : filters.PageSize;

                return await context.Repositories.DoctorRepository.GetAll(filters.PageNumber, filters.PageSize);
            }
        }

        public async Task<bool> InsertDoctor(Doctor doctor)
        {
            using (var context = _unitOfWork.Create())
            {
                await context.Repositories.DoctorRepository.Add(doctor);
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
                await context.Repositories.DoctorRepository.Delete(id);
                await context.SaveChangesAsync();

                return true;
            }
        }

        public async Task<bool> EnableDisableDoctor(int id, bool isActive)
        {
            using (var context = _unitOfWork.Create())
            {
                await context.Repositories.DoctorRepository.EnableDisableDoctor(id, isActive);
                await context.SaveChangesAsync();

                return true;
            }
        }
    }
}
