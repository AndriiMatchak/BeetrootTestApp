
using BeetrootTestApp.Common.Models.ViewModels;

namespace BeetrootTestApp.Services.Interfaces
{
    public interface ISenderService
    {
        CreatedEntityViewModel CreateSender(string senderIpAdress);

        SenderViewModel GetSenderByIpAddress(string senderIpAdress);
    }
}
