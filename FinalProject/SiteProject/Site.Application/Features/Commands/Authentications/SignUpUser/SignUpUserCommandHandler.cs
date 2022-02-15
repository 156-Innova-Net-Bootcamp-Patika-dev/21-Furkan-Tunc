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

namespace Site.Application.Features.Commands.Authentications.SignUpUser
{
    public class SignUpUserCommandHandler : IRequestHandler<SignUpUserCommand, int>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        SignUpUserValidatior _validator;

        public SignUpUserCommandHandler(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _validator = new SignUpUserValidatior();
        }

        public async Task<int> Handle(SignUpUserCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var userEntity = _mapper.Map<User>(request);

            userEntity.UserName = request.Email;

            var userCreateResult = await _userManager.CreateAsync(userEntity, request.Password);

            if (userCreateResult.Succeeded)
            {
                var user = _userManager.Users.SingleOrDefault(u => u.Email == request.Email);

                return user.Id;
            }

            return 0;
        }
    }
}
