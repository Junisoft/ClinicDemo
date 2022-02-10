using ClinicDemo.Core.Interfaces;
using ClinicDemo.Core.Interfaces.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace ClinicDemo.Infrastructure.Repositories.UnitOfWork
{
    public class UnitOfWorkRepository: IUnitOfWorkRepository
    {
        public IDoctorRepository DoctorRepository { get; }
        public UnitOfWorkRepository(SqlConnection context, SqlTransaction transaction)
        {
            DoctorRepository = new DoctorRepository(context, transaction);
        }
    }
}
