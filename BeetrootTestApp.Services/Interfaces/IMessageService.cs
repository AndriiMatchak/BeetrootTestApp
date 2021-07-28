using BeetrootTestApp.Common.Models.IncomeModels;
using BeetrootTestApp.Common.Models.ViewModels;
using System;
using System.Collections.Generic;

namespace BeetrootTestApp.Services.Interfaces
{
    public interface IMessageService
    {
        CreatedEntityViewModel CreateMessage(Guid senderId, string messageText);

        List<MessageViewModel> GetMessagesByFilter(GetMessagesFilterIncomeModel getMessagesFilter);
    }
}
