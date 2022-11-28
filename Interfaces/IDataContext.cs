using Factory_Implementation.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Factory_Implementation.Interfaces
{
    public class IDataContext : DbContext
    {
        public DbSet<Log> Logs { get; set; }
    }
}
