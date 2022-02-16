using MediatR;
using Site.Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Queries.Users.GetUser
{
    public class GetUserQuery : IRequest<GetUserModel>
    {
        public GetUserQuery(int Id)
        {
            ID = Id;
        }
        public int ID { get; set; }
    }
}
