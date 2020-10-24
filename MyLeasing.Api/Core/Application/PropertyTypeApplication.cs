namespace MyLeasing.Api.Core.Application
{
    using AutoMapper;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using MyLeasing.Common.AdvancedRest;
    using MyLeasing.Common.Rest;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class PropertyTypeApplication : GenericApplication<PropertyTypeRest, PropertyTypeDto>
    {
        private readonly IPropertyTypeRepository _propertyTypeRepository;

        public PropertyTypeApplication(IPropertyTypeRepository propertyTypeRepository, IMapper mapper)
            : base(propertyTypeRepository, mapper)
        {
            this._propertyTypeRepository = propertyTypeRepository;
        }

        public async Task<List<PropertyTypeWithProperties>> FindAllWithProperties()
        {
            var list = await _propertyTypeRepository.FindAllWithProperties();
            list.ForEach(pt =>{
                pt.Properties.ToList().ForEach( property => { property.PropertyType = null; });
            });
            return Mapper.Map<List<PropertyTypeWithProperties>>(list);
        }
    }
}
