namespace MyLeasing.Api.Core.Application
{
    using AutoMapper;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using MyLeasing.Common.AdvancedRest;
    using MyLeasing.Common.Rest;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class PropertyApplication: GenericApplication<PropertyRest, PropertyDto>
    {
        private readonly IPropertyRepository propertyRepository;

        public PropertyApplication(IPropertyRepository propertyRepository, IMapper mapper): base(propertyRepository, mapper)
        {
            this.propertyRepository = propertyRepository;
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

        public override Task<PropertyRest> GetEntity(int id)
        {
            return base.GetEntity(id);
        }
    }
}
