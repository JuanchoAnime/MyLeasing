namespace MyLeasing.Api.Core.Application
{
    using AutoMapper;
    using Microsoft.AspNetCore.Http;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using MyLeasing.Common.AdvancedRest;
    using MyLeasing.Common.Rest;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PropertyApplication: GenericApplication<PropertyRest, PropertyDto>
    {
        private readonly IPropertyRepository propertyRepository;
        private readonly IPropertyImageRepository propertyImageRepository;

        public PropertyApplication(IPropertyRepository propertyRepository, IMapper mapper, IPropertyImageRepository propertyImageRepository)
            : base(propertyRepository, mapper)
        {
            this.propertyRepository = propertyRepository;
            this.propertyImageRepository = propertyImageRepository;
        }

        public async Task<List<PropertyWithOwner>> GetPropertiesWithOwner()
        {
            var list = await propertyRepository.FindAll();
            list.ForEach(p => p.Owner.Properties = new List<PropertyDto>());
            return Mapper.Map<List<PropertyWithOwner>>(list);
        }

        public async override Task<PropertyRest> Save(PropertyRest entity)
        {
            entity.Contracts = new List<ContractRest>();
            entity.PropertiesImages = new List<PropertyImageRest>();
            var data = await this.propertyRepository.AddProperty(Mapper.Map<PropertyDto>(entity), entity.IdOwner);
            return Mapper.Map<PropertyRest>(data);
        }

        public async Task<PropertyWithOwner> GetEntityInfoById(int id)
        {
            var dto = await propertyRepository.FindById(id);
            return Mapper.Map<PropertyWithOwner>(dto);
        }

        public async Task<PropertyWithOwner> SaveImage(int idProperty, IFormFile formFile)
        {
            var data = await propertyImageRepository.SaveData(idProperty, formFile);
            return Mapper.Map<PropertyWithOwner>(data);
        }
    }
}
