using HealthClaim.BAL.Repository.Interface;
using HealthClaim.DAL;
using HealthClaim.DAL.Models;
using HealthClaim.Model.Dtos.Common;
using HealthClaim.Model.Dtos.EmpAccountDetail;
using HealthClaim.Model.Dtos.Employee;
using HealthClaim.Model.Dtos.Response;
using HealthClaim.Utility.Resources;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.BAL.Repository.Concrete
{
    public class CommanRepository : GenricRepository<UplodDocType>, ICommanRepository
    {
        private HealthClaimDbContext _dbContext;

        public CommanRepository(HealthClaimDbContext db) : base(db)
        {
            _dbContext = db;
        }

        public async Task<ResponeModel> CreateHospitalAccountDetail(HospitalAccountDetailDto hospitalAccountDetailDto)
        {
            ResponeModel responeModel = new ResponeModel();
            if (hospitalAccountDetailDto != null)
            {
                HospitalAccountDetail hospitalAccountDetail = new HospitalAccountDetail()
                {
                    BankName = hospitalAccountDetailDto.BankName,
                    AccountNumber=hospitalAccountDetailDto.AccountNumber,
                    IfscCode=hospitalAccountDetailDto.IfscCode,
                    CreatedBy = 1,
                    CreatedDate = DateTime.Now,
                    IsActive = hospitalAccountDetailDto.IsActive
                };
                _dbContext.Add(hospitalAccountDetail);
                int id = await _dbContext.SaveChangesAsync();
                responeModel.Data = hospitalAccountDetail;
                responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                responeModel.Error = false;
                responeModel.Message = "Hospital Account Details created successfully.";
            }
            return responeModel;
        }
        public async Task<ResponeModel> UpdateHospitalAccountDetail(HospitalAccountDetailDto hospitalAccountDetailDto, int id)
        {
            ResponeModel responeModel = new ResponeModel();
            if (hospitalAccountDetailDto != null && id != 0)
            {
                var hospitalaccountdetail = _dbContext.HospitalAccountDetails.Where(e => e.Id == id).FirstOrDefault();

                if (hospitalaccountdetail != null)
                {
                    hospitalaccountdetail.BankName = hospitalAccountDetailDto.BankName;
                    hospitalaccountdetail.AccountNumber = hospitalAccountDetailDto.AccountNumber;
                    hospitalaccountdetail.IfscCode = hospitalAccountDetailDto.IfscCode;
                    hospitalaccountdetail.IsActive = hospitalAccountDetailDto.IsActive;
                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = hospitalaccountdetail;
                    responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                    responeModel.Error = false;
                    responeModel.Message = "Hospital Account Updated Successfully";
                }
            }
            return responeModel;
        }
        public async Task<ResponeModel> DeleteHospitalAccountDetail(int id)
        {
            ResponeModel responeModel = new ResponeModel();
            if (id != 0)
            {
                var empDeleteDocType = _dbContext.HospitalAccountDetails.Where(e => e.Id == id).FirstOrDefault();

                if (empDeleteDocType != null)
                {
                    empDeleteDocType.IsActive = false;
                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = null;
                    responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                    responeModel.Error = false;
                    responeModel.Message = "Hospital Account record deleted successfully.";
                }
            }
            return responeModel;
        }
        public async Task<ResponeModel> GetHospitalAccountDetail(int? id)
        {
            ResponeModel responeModel = new ResponeModel();
            var hospitalAccountDetails = await _dbContext.HospitalAccountDetails.Where(e => e.IsActive == true && id == 0 ? e.Id == e.Id : e.Id == id ).ToListAsync();
            responeModel.Data = hospitalAccountDetails;
            responeModel.DataLength = hospitalAccountDetails.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = hospitalAccountDetails.Count + " Hosptial Details found By Id.";
            return responeModel;
        }

        public async Task<ResponeModel> CreateUploadDocType(UplodDocTypeModel uplodDocType)
        {
            ResponeModel responeModel = new ResponeModel();
            if (uplodDocType != null)
            {
                UplodDocType uplodDoc = new UplodDocType()
                {
                    Name = uplodDocType.Name,
                    IsBillable = uplodDocType.IsBillable,
                    CreatedBy=1,
                    CreatedDate=DateTime.Now,
                    IsActive=true
                };
                _dbContext.Add(uplodDoc);
                int id = await _dbContext.SaveChangesAsync();
                responeModel.Data = uplodDoc;
                responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                responeModel.Error = false;
                responeModel.Message = "Doc Type created successfully.";
            }
            return responeModel;
        }

       

        public async Task<ResponeModel> DeleteUploadDocType(int id)
        {
            ResponeModel responeModel = new ResponeModel();
            if (id != 0)
            {
                var empDeleteDocType = _dbContext.UplodDocType.Where(e => e.Id == id).FirstOrDefault();

                if (empDeleteDocType != null)
                {
                    empDeleteDocType.IsActive = false;
                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = null;
                    responeModel.StatusCode = System.Net.HttpStatusCode.OK;
                    responeModel.Error = false;
                    responeModel.Message = "UploadDocType record deleted successfully.";

                }
            }
            return responeModel;
        }

        public async Task<ResponeModel> Get(int? id)
        {
            ResponeModel responeModel = new ResponeModel();
            var empDocType = await _dbContext.UplodDocType.Where(e => id == 0 ? e.Id == e.Id : e.Id == id && e.IsActive == true).ToListAsync();
            responeModel.Data = empDocType;
            responeModel.DataLength = empDocType.Count;
            responeModel.StatusCode = System.Net.HttpStatusCode.OK;
            responeModel.Error = false;
            responeModel.Message = empDocType.Count + " Employee Doc Type found By Id.";

            return responeModel;
        }

        public async Task<ResponeModel> UpdateUploadDocType(UplodDocTypeModel uplodDocType, int id)
        {
            ResponeModel responeModel = new ResponeModel();
            if (uplodDocType != null && id != 0)
            {
                var updateDocType = _dbContext.UplodDocType.Where(e => e.Id == id).FirstOrDefault();

                if (updateDocType != null)
                {
                    updateDocType.Name = uplodDocType.Name;
                    updateDocType.IsBillable = uplodDocType.IsBillable;
                    await _dbContext.SaveChangesAsync();
                    responeModel.Data = updateDocType;
                    responeModel.StatusCode = System.Net.HttpStatusCode.Created;
                    responeModel.Error = false;
                    responeModel.Message = "Updated DocType Successfully";
                }
            }
            return responeModel;
        }
    }
}
