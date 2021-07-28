using BeetrootTestApp.HostedServices.BaseServices;
using BeetrootTestApp.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BeetrootTestApp.HostedServices.HostedServices
{
    public class MessagesReceiver : BackgroundService
    {
        private readonly IServiceScopeFactory _serviceScopeFactory;
        public MessagesReceiver(IServiceScopeFactory serviceScopeFactory)
        {
            _serviceScopeFactory = serviceScopeFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            using (var scope = _serviceScopeFactory.CreateScope())
            {
                var messageService = scope.ServiceProvider.GetService<IMessageService>();
                var cofigurationService = scope.ServiceProvider.GetService<IConfigurationManagerService>();
                var senderService = scope.ServiceProvider.GetService<ISenderService>();

                UdpClient receiver = new UdpClient(cofigurationService.GetDefaultPortForMessagesListening());

                try
                {
                    while (!stoppingToken.IsCancellationRequested)
                    {
                        ReceiveMessages(receiver, messageService, senderService);
                    }
                }
                catch (Exception ex)
                {
                    // We can log some error message
                }
                finally
                {
                    receiver.Close();
                }
            }
        }

        private void ReceiveMessages(UdpClient receiver, IMessageService messageService, ISenderService senderService)
        {
            IPEndPoint remoteIp = null;

            byte[] data = receiver.Receive(ref remoteIp);
            if (remoteIp.Address == null)
                return;

            var senderId = senderService.GetSenderByIpAddress(remoteIp.Address.ToString())?.Id;
            if (!senderId.HasValue)
                senderId = senderService.CreateSender(remoteIp.Address.ToString())?.EntityId;

            if (!senderId.HasValue)
                return;

            string message = Encoding.Unicode.GetString(data);
            messageService.CreateMessage(senderId.Value, message);
        }
    }
}
