using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicDemo.Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWorkRepository
    {
        //List of repositories
        IDoctorRepository DoctorRepository { get; }
    }
}
