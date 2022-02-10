using ClinicDemo.Core.Interfaces.UnitOfWork;
using Microsoft.Extensions.Configuration;

namespace ClinicDemo.Infrastructure.Repositories.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private string _connectionString;
        private IConfiguration _configuration;

        public UnitOfWork(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public IUnitOfWorkAdapter Create()
        {
            _connectionString = this._configuration.GetConnectionString("DefaultConnection");
            return new UnitOfWorkAdapter(_connectionString);
        }
    }
}
