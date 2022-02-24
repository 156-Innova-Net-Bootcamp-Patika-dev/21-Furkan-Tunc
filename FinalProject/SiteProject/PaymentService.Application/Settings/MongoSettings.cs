using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PaymentService.Application.Settings
{
    public class MongoSettings
    {
        public string MongoDbConnectionString { get; set; }
        public string Database { get; set; }
    }
}
