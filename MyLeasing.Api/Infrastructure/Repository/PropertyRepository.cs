﻿namespace MyLeasing.Api.Infrastructure.Repository
{
    using Microsoft.EntityFrameworkCore;
    using MyLeasing.Api.Infrastructure.Data;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using System.Collections.Generic;
    using System.Linq;
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
                    .Include(p => p.PropertyType)
                    .Include(p => p.Owner)
                        .ThenInclude(o => o.User).ToListAsync();
            return list;
        }

        public async Task<PropertyDto> AddProperty(PropertyDto property, int idOwner)
        {
            property.Owner = await _ownerRepository.FindAsync(idOwner);
            property.PropertyType = await this._propertyTypeRepository.FindById(property.PropertyType.Id);
            return await base.Save(property);
        }

        public override async Task<PropertyDto> Update(PropertyDto entity)
        {
            var property = Entity.AsNoTracking()
                        .Include(p=>p.Owner).ThenInclude(o=>o.User)
                        .Include(p=>p.Contracts)
                        .Include(p=>p.PropertiesImages).FirstOrDefault(p => p.Id.Equals(entity.Id));
            property.PropertyType = await this._propertyTypeRepository.FindById(entity.PropertyType.Id);
            entity.Owner = property.Owner;
            entity.Contracts = property.Contracts;
            entity.PropertiesImages = property.PropertiesImages;
            await base.Update(entity);
            entity.Contracts.ToList().ForEach(c => c.Property = null);
            return entity;
        }

        public async override Task<PropertyDto> FindById(int id)
        {
            var dto = await Entity.Include(p => p.Owner).ThenInclude(o => o.User)
                                  .Include(p => p.PropertiesImages)
                                  .Include(p => p.PropertyType)
                                  .Include(p => p.Contracts).ThenInclude(c => c.Lessee).ThenInclude(l => l.User)
                                  .FirstOrDefaultAsync(p => p.Id.Equals(id));
            if (dto == null)
                throw new System.Exception("Id no encontrado");
            dto.Contracts.ToList().ForEach(c => { 
                c.Property = null; 
                c.Owner = null; 
                c.Lessee.Contracts = new List<ContractDto>(); 
            });
            dto.Owner.Properties = null;
            dto.Owner.Contracts = null;
            return dto;
        }

        public async Task<PropertyDto> FindAsync(int id)
        {
            var dto = await Entity.Include(p => p.Owner).ThenInclude(o => o.User)
                                  .Include(p => p.PropertiesImages)
                                  .Include(p => p.PropertyType)
                                  .Include(p => p.Contracts).ThenInclude(c => c.Lessee).ThenInclude(l => l.User)
                                  .FirstOrDefaultAsync(p => p.Id.Equals(id));
            if (dto == null)
                throw new System.Exception("Id no encontrado");
            return dto;
        }
    }
}
