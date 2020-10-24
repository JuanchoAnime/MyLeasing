namespace MyLeasing.Api.Infrastructure.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using MyLeasing.Api.Core.Application;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Common.Rest;
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

        [HttpGet("WithOwner")]
        public async Task<IActionResult> GetPropertiesWithOwner() 
        {
            var list = await _propertyApplication.GetPropertiesWithOwner();
            return Ok(list);
        }
    }
}
