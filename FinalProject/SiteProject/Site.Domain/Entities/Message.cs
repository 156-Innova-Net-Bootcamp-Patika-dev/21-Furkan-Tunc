﻿using Site.Domain.Entities.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Domain.Entities
{
    public class Message:EntityBase
    {
        public string Content { get; set; }
        public string From { get; set; }
        public string To { get; set; }
        public bool Read { get; set; }
    }
}
