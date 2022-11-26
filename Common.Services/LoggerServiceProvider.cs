using Factory_Implementation.Domain.Helpers;
using Factory_Implementation.Enums;
using Factory_Implementation.Interfaces;

namespace Factory_Implementation.Common.Services
{
    public class LoggerServiceProvider
    {
        public ILoggerOperations GetLogger(LoggerTypes type)
        {
            switch (type)
            {
                case LoggerTypes.FILE:
                    return new FileLogger();
                case LoggerTypes.DB:
                    return new DbLogger();
            }

            return new FileLogger();  //  Default logger
        }
    }
}
