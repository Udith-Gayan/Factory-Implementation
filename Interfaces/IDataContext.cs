using Factory_Implementation.Common.Entities;
using Microsoft.EntityFrameworkCore;

namespace Factory_Implementation.Interfaces
{
    public interface IDataContext
    {
        public DbSet<Log> Logs { get; set; }

        public Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess = true, CancellationToken cancellationToken = default);

    }
}
