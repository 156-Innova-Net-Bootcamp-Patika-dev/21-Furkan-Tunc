using Site.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Domain.Entities
{
    public class Apartment :EntityBase
    {
        public string Blok { get; set; }
        public string Status { get; set; }
        public string Type { get; set; }
        public int Floor { get; set; }
        public int ApartmentNumber { get; set; }
        public string Owner { get; set; }
    }
}
