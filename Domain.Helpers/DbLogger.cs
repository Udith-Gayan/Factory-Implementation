using Factory_Implementation.Common.Entities;
using Factory_Implementation.Interfaces;

namespace Factory_Implementation.Domain.Helpers
{
    public class DbLogger : ILoggerOperations
    {
        private readonly IDataContext _dbcontext;

        public DbLogger(IDataContext context)
        {
            _dbcontext = context;
        }

        public async Task Clear()
        {
            List<Log>? recs = _dbcontext.Logs.Select(rec => rec).ToList();
            if (recs.Any())
            {
                _dbcontext.Logs.RemoveRange(recs);
                await _dbcontext.SaveChangesAsync();   
            }
        }

        public async Task LogAsync(string message)
        {
            DateTime dateTime = DateTime.Now;
            message = message.Trim();
            _dbcontext.Logs.Add(new Log() { CreatedAt = dateTime, Message = message });
            await _dbcontext.SaveChangesAsync();
        }
    }
}
