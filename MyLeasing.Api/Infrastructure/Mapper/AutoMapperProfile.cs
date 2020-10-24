namespace MyLeasing.Api.Infrastructure.Mapper
{
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Common.Rest;

    public class AutoMapperProfile : AutoMapper.Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<ContractRest, ContractDto>();
            CreateMap<ContractDto, ContractRest>();

            CreateMap<UserRest, UserDto>();
            CreateMap<UserDto, UserRest>();

            CreateMap<PropertyRest, PropertyDto>();
            CreateMap<PropertyDto, PropertyRest>();

            CreateMap<OwnerRest, OwnerDto>();
            CreateMap<OwnerDto, OwnerRest>();

            CreateMap<PropertyTypeRest, PropertyTypeDto>();
            CreateMap<PropertyTypeDto, PropertyTypeRest>();
        }
    }
}
