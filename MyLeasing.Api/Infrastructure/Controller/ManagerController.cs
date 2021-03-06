﻿namespace MyLeasing.Api.Infrastructure.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using MyLeasing.Api.Core.Application;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Common.Rest;

    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController: GenericController<ManagerRest, ManagerDto>
    {
        public ManagerController(ManagerApplication managerApplication): base(managerApplication)
        {
        }
    }
}
