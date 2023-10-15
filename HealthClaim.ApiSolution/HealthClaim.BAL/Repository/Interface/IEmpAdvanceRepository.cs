using HealthClaim.DAL.Models;
using HealthClaim.Model.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.BAL.Repository.Interface
{
    public interface IEmpAdvanceRepository : IGenricRepository<EmpAdvance>
    {
        Task<CreateResponseDto> AdvanceRequest(EmpAdvance empAdvance);
        void Update(EmpAdvance obj);
    }
   
}
