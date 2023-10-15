using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.Model.Dtos.Employee
{
    public class EmployeeModel
    {
        [Required]
        public string EmpId { get; set; }
        public string EmailId { get; set; }
        [Required]
        public string Mobile { get; set; }
        public string Designation { get; set; }
        public string BloodGroup { get; set; }
        //public long CreatedBy { get; set; }
        public bool IsActive { get; set; }
        //public long UpdatedBy { get; set; }
    }
}
