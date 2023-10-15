using HealthClaim.BAL.Repository.Interface;
using HealthClaim.DAL.Models;
using HealthClaim.Model.Dtos.Employee;
using HealthClaim.Model.Dtos.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HealthClaim.API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeRepository employeeRepository;
        public EmployeeController(IEmployeeRepository _employeeRepository)
        {
            employeeRepository = _employeeRepository;
        }

        // GET: api/<EmployeeController>
        [HttpGet("Employee")]
        public async Task<ResponeModel> Get()
        {
           
            var response = await employeeRepository.Get(0);
            return response;
        }
        [HttpGet("GetEmpRelation")]
        //[Route("/api/GetEmpRelation")]
        public async Task<ResponeModel> GetEmpRelation()
        {
            var response = await employeeRepository.GetEmpRelation(0);
            return response;
        }

        // GET api/<EmployeeController>/5
        [HttpGet("{id}")]
        public async Task<ResponeModel> Get(int id)
        {
            var response = await employeeRepository.Get(id);
            return response;
        }
        [HttpGet("GetEmpRelationById/{id}")]
        //[Route("/api/GetEmpRelationById/{id}")]
        public async Task<ResponeModel> GetEmpRelationById(int id)
        {
            var response = await employeeRepository.GetEmpRelation(id);
            return response;
        }

        // POST api/<EmployeeController>
        [HttpPost]
        public async Task<ResponeModel> Post([FromBody] EmployeeModel employee)
        {
            var response = await employeeRepository.Create(employee);
            return response;
        }
        // POST api/<EmployeeController>
        [HttpPost("CreateEmpRelation")]
        //[Route("/api/CreateEmpRelation")]
        public async Task<ResponeModel> CreateEmpRelation([FromBody] EmpRelationModel empRelationModel)
        {
            var response = await employeeRepository.CreateEmpRelation(empRelationModel);
            return response;
        }

        // PUT api/<EmployeeController>/5
        [HttpPut("{id}")]
        public async Task<ResponeModel> Put(int id, [FromBody] EmployeeModel employee)
        {
            var response = await employeeRepository.Update(employee, id);
            return response;
        }
        
        [HttpPut("UpdateEmpRelation/{id}")]
        //[Route("/api/UpdateEmpRelation")]
        public async Task<ResponeModel> UpdateEmpRelation(int id, [FromBody] EmpRelationModel employee)
        {
            var response = await employeeRepository.UpdateEmpRelation(employee, id);
            return response;
        }

        // DELETE api/<EmployeeController>/5
        [HttpDelete("{id}")]
        public async Task<ResponeModel> Delete(int id)
        {
            var response = await employeeRepository.Delete(id);
            return response;
        }
       
        [HttpDelete("DeleteEmpRelation")]
        //[Route("/api/DeleteEmpRelation")]
        public async Task<ResponeModel> DeleteEmpRelation(int id)
        {
            var response = await employeeRepository.DeleteEmpRelation(id);
            return response;
        }
    }
}
