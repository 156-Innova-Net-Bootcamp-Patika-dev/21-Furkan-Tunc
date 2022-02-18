using Site.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Domain.Entities
{
    public class Bill:EntityBase
    {
        public decimal Electric { get; set; }
        public decimal Water { get; set; }
        public decimal NaturalGas { get; set; }
        public decimal Dues { get; set; }
        public string Month { get; set; }
    }
}
