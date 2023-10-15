using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthClaim.DAL.Models
{
    public class UplodDocType:BaseModel
    {
        public string Name { get; set; }
        public bool IsBillable { get; set; }
    }
}
