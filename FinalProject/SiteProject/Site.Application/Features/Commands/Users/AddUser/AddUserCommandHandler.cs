using AutoMapper;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Site.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Site.Application.Features.Commands.Users.AddUser
{
    public class AddUserCommandHandler : IRequestHandler<AddUserCommand, string>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly AddUserValidator _validator;
        Random _rnd;

        public AddUserCommandHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _validator = new AddUserValidator();
            _rnd = new Random();
        }
        public async Task<string> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var user = _mapper.Map<User>(request);

            var pin = _rnd.Next(1000, 9999).ToString();

            user.UserName = request.Email;
            var createdUser = await _userManager.CreateAsync(user,pin);

            if (createdUser.Succeeded)
            {
                var userEntity = _userManager.Users.SingleOrDefault(u => u.Email == request.Email);

                return pin;
            }

            return null;

        }
    }
}
