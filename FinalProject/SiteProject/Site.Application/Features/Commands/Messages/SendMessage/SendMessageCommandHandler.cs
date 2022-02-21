using AutoMapper;
using MediatR;
using FluentValidation;
using Site.Application.Contracts.Persistence.Repositories.Messages;
using Site.Application.Models.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Site.Domain.Entities;
using Microsoft.Extensions.Caching.Distributed;

namespace Site.Application.Features.Commands.Messages.SendMessage
{
    public class SendMessageCommandHandler : IRequestHandler<SendMessageCommand>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;
        private readonly SendMessageValidator _validator;

        public SendMessageCommandHandler(IMessageRepository messageRepository,IMapper mapper, IDistributedCache distributedCache)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _distributedCache = distributedCache;
            _validator = new SendMessageValidator();
        }
        
        public async Task<Unit> Handle(SendMessageCommand request, CancellationToken cancellationToken)
        {
            await _validator.ValidateAndThrowAsync(request);

            var message = _mapper.Map<Message>(request);
            
            await _messageRepository.AddAsync(message);

            await _distributedCache.RemoveAsync("GetMessages");

            return Unit.Value;
        }
    }
}
