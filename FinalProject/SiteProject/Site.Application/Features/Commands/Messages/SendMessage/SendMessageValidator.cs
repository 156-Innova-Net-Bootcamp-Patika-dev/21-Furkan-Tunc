using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Site.Application.Features.Commands.Messages.SendMessage
{
    public class SendMessageValidator : AbstractValidator<SendMessageCommand>
    {
        public SendMessageValidator()
        {
            RuleFor(m => m.Content).NotEmpty();
            RuleFor(m => m.From).EmailAddress();
            RuleFor(m => m.To).EmailAddress();
        }
    }
}
