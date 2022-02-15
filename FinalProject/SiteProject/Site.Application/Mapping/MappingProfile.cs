﻿using AutoMapper;
using Site.Application.Features.Commands.Authentications.SignUpUser;
using Site.Application.Features.Commands.Users.AddUser;
using Site.Application.Models.Authentication;
using Site.Domain.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Mapping
{
    public class MappingProfile:Profile
    {
        public MappingProfile()
        {
            CreateMap<User, SignUpUserCommand>().ReverseMap();
            CreateMap<User, UserModel>().ReverseMap();
            CreateMap<User, AddUserCommand>().ReverseMap();
        }
    }
}
