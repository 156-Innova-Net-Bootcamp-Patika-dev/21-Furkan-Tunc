using MediatR;
using Site.Application.Models.Authentication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Queries.Authentications.GetUser
{
    public class GetUserByEmailAndPasswordQuery : IRequest<UserModel>
    {

        public string Email { get; set; }
        public string Password { get; set; }

        public GetUserByEmailAndPasswordQuery(SignInModel signInModel)
        {
            Email = signInModel.Email ?? throw new ArgumentException(nameof(Email));
            Password = signInModel.Password ?? throw new ArgumentException(nameof(Password));
        }

    }
}
