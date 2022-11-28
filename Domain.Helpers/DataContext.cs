using Factory_Implementation.Common.Entities;
using Factory_Implementation.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Factory_Implementation.Domain.Helpers
{
    public class DataContext : IDataContext
    {

        protected readonly IConfiguration Configuration;

        public DataContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sqlite database
            options.UseSqlite(Configuration.GetConnectionString("WebApiDatabase"));
        }

        public DbSet<Log> Logs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasKey(e => e.Id);
                entity.Property(e => e.CreatedAt);
                entity.Property(e => e.Message);

                entity.HasData(new Log
                {
                    Id = 1,
                    CreatedAt = DateTime.Now,
                    Message = "Init Log"
                });
            });
        }
    }
}
