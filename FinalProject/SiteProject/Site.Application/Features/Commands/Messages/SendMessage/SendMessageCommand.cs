using MediatR;
using Site.Application.Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Commands.Messages.SendMessage
{
    public class SendMessageCommand:IRequest
    {
        public string Content { get; set; }
        public string From { get; set; }
        public string To { get; set; }
    }
}
