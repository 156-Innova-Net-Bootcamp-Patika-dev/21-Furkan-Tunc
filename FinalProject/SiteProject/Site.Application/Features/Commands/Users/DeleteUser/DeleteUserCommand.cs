using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Commands.Users.DeleteUser
{
    public class DeleteUserCommand : IRequest<int>
    {
        public DeleteUserCommand(int Id)
        {
            ID = Id;
        }
        public int ID { get; set; }
    }
}
