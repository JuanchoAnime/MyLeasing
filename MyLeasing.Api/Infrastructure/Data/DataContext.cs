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

        public DbSet<ContractDto> Contracts { get; set; }

        public DbSet<PropertyTypeDto> PropertyTypes { get; set; }

        public DbSet<LesseeDto> Lessees { get; set; }

        public DbSet<PropertyDto> Properties { get; set; }

        public DbSet<PropertyImageDto> PropertyImages { get; set; }
    }
}
