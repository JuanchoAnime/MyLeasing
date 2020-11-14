namespace MyLeasing.Api.Infrastructure.Mapper
{
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Common.AdvancedRest;
    using MyLeasing.Common.Response;
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

            CreateMap<PropertyWithOwner, PropertyDto>();
            CreateMap<PropertyDto, PropertyWithOwner>();

            CreateMap<OwnerRest, OwnerDto>();
            CreateMap<OwnerDto, OwnerRest>();

            CreateMap<ManagerRest, ManagerDto>();
            CreateMap<ManagerDto, ManagerRest>();

            CreateMap<LesseeRest, LesseeDto>();
            CreateMap<LesseeDto, LesseeRest>();

            CreateMap<OwnerDto, OwnerResponse>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.Document, opt => opt.MapFrom(src => src.User.Document))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.User.Address))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));
            CreateMap<LesseeDto, LesseeResponse>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.User.FirstName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.User.LastName))
                .ForMember(dest => dest.Phone, opt => opt.MapFrom(src => src.User.PhoneNumber))
                .ForMember(dest => dest.Document, opt => opt.MapFrom(src => src.User.Document))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.User.Address))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.User.Email));
            CreateMap<PropertyDto, PropertyResponse>()
                .ForMember(dest => dest.PropertyType, opt => opt.MapFrom(src => src.PropertyType.Name));
            CreateMap<PropertyImageDto, PropertyImageResponse>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => $"{src.ImageUrl}"));

            CreateMap<PropertyTypeRest, PropertyTypeDto>();
            CreateMap<PropertyTypeDto, PropertyTypeRest>();

            CreateMap<PropertyTypeDto, PropertyTypeWithProperties>();
            CreateMap<PropertyTypeWithProperties, PropertyTypeDto>();
        }
    }
}
