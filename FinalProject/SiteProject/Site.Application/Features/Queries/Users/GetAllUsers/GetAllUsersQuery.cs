using MediatR;
using Site.Application.Models.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Queries.Users.GetAllUsers
{
    public class GetAllUsersQuery : IRequest<List<GetUserModel>>
    {
    }
}
