using AutoMapper;
using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using Newtonsoft.Json;
using Site.Application.Contracts.Persistence.Repositories.Messages;
using Site.Application.Models.Message;
using Site.Domain.Dtos;
using Site.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Site.Application.Features.Queries.Messages.GetMessage
{
    public class GetMessageQueryHandler : IRequestHandler<GetMessageQuery, List<MessageModel>>
    {
        private readonly IMessageRepository _messageRepository;
        private readonly IMapper _mapper;
        private readonly IDistributedCache _distributedCache;

        public GetMessageQueryHandler(IMessageRepository messageRepository, IMapper mapper, IDistributedCache distributedCache)
        {
            _messageRepository = messageRepository;
            _mapper = mapper;
            _distributedCache = distributedCache;
        }

        public async Task<List<MessageModel>> Handle(GetMessageQuery request, CancellationToken cancellationToken)
        {
            string cacheKey = "GetMessages";
            string json;
            IReadOnlyList<MessageDto> messages;
            var messagesFromCache = await _distributedCache.GetAsync(cacheKey);

            if (messagesFromCache != null)
            {
                json = Encoding.UTF8.GetString(messagesFromCache);
                messages = JsonConvert.DeserializeObject<List<MessageDto>>(json);
                return _mapper.Map<List<MessageModel>>(messages);
            }
            else
            {
                messages = await _messageRepository.GetMessages(request.ID);

                //Çekilen mesajlar okundu olarak işaretlendi
                Message newMessages;
                for (int i = 0; i < messages.Count; i++)
                {
                    newMessages = await _messageRepository.GetByIdAsync(messages[i].Id);
                    newMessages.Read = true;
                    await _messageRepository.UpdateAsync(newMessages);
                }

                json = JsonConvert.SerializeObject(messages);
                messagesFromCache = Encoding.UTF8.GetBytes(json);
                var options = new DistributedCacheEntryOptions()
                    .SetSlidingExpiration(TimeSpan.FromMinutes(10))
                    .SetAbsoluteExpiration(DateTime.Now.AddHours(1));
                await _distributedCache.SetAsync(cacheKey, messagesFromCache, options);
                return _mapper.Map<List<MessageModel>>(messages);
            }
        }
    }
}
