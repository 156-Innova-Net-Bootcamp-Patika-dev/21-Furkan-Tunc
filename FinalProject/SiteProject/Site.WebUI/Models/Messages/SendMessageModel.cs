using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.WebUI.Models.Messages
{
    public class SendMessageModel
    {
        public string Content { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
