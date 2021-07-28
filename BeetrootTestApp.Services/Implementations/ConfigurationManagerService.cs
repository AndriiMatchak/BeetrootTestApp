using BeetrootTestApp.Services.Interfaces;
using Microsoft.Extensions.Configuration;
using System;

namespace BeetrootTestApp.Services.Implementations
{
    public class ConfigurationManagerService : IConfigurationManagerService
    {
        private readonly IConfiguration _configuration;

        public ConfigurationManagerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public int GetDefaultPortForMessagesListening() {
            var defaultPort = _configuration["DefaultPortForMessagesListening"];
            return Convert.ToInt32(defaultPort);
        }
    }
}
