﻿using Site.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Domain.Entities
{
    public class BillPayment:EntityBase
    {
        public Bill Bill { get; set; }
        public int BillId { get; set; }
        public Apartment Apartment { get; set; }
        public int ApartmentId { get; set; }
        public decimal Electric { get; set; }
        public decimal Water { get; set; }
        public decimal NaturalGas { get; set; }
        public decimal Dues { get; set; }
        public string Month { get; set; }
    }
}