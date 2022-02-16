using AutoMapper;
using MediatR;
using FluentValidation;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Site.Application.Models.User;
using Site.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Site.Application.Features.Queries.Users.GetUser
{
    public class GetUserQueryCommand : IRequestHandler<GetUserQuery, GetUserModel>
    {
        private readonly UserManager<User> _userManager;
        private readonly IMapper _mapper;
        private readonly GetUserValidator _validator;

        public GetUserQueryCommand(UserManager<User> userManager, IMapper mapper)
        {
            _userManager = userManager;
            _mapper = mapper;
            _validator = new GetUserValidator();
        }

        public async Task<GetUserModel> Handle(GetUserQuery request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var user = await _userManager.Users.FirstOrDefaultAsync(u => u.Id == request.ID);

            if(user == null)
                throw new InvalidOperationException("There is no user with this id number.");

            var userModel = _mapper.Map<GetUserModel>(user);
            return userModel;
        }
    }
}
