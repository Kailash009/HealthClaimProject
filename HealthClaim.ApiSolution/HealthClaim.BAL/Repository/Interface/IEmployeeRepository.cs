using HealthClaim.Model.Dtos.Common;
using HealthClaim.Model.Dtos.Employee;
using HealthClaim.Model.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.BAL.Repository.Interface
{
    public interface IEmployeeRepository
    {
        public Task<ResponeModel> Create(EmployeeModel employeeModel);
        public Task<ResponeModel> Update(EmployeeModel employeeModel, int id);
        public Task<ResponeModel> Delete(int id);
        public Task<ResponeModel> Get(int? id);
        public Task<ResponeModel> CreateEmpRelation(EmpRelationModel empRelationModel);
        public Task<ResponeModel> UpdateEmpRelation(EmpRelationModel empRelationModel, int id);
        public Task<ResponeModel> DeleteEmpRelation(int id);
        public Task<ResponeModel> GetEmpRelation(int? id);
    }
}
