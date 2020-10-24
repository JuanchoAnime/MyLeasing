namespace MyLeasing.Api.Infrastructure.Data
{
    using Microsoft.EntityFrameworkCore;
    using MyLeasing.Api.Infrastructure.Data.Entities;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<OwnerDto> Owners { get; set; }
    }
}
