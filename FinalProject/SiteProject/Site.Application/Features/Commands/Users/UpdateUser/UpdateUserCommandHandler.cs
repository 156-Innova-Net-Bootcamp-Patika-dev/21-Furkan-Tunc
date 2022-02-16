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

namespace Site.Application.Features.Commands.Users.UpdateUser
{
    public class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand,int>
    {
        private readonly UserManager<User> _userManager;
        private readonly UpdateUserValidator _validator;

        public UpdateUserCommandHandler(UserManager<User> userManager)
        {
            _userManager = userManager;
            _validator = new UpdateUserValidator();
        }

        public async Task<int> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == request.Id);

            if (user == null)
                throw new InvalidOperationException("There is no user with this Id number.");

            user.FirstName = request.FirstName != default ? request.FirstName : user.FirstName;
            user.LastName = request.LastName != default ? request.LastName : user.LastName;
            user.PhoneNumber = request.PhoneNumber != default ? request.PhoneNumber : user.PhoneNumber;
            user.VehicleInformation = request.VehicleInformation != default ? request.VehicleInformation : user.VehicleInformation;

            await _userManager.UpdateAsync(user);
            return 1;
        }
    }
}
