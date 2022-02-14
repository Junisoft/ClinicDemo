using ClinicDemo.Core.Interfaces;
using ClinicDemo.Core.Interfaces.UnitOfWork;
using System.Data.SqlClient;

namespace ClinicDemo.Infrastructure.Repositories.UnitOfWork
{
    public class UnitOfWorkRepository: IUnitOfWorkRepository
    {
        public IDoctorRepository DoctorRepository { get; }
        public ISpecialtyRepository SpecialtyRepository { get; }
        public UnitOfWorkRepository(SqlConnection context, SqlTransaction transaction)
        {
            DoctorRepository = new DoctorRepository(context, transaction);
            SpecialtyRepository = new SpecialtyRepository(context, transaction);
        }
    }
}
