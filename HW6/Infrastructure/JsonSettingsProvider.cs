using HW6.Abstractions;
using HW6.Domain;
using Microsoft.Extensions.Configuration;

namespace HW6.Infrastructure
{
    public sealed class JsonSettingsProvider : ISettingsProvider
    {
        private readonly IConfiguration _configuration;

        public JsonSettingsProvider(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public GameSettings GetSettings()
        {
            var section = _configuration.GetSection("Game");

            var settings = new GameSettings
            {
                MinNumber = section.GetValue<int>("MinNumber"),
                MaxNumber = section.GetValue<int>("MaxNumber"),
                MaxAttempts = section.GetValue<int>("MaxAttempts")
            };

            return settings;
        }
    }
}
