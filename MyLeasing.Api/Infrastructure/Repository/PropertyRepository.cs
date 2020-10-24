namespace MyLeasing.Api.Infrastructure.Repository
{
    using Microsoft.EntityFrameworkCore;
    using MyLeasing.Api.Infrastructure.Data;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PropertyRepository: GenericRepository<PropertyDto>, IPropertyRepository
    {
        private readonly IOwnerRepository _ownerRepository;
        private readonly IPropertyTypeRepository _propertyTypeRepository;

        public PropertyRepository(DataContext dataContext, IOwnerRepository ownerRepository, IPropertyTypeRepository propertyTypeRepository)
            : base(dataContext)
        {
            this._ownerRepository = ownerRepository;
            this._propertyTypeRepository = propertyTypeRepository;
        }

        public async override Task<List<PropertyDto>> FindAll()
        {
            var list = await Entity
                    .Include(p => p.PropertiesImages)
                    .Include(p => p.Owner)
                        .ThenInclude(o => o.User).ToListAsync();
            return list;
        }

        public async Task<PropertyDto> AddProperty(PropertyDto property, int idOwner, int idPropertyType)
        {
            property.Owner = await _ownerRepository.FindAsync(idOwner);
            property.PropertyType = await this._propertyTypeRepository.FindById(idPropertyType);
            return await base.Save(property);
        }
    }
}
