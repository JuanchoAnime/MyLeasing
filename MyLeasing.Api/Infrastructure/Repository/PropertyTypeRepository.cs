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

        public async Task<PropertyTypeDto> FindWithProperties(int id)
        {
            var dto = await Entity.Include(tp => tp.Properties).FirstOrDefaultAsync(tp => tp.Id.Equals(id));
            if (dto == null)
                throw new System.Exception("Id no encontrado");
            return dto;
        }
    }
}
