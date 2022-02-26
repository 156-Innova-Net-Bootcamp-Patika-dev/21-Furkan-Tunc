using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Site.WebUI.Models.Messages
{
    public class MessageListModel
    {
        public string Content { get; set; }
        public string From { get; set; }
        public string Read { get; set; }
    }
}
