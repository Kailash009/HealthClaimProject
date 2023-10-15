using HealthClaim.BAL.Repository.Interface;
using HealthClaim.DAL;
using HealthClaim.DAL.Models;
using HealthClaim.Model.Dtos.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.BAL.Repository.Concrete
{
    public class EmpAdvanceRepository : GenricRepository<EmpAdvance>, IEmpAdvanceRepository
    {
        private HealthClaimDbContext _db;

        public EmpAdvanceRepository(HealthClaimDbContext db) : base(db)
        {
            _db = db;
        }

        public async Task<CreateResponseDto> AdvanceRequest(EmpAdvance empAdvance)
        {
            throw new NotImplementedException();
            /*await _db.AddAsync(empAdvance);
            var result = _db.SaveChanges();

            CreateResponseDto createResponse = new CreateResponseDto
            {

            };*/

        }


        public void Update(EmpAdvance obj)
        {
            /*var objFromDb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);

            if (objFromDb != null)
            {

                objFromDb.Title = obj.Title;
                objFromDb.ISBN = obj.ISBN;
                objFromDb.Description = obj.Description;
                objFromDb.Price = obj.Price;
                objFromDb.Price50 = obj.Price50;
                objFromDb.Price100 = obj.Price100;
                objFromDb.Author = obj.Author;
                objFromDb.CategoryId = obj.CategoryId;
                objFromDb.CoverTypeId = obj.CoverTypeId;
                if (obj.ImageUrl != null)
                {
                    objFromDb.ImageUrl = obj.ImageUrl;
                }
                _db.Products.Update(objFromDb);
            }*/
        }
    }
}

