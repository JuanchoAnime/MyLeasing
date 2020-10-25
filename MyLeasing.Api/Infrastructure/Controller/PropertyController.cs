namespace MyLeasing.Api.Infrastructure.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using MyLeasing.Api.Core.Application;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Common.Rest;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class PropertyController : GenericController<PropertyRest, PropertyDto>
    {
        private readonly PropertyApplication _propertyApplication;

        public PropertyController(PropertyApplication propertyApplication)
            : base(propertyApplication)
        {
            this._propertyApplication = propertyApplication;
        }

        public override async Task<IActionResult> Get()
        {
            var list = await _propertyApplication.GetPropertiesWithOwner();
            return Ok(list);
        }

        public override async Task<IActionResult> GetById([FromRoute] int id)
        {
            var data = await this._propertyApplication.GetEntityInfoById(id);
            return Ok(data);
        }
    }
}
