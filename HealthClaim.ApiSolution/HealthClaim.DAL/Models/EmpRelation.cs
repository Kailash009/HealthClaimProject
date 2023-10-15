﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class EmpRelation : BaseModel
    {
        [Required]
        public string Name { get; set; } 
        public string Description { get; set; } = string.Empty;
    }
}
