using HealthClaim.BAL.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.BAL.Repository
{
    public interface IUnitOfWork
    {
        IEmpAdvanceRepository ProductUnit { get; }
        void Save();
    }
}
