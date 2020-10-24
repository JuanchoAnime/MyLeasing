namespace MyLeasing.Api.Infrastructure.Repository
{
    using Microsoft.EntityFrameworkCore;
    using MyLeasing.Api.Infrastructure.Data;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PropertyTypeRepository : GenericRepository<PropertyTypeDto>, IPropertyTypeRepository
    {
        public PropertyTypeRepository(DataContext dataContext) : base(dataContext)
        {
        }

        public async Task<List<PropertyTypeDto>> FindAllWithProperties()
        {
            return await Entity.Include(pt => pt.Properties).ToListAsync();
        }
    }
}
