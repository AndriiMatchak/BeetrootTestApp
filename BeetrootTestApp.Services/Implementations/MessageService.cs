using BeetrootTestApp.Common.Models.IncomeModels;
using BeetrootTestApp.Common.Models.ViewModels;
using BeetrootTestApp.DataAccess.EntitesModel;
using BeetrootTestApp.Repositories.Interfaces;
using BeetrootTestApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BeetrootTestApp.Services.Implementations
{
    public class MessageService : IMessageService
    {
        private readonly IBaseRepository<Message> _messageRepository;
        public MessageService(IBaseRepository<Message> messageRepository)
        {
            _messageRepository = messageRepository;
        }

        public CreatedEntityViewModel CreateMessage(Guid senderId, string messageText)
        {
            var message = new Message()
            {
                MessageText = messageText,
                SenderId = senderId,
            };
            _messageRepository.Add(message);
            return new CreatedEntityViewModel(message.Id);
        }

        public List<MessageViewModel> GetMessagesByFilter(GetMessagesFilterIncomeModel getMessagesFilter)
        {
            return _messageRepository.GetAll(m =>
                m.Sender.SenderIPAddress == getMessagesFilter.SenderIpAddress &&
                (m.CreatedDate >= getMessagesFilter.FromMessagesDateTime &&
                m.CreatedDate <= getMessagesFilter.ToMessagesDateTime ||
                (m.ModifiedDate >= getMessagesFilter.FromMessagesDateTime &&
                m.ModifiedDate <= getMessagesFilter.ToMessagesDateTime))).Select(m => 
                new MessageViewModel()
                {
                    Id = m.Id,
                    MessageText = m.MessageText,
                    CreatedDate = m.CreatedDate,
                    ModifiedDate = m.ModifiedDate,
                }).ToList();
        }
    }
}
