namespace MyLeasing.Api.Core.Application
{
    using AutoMapper;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using MyLeasing.Common.Rest;

    public class PropertyTypeApplication : GenericApplication<PropertyTypeRest, PropertyTypeDto>
    {
        public PropertyTypeApplication(IPropertyTypeRepository propertyTypeRepository, IMapper mapper)
            : base(propertyTypeRepository, mapper)
        {

        }
    }
}
