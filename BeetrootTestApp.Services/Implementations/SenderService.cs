using BeetrootTestApp.Common.Models.ViewModels;
using BeetrootTestApp.DataAccess.EntitesModel;
using BeetrootTestApp.Repositories.Interfaces;
using BeetrootTestApp.Services.Interfaces;

namespace BeetrootTestApp.Services.Implementations
{
    public class SenderService : ISenderService
    {
        private readonly IBaseRepository<Sender> _senderRepository;
        public SenderService(IBaseRepository<Sender> senderRepository)
        {
            _senderRepository = senderRepository;
        }

        public CreatedEntityViewModel CreateSender(string senderIpAdress)
        {
            var sender = new Sender()
            {
                SenderIPAddress = senderIpAdress,
            };
            _senderRepository.Add(sender);
            return new CreatedEntityViewModel(sender.Id);
        }

        public SenderViewModel GetSenderByIpAddress(string senderIpAdress)
        {
            var dbSender = _senderRepository.Get(s => s.SenderIPAddress == senderIpAdress);
            if (dbSender == null)
                return null;

            return new SenderViewModel()
            {
                Id = dbSender.Id,
                SenderIPAddress = dbSender.SenderIPAddress,
                CreatedDate = dbSender.CreatedDate,
                ModifiedDate = dbSender.ModifiedDate,
            };
        }
    }
}
