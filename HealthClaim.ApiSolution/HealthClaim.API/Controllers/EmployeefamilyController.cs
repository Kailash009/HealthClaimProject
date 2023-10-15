using HealthClaim.BAL.Repository.Concrete;
using HealthClaim.BAL.Repository.Interface;
using HealthClaim.Model.Dtos.Employee;
using HealthClaim.Model.Dtos.Employeefamily;
using HealthClaim.Model.Dtos.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HealthClaim.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeefamilyController : ControllerBase
    {
        private readonly IEmployeefamilyRepository _employeefamilyRepository;
        public EmployeefamilyController(IEmployeefamilyRepository employeefamilyRepository)
        {
            _employeefamilyRepository = employeefamilyRepository;
        }

        // GET: api/<EmployeefamilyController>
        [HttpGet("GetFamily")]
        public async Task<ResponeModel> Get()
        {
            var response = await _employeefamilyRepository.GetFamily(0);
            return response;
        }

        // GET api/<EmployeefamilyController>/5
        [HttpGet("GetFamily/{id}")]
        public async Task<ResponeModel> Get(int id)
        {
            var response = await _employeefamilyRepository.GetFamily(id);
            return response;
        }

        // POST api/<EmployeefamilyController>
        [HttpPost("CreateEmpRelation")]
        //[Route("/api/CreateEmpRelation")]
        public async Task<ResponeModel> CreateEmpFaimly([FromBody] EmployeefamilyModel employeefamilyModel)
        {
            var response = await _employeefamilyRepository.Create(employeefamilyModel);
            return response;
        }

        // PUT api/<EmployeefamilyController>/5
        [HttpPut("{id}")]
        public async Task<ResponeModel> Put(int id, [FromBody] UpdateEmployeefamilyModel employee)
        {
            var response = await _employeefamilyRepository.Update(employee, id);
            return response;
        }

        // DELETE api/<EmployeefamilyController>/5
        [HttpDelete("{id}")]
        public async Task<ResponeModel> Delete(int id)
        {
            var response = await _employeefamilyRepository.Delete(id);
            return response;
        }
    }
}
