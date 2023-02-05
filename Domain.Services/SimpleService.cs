using Factory_Implementation.Enums;
using Factory_Implementation.Interfaces;

namespace Factory_Implementation.Domain.Services
{
    public class SimpleService : ISimpleService
    {
        private readonly ILoggerOperations _logger;
        private readonly IConfiguration _configuration;

        public SimpleService(ILoggerServiceProvider loggerServiceProvider, IConfiguration configuration)
        {
            _configuration = configuration;
            _logger = loggerServiceProvider.GetLogger((LoggerTypes)Enum.Parse(typeof(LoggerTypes), _configuration.GetValue<string>("Logging:LoggingType"), true));
        }

        public async Task WriteMessageAsync(string message = null)
        {
            await _logger.LogAsync(message);
        }

        public async Task ClearLogFiles()
        {
            await _logger.Clear();
        }


    }
}
