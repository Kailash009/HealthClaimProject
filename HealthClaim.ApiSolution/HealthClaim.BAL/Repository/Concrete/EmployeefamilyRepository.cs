using HealthClaim.BAL.Repository.Interface;
using HealthClaim.DAL;
using HealthClaim.DAL.Models;
using HealthClaim.Model.Dtos.Employee;
using HealthClaim.Model.Dtos.Employeefamily;
using HealthClaim.Model.Dtos.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.BAL.Repository.Concrete
{
    public class EmployeefamilyRepository : GenricRepository<EmpFamily>, IEmployeefamilyRepository
    {
        private HealthClaimDbContext _dbContext;
        #region Constructor
        /// <summary>
        /// This is constructor to set dependency injection
        /// </summary>
        /// <param name="db"></param>
        public EmployeefamilyRepository(HealthClaimDbContext db) : base(db)
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
        public async Task<ResponeModel> Create(EmployeefamilyModel employeefamily)
        {
            ResponeModel responeModel = new ResponeModel();
            if (employeefamily != null)
            {
                EmpFamily empFamily = new EmpFamily()
                {
                    EmpId = employeefamily.EmpId,
                    Name = employeefamily.Name,
                    RelationId = employeefamily.RelationId,
                    BloodGroup = employeefamily.BloodGroup,
                    EmailId = employeefamily.EmailId,
                    MobileNo = employeefamily.MobileNo,
                    Gender = employeefamily.Gender,
                    IsActive = employeefamily.IsActive,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    //UpdatedBy = employeeModel.UpdatedBy,
                    //UpdatedDate=DateTime.Now,
                };
                 _dbContext.Add(empFamily);
                int id = await _dbContext.SaveChangesAsync();
                responeModel.Data = empFamily;
                responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                responeModel.Error = false;
                responeModel.Message = "Employee created successfully.";

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
                var empFamilyDetails = _dbContext.EmpFamilys.Where(e => e.Id == id).FirstOrDefault();

                if (empFamilyDetails != null)
                {
                    empFamilyDetails.IsActive = false;
                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = null;
                    responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                    responeModel.Error = false;
                    responeModel.Message = "Faimly record deleted successfully.";

                }
            }
            return responeModel;
        }
        #endregion

        #region Get Faimly details
        /// <summary>
        /// This method is used for fetch the employee details and list of faimly
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponeModel> GetFamily(int? id)
        {
            ResponeModel responeModel = new ResponeModel();
            var empFaimly = _dbContext.EmpFamilys.Where(e => id == 0 ? e.Id == e.Id : e.Id == id && e.IsActive == true).ToList();
            responeModel.Data = empFaimly;
            responeModel.DataLength = empFaimly.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = empFaimly.Count + " Employee found.";

            return responeModel;
        }
        #endregion

        #region Update Employee Details
        /// <summary>
        /// This method is used for update employee details
        /// </summary>
        /// <param name="employeeModel"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<ResponeModel> Update(UpdateEmployeefamilyModel employeefamilyModel, int id)
        {
            ResponeModel responeModel = new ResponeModel();
            if (employeefamilyModel != null && id != 0)
            {
                var employeefamilyDetails = _dbContext.Employees.Where(e => e.Id == id).FirstOrDefault();

                if (employeefamilyDetails != null)
                {
                    //employeeDetails.EmpId = employeeModel.EmpId;
                    employeefamilyDetails.BloodGroup = employeefamilyModel.BloodGroup;
                    employeefamilyDetails.EmailId = employeefamilyModel.EmailId;
                    employeefamilyDetails.Mobile = employeefamilyModel.MobileNo;
                    employeefamilyDetails.IsActive = employeefamilyModel.IsActive;
                    employeefamilyDetails.UpdatedDate = DateTime.Now;
                    employeefamilyDetails.UpdatedBy = 1;

                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = employeefamilyDetails;
                    responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                    responeModel.Error = false;
                    responeModel.Message = "Employee updated successfully.";

                }

            }
            return responeModel;
        }
        #endregion
    }
}
