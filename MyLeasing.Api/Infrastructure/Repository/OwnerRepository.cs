namespace MyLeasing.Api.Infrastructure.Repository
{
    using Microsoft.EntityFrameworkCore;
    using MyLeasing.Api.Infrastructure.Data;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class OwnerRepository: GenericRepository<OwnerDto>, IOwnerRepository
    {
        private readonly IPropertyTypeRepository _typeRepository;
        private readonly IPropertyRepository _propertyRepository;

        public OwnerRepository(DataContext dataContext, IPropertyTypeRepository typeRepository, IPropertyRepository propertyRepository)
            : base(dataContext)
        {
            this._typeRepository = typeRepository;
            this._propertyRepository = propertyRepository;
        }

        public async Task<PropertyDto> AddProperty(PropertyDto property, int idOwner, int idPropertyType)
        {
            property.Owner = await this.FindById(idOwner);
            property.PropertyType = await this._typeRepository.FindById(idPropertyType);
            return await _propertyRepository.Save(property);
        }

        public async override Task<List<OwnerDto>> FindAll()
        {
            var owners = await Entity.Include(o => o.User)
                .ToListAsync();
            return owners;
        }

        public async override Task<OwnerDto> FindById(int id)
        {
            var dto = await  Entity.Include(o => o.User)
                .Include(o => o.Properties).ThenInclude(p => p.PropertiesImages)
                .Include(o => o.Properties).ThenInclude(p => p.PropertyType)
                .Where(o => o.Id.Equals(id))
                .FirstOrDefaultAsync();
            if (dto == null)
                throw new Exception("Id no encontrado");
            return dto;
        }
    }
}
