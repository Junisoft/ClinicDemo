using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicDemo.Core.Interfaces.UnitOfWork
{
    public interface IUnitOfWork
    {
        IUnitOfWorkAdapter Create();
    }
}
