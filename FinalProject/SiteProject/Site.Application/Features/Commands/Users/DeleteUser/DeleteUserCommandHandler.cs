using MediatR;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Site.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Site.Application.Features.Commands.Users.DeleteUser
{
    public class DeleteUserCommandHandler : IRequestHandler<DeleteUserCommand,int>
    {
        private readonly UserManager<User> _userManager;
        private readonly DeleteUserValidator _validator;

        public DeleteUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
            _validator = new DeleteUserValidator();
        }

        public async Task<int> Handle(DeleteUserCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == request.ID);

            if (user==null)
                throw new InvalidOperationException("There is no user with this Id number.");

            await _userManager.DeleteAsync(user);
            return 1;
        }
    }
}
