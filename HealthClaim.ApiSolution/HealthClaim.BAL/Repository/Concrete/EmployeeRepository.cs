using HealthClaim.BAL.Repository.Interface;
using HealthClaim.DAL;
using HealthClaim.DAL.Models;
using HealthClaim.Model.Dtos.Employee;
using HealthClaim.Model.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.BAL.Repository.Concrete
{
    public class EmployeeRepository : GenricRepository<Employee>, IEmployeeRepository
    {
        private HealthClaimDbContext _dbContext;
        #region Constructor
        /// <summary>
        /// This is constructor to set dependency injection
        /// </summary>
        /// <param name="db"></param>
        public EmployeeRepository(HealthClaimDbContext db) : base(db)
        {
            _dbContext = db;
        } 
        #endregion

        #region Create Employee
        /// <summary>
        /// This method is used for add new employee
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <returns></returns>
        public async Task<ResponeModel> Create(EmployeeModel employeeModel)
        {
            ResponeModel responeModel = new ResponeModel();
            if (employeeModel != null)
            {
                Employee employee = new Employee()
                {
                    EmpId = employeeModel.EmpId,
                    BloodGroup = employeeModel.BloodGroup,
                    EmailId = employeeModel.EmailId,
                    Designation = employeeModel.Designation,
                    Mobile = employeeModel.Mobile,
                    IsActive = employeeModel.IsActive,
                    //CreatedBy = employeeModel.CreatedBy,
                    CreatedDate = DateTime.Now,
                    //UpdatedBy = employeeModel.UpdatedBy,
                    //UpdatedDate=DateTime.Now,
                };
                _dbContext.Add(employee);
                int id = await _dbContext.SaveChangesAsync();
                responeModel.Data = employee;
                responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                responeModel.Error = false;
                responeModel.Message = "Employee created successfully.";

            }
            return responeModel;
        }
        #endregion

        #region Create Employee Relation
        /// <summary>
        /// This method is used for create employee relation
        /// </summary>
        /// <param name="empRelationModel"></param>
        /// <returns></returns>
        public async Task<ResponeModel> CreateEmpRelation(EmpRelationModel empRelationModel)
        {
            ResponeModel responeModel = new ResponeModel();
            if (empRelationModel != null)
            {
                EmpRelation employeerelation = new EmpRelation()
                {
                    Name = empRelationModel.Name,
                    Description = empRelationModel.Description,
                    CreatedBy = 5,
                    CreatedDate = DateTime.Now,

                };
                _dbContext.Add(employeerelation);
                int id = await _dbContext.SaveChangesAsync();
                responeModel.Data = employeerelation;
                responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                responeModel.Error = false;
                responeModel.Message = "Employee relation created successfully.";

            }
            return responeModel;
        }

        #endregion
        #region Delete
        /// <summary>
        /// This method is used for delete record
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponeModel> Delete(int id)
        {
            ResponeModel responeModel = new ResponeModel();
            if (id != 0)
            {
                var employeeDetails = _dbContext.Employees.Where(e => e.Id == id).FirstOrDefault();

                if (employeeDetails != null)
                {
                    employeeDetails.IsActive = false;
                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = null;
                    responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                    responeModel.Error = false;
                    responeModel.Message = "Employee deleted successfully.";

                }
            }
            return responeModel;
        }

        #endregion
        #region Delete Employee Relation
        /// <summary>
        /// This method is used for Delete Employee relation
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponeModel> DeleteEmpRelation(int id)
        {
            ResponeModel responeModel = new ResponeModel();
            if (id != 0)
            {
                var employeeDetails = _dbContext.EmpRelations.Where(e => e.Id == id).FirstOrDefault();

                if (employeeDetails != null)
                {
                    employeeDetails.IsActive = false;
                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = null;
                    responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                    responeModel.Error = false;
                    responeModel.Message = "Employee relation deleted successfully.";

                }
            }
            return responeModel;
        }

        #endregion
        #region Get Employee
        /// <summary>
        /// This method is used for fetch the employee details
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponeModel> Get(int? id)
        {
            ResponeModel responeModel = new ResponeModel();
            var employees = _dbContext.Employees.Where(e => id == 0 ? e.Id == e.Id : e.Id == id && e.IsActive == true).ToList();
            responeModel.Data = employees;
            responeModel.DataLength = employees.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = employees.Count + " Employee found.";

            return responeModel;
        } 
        #endregion

        public async Task<ResponeModel> GetEmpRelation(int? id)
        {
            ResponeModel responeModel = new ResponeModel();
            var employees = _dbContext.EmpRelations.Where(e => id == 0 ? e.Id == e.Id : e.Id == id && e.IsActive == true).ToList();
            responeModel.Data = employees;
            responeModel.DataLength = employees.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = employees.Count + " Employee relation found.";

            return responeModel;
        }

        #region Update Employee Details
        /// <summary>
        /// This method is used for update employee details
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponeModel> Update(EmployeeModel employeeModel, int id)
        {

            ResponeModel responeModel = new ResponeModel();
            if (employeeModel != null && id != 0)
            {
                var employeeDetails = _dbContext.Employees.Where(e => e.Id == id).FirstOrDefault();

                if (employeeDetails != null)
                {
                    employeeDetails.EmpId = employeeModel.EmpId;
                    employeeDetails.BloodGroup = employeeModel.BloodGroup;
                    employeeDetails.EmailId = employeeModel.EmailId;
                    employeeDetails.Designation = employeeModel.Designation;
                    employeeDetails.Mobile = employeeModel.Mobile;
                    employeeDetails.IsActive = employeeModel.IsActive;
                    employeeDetails.UpdatedDate = DateTime.Now;

                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = employeeDetails;
                    responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                    responeModel.Error = false;
                    responeModel.Message = "Employee updated successfully.";

                }

            }
            return responeModel;
        }
        
        #endregion
        #region Update Employee Relation
        /// <summary>
        /// This method is used for update Employee relation
        /// </summary>
        /// <param name="empRelationModel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponeModel> UpdateEmpRelation(EmpRelationModel empRelationModel, int id)
        {
            ResponeModel responeModel = new ResponeModel();
            if (empRelationModel != null && id != 0)
            {
                var employeeDetails = _dbContext.EmpRelations.Where(e => e.Id == id).FirstOrDefault();

                if (employeeDetails != null)
                {
                    employeeDetails.Name = empRelationModel.Name;
                    employeeDetails.Description = empRelationModel.Description;

                    employeeDetails.IsActive = empRelationModel.IsActive;
                    employeeDetails.UpdatedDate = DateTime.Now;

                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = employeeDetails;
                    responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                    responeModel.Error = false;
                    responeModel.Message = "Employee relation updated successfully.";

                }

            }
            return responeModel;
        } 
        #endregion
    }
}
