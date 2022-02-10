using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ClinicDemo.Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWorkAdapter: IDisposable
    {
        IUnitOfWorkRepository Repositories { get; }
        
        void SaveChanges();

        Task SaveChangesAsync();
    }
}
