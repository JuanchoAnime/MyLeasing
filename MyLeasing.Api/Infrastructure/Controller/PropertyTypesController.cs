namespace MyLeasing.Api.Infrastructure.Controller
{
    using Microsoft.AspNetCore.Mvc;
    using MyLeasing.Api.Core.Application;
    using MyLeasing.Api.Infrastructure.Data.Entities;
    using MyLeasing.Common.Rest;
    using System.Threading.Tasks;

    [Route("api/[controller]")]
    [ApiController]
    public class PropertyTypesController : GenericController<PropertyTypeRest, PropertyTypeDto>
    {
        private readonly PropertyTypeApplication _application;

        public PropertyTypesController(PropertyTypeApplication application) : base(application)
        {
            this._application = application;
        }

        [HttpGet]
        [Route("WithProperties")]
        public async Task<IActionResult> FindAllWithProperties() 
        {
            var list = await _application.FindAllWithProperties();
            return Ok(list);
        }
    }
}