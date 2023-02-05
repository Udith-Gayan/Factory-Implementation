using Factory_Implementation.Enums;

namespace Factory_Implementation.Interfaces
{
    public interface ILoggerServiceProvider
    {
        ILoggerOperations GetLogger(LoggerTypes type);
    }
}
