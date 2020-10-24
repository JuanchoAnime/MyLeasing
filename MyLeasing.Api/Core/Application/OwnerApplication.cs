﻿namespace MyLeasing.Api.Core.Application
{
    using AutoMapper;
    using MyLeasing.Api.Core.Application.Interface;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Api.Infrastructure.Repository.Interface;
    using MyLeasing.Common.Rest;

    public class OwnerApplication : GenericApplication<OwnerRest, OwnerDto>, IGenericApplication<OwnerRest>
    {
        public OwnerApplication(IOwnerRepository ownerRepository, IMapper mapper) : base(ownerRepository, mapper)
        {
        }
    }
}