using MyLeasing.Api.Infrastructure.Data.Entities;
using MyLeasing.Common.Rest;

namespace MyLeasing.Api.Infrastructure.Mapper
{
    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<OwnerRest, OwnerDto>();
            CreateMap<OwnerDto, OwnerRest>();


            CreateMap<PropertyTypeRest, PropertyTypeDto>();
            CreateMap<PropertyTypeDto, PropertyTypeRest>();
        }
    }
}
