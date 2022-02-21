using MediatR;
using Site.Application.Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Queries.Messages.GetMessage
{
    public class GetMessageQuery:IRequest<List<MessageModel>>
    {
        public GetMessageQuery(int Id)
        {
            ID = Id;
        }

        public int ID { get; set; }
    }
}
