using Factory_Implementation.Domain.Helpers;
using Factory_Implementation.Enums;
using Factory_Implementation.Interfaces;

namespace Factory_Implementation.Common.Services
{
    public class LoggerServiceProvider : ILoggerServiceProvider
    {
        private readonly IDataContext _context;

        public LoggerServiceProvider(IDataContext context)
        {
            _context = context;
        }

        public ILoggerOperations GetLogger(LoggerTypes type)
        {
            switch (type)
            {
                case LoggerTypes.FILE:
                    return new FileLogger();
                case LoggerTypes.DB:
                    return new DbLogger(_context);
            }

            return new FileLogger();  //  Default logger
        }
    }
}
