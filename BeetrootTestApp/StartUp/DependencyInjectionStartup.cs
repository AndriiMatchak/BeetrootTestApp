using BeetrootTestApp.HostedServices.HostedServices;
using BeetrootTestApp.Repositories.Implementations;
using BeetrootTestApp.Repositories.Interfaces;
using BeetrootTestApp.Services.Implementations;
using BeetrootTestApp.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BeetrootTestApp.Web.StartUp
{
    public class DependencyInjectionStartup
    {
        public static void Inject(IServiceCollection services)
        {
            #region Repositories

            services.AddTransient(typeof(IBaseRepository<>), typeof(BaseRepository<>));

            #endregion

            #region Services

            services.AddScoped<IConfigurationManagerService, ConfigurationManagerService>();

            services.AddScoped<IMessageService, MessageService>();

            services.AddScoped<ISenderService, SenderService>();

            #endregion

            #region HostedServices

            services.AddSingleton<MessagesReceiver>();

            #endregion
        }
    }
}
