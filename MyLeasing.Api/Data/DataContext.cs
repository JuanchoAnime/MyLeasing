namespace MyLeasing.Api.Data
{
    using Microsoft.EntityFrameworkCore;
    using MyLeasing.Api.Data.Entities;

    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<OwnerDto> Owners { get; set; }
    }
}
