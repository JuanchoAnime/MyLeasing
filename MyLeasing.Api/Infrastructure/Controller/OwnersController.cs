﻿namespace MyLeasing.Api.Infrastructure.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using MyLeasing.Api.Core.Application;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Common.Rest;

    [Route("api/[controller]")]
    [ApiController]
    public class OwnersController : GenericController<OwnerRest, OwnerDto>
    {
        public OwnersController(OwnerApplication ownerApplication) : base(ownerApplication)
        {
        }
    }
}