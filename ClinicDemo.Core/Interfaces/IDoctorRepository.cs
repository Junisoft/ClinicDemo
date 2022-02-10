using ClinicDemo.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDemo.Core.Interfaces
{
    public interface IDoctorRepository
    {
        Task<List<Doctor>> GetAll();
        Task<Doctor> GetById(int Id);
        Task Insert(Doctor doctor);
        Task Update(Doctor doctor);
        Task DeleteById(int Id);
    }
}
