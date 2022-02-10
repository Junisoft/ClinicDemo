using ClinicDemo.Core.Interfaces.UnitOfWork;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ClinicDemo.Infrastructure.Repositories.UnitOfWork
{
    public class UnitOfWorkAdapter : IUnitOfWorkAdapter
    {
        public SqlConnection _context { get; set; }
        public SqlTransaction _transaction { get; set; }
        public IUnitOfWorkRepository Repositories { get; set; }

        public UnitOfWorkAdapter(string cnn)
        {
            _context = new SqlConnection(cnn);
            _context.Open();

            _transaction = _context.BeginTransaction();

            Repositories = new UnitOfWorkRepository(_context, _transaction);
        }

        public void Dispose()
        {
            if (_transaction != null)
            {
                _transaction.Dispose();
            }

            if (_context != null)
            {
                _context.Close();
                _context.Dispose();
            }

            Repositories = null;
        }

        public void SaveChanges()
        {
            _transaction.Commit();
        }

        public async Task SaveChangesAsync()
        {
            await _transaction.CommitAsync();
        }
    }
}
